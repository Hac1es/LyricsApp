using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using HtmlAgilityPack;
using System.Net;

namespace LyricsApp
{
    public partial class Form1 : Form
    {
        private const string clientID = "ERdyLWio0g41s06xQ2vtKA8703lnGldURUR9tTYe7hQZlZ7wCmJ_SJIZ_GMBXQtF";
        private const string clientSecret = "TX0wBJJmuOltMnMVHwmtiPYLBXSQFGH0XlsacdqXQksPzc4lR8D28d5An10o_UKQvJvBa1mgos06LZwTa24tDw";
        private const string tokenUrl = "https://api.genius.com/oauth/token"; //Endpoint của Genius
        private string accessToken;
        public Form1()
        {
            InitializeComponent();
        }

        //Dùng OAuth2 Credentials Flow
        private async Task<string> getToken()
        {
            using (HttpClient client = new HttpClient())
            {
                //Mã hóa thành Base64                                                        
                byte[] bytes = Encoding.UTF8.GetBytes($"{clientID}:{clientSecret}");
                client.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("Basic", Convert.ToBase64String(bytes));
                //Soạn request
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, tokenUrl);
                request.Content =
                    new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");
                //Gửi request
                var response = await client.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();
                //Lấy token trả về, parse từ dạng JSON
                JObject json = JObject.Parse(responseBody);
                string Token = json["access_token"].ToString();
                return Token;
            } 
                
        }

        private async void getLyric_Click(object sender, EventArgs e)
        {
            accessToken = await getToken(); //Lấy về access_token
            string songTitle;
            string artist;
            if (userInput.Text.Contains("-")) //Nếu người dùng nhập theo dạng "Tên bài hát - Nghệ sĩ"
            {
                string[] parts = userInput.Text.Split(new string[] { " - " }, StringSplitOptions.None);

                if (parts.Length == 2)
                {
                    songTitle = parts[0].Trim();  // Tên bài hát
                    artist = parts[1].Trim();     // Tên nghệ sĩ
                }
                else
                {
                    MessageBox.Show("Định dạng đầu vào không hợp lệ.");
                    return;
                }
            }
            else
            {
                // Nếu người dùng nhập mỗi tên bài hát
                songTitle = userInput.Text; //Tên bài hát
                artist = string.Empty; //Tên nghệ sĩ = null
            }
            var lyrics = await GetLyrics(songTitle, artist); //Gọi hàm lấy lời bài hát và đợi nó hoàn tất
            lyricShow.Text = lyrics; //Hiện thị lời bài hát
        }

        private async Task<string> GetLyrics(string songTitle, string artist)
        {
            using (HttpClient client = new HttpClient()) 
            {
                client.DefaultRequestHeaders.Authorization 
                    = new AuthenticationHeaderValue("Bearer", accessToken); //gán accessToken vào header lệnh GET
                string searchUrl;
                if (artist != null)
                    searchUrl 
                        = $"https://api.genius.com/search?q={Uri.EscapeDataString(songTitle + " " + artist)}"; //Tên bài
                else
                    searchUrl 
                        = $"https://api.genius.com/search?q={Uri.EscapeDataString(songTitle)}";//Tên bài + Nghệ sĩ
                var response = await client.GetAsync(searchUrl);//chờ API Genius trả lời
                if (!response.IsSuccessStatusCode)
                    return "Không tìm thấy lời bài hát!";
                //Đọc chuỗi JSON trả về và parse ra link tới lời bài hát
                var content = await response.Content.ReadAsStringAsync();
                JObject jsondilla = JObject.Parse(content);
                if (jsondilla["response"]["hits"].HasValues)
                {
                    var lyrics_api = jsondilla["response"]["hits"][0]["result"]["path"].ToString();
                    string lyrics_url = $"https://genius.com{lyrics_api}";// link tới lời bài hát
                    return await GetLyricsFromSongUrl(lyrics_url);// Lấy file HTML về để xử lý
                }
                else
                    return "Không tìm thấy lời bài hát!";
            }
        }

        private async Task<string> GetLyricsFromSongUrl(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync(); //File HTML chứa lời bài hát
                HtmlAgilityPack.HtmlDocument htmlDoc 
                    = new HtmlAgilityPack.HtmlDocument(); //Đưa vào HTMLDocument để dễ xử lý
                htmlDoc.LoadHtml(content);
                var lyricsDivs 
                    = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'Lyrics__Container')]"); //Chọn tất cả các thẻ <div> chứa lời bài hát
                if (lyricsDivs == null || lyricsDivs.Count == 0)
                    return "Không tìm thấy lời bài hát!";
                StringBuilder lyrics = new StringBuilder();
                //Xử lý file HTML
                foreach (var div in lyricsDivs) //Mỗi thẻ div chứa lời bài hát
                    foreach (var node in div.DescendantsAndSelf()) //Mỗi thẻ con của <div>
                    {
                        // Nếu gặp thẻ <br> thì thêm dấu xuống dòng
                        if (node.Name == "br")
                        {
                            lyrics.Append("\n");
                        }
                        // Nếu gặp thẻ <p> thì thêm một dòng trống (ngắt đoạn)
                        else if (node.Name == "p")
                        {
                            lyrics.Append("\n\n");
                        }
                        // Nếu là văn bản, thì thêm nó vào kết quả
                        else if (node.NodeType == HtmlAgilityPack.HtmlNodeType.Text)
                        {
                            // Loại bỏ các khoảng trắng dư thừa
                            var text = node.InnerText.Trim();
                            if (!string.IsNullOrEmpty(text))
                            {
                                lyrics.Append(WebUtility.HtmlDecode(text));
                            }
                        }
                    }

                // Trả về chuỗi lời bài hát đã xử lý
                return lyrics.ToString().Trim();
            } 
                
        }

        private void _clear_Click(object sender, EventArgs e)
        {
            userInput.Text = string.Empty;
            lyricShow.Text = string.Empty;
            accessToken = null;
        }
    }
}
