namespace LyricsApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.userInput = new System.Windows.Forms.RichTextBox();
            this.getLyric = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lyricShow = new System.Windows.Forms.RichTextBox();
            this._clearKeo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // userInput
            // 
            this.userInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userInput.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInput.Location = new System.Drawing.Point(25, 22);
            this.userInput.Name = "userInput";
            this.userInput.Size = new System.Drawing.Size(679, 38);
            this.userInput.TabIndex = 0;
            this.userInput.Text = "";
            // 
            // getLyric
            // 
            this.getLyric.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.getLyric.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getLyric.Location = new System.Drawing.Point(742, 22);
            this.getLyric.Name = "getLyric";
            this.getLyric.Size = new System.Drawing.Size(139, 37);
            this.getLyric.TabIndex = 1;
            this.getLyric.Text = "Lời bài hát";
            this.getLyric.UseVisualStyleBackColor = true;
            this.getLyric.Click += new System.EventHandler(this.getLyric_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lyricShow);
            this.panel1.Location = new System.Drawing.Point(25, 156);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1018, 571);
            this.panel1.TabIndex = 2;
            // 
            // lyricShow
            // 
            this.lyricShow.BackColor = System.Drawing.Color.White;
            this.lyricShow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lyricShow.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lyricShow.Location = new System.Drawing.Point(16, 16);
            this.lyricShow.Name = "lyricShow";
            this.lyricShow.ReadOnly = true;
            this.lyricShow.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.lyricShow.Size = new System.Drawing.Size(999, 531);
            this.lyricShow.TabIndex = 0;
            this.lyricShow.Text = "";
            // 
            // _clearKeo
            // 
            this._clearKeo.BackColor = System.Drawing.Color.Firebrick;
            this._clearKeo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._clearKeo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._clearKeo.Location = new System.Drawing.Point(904, 22);
            this._clearKeo.Name = "_clearKeo";
            this._clearKeo.Size = new System.Drawing.Size(139, 37);
            this._clearKeo.TabIndex = 3;
            this._clearKeo.Text = "Xóa";
            this._clearKeo.UseVisualStyleBackColor = false;
            this._clearKeo.Click += new System.EventHandler(this._clearKeo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 60);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cách nhập:\r\nTên bài hát, ví dụ: Shape of you\r\nTên bài hát - Nghệ sĩ, ví dụ: Mang " +
    "tiền về cho mẹ - Đen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(841, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "Powered by";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(966, 75);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 756);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._clearKeo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.getLyric);
            this.Controls.Add(this.userInput);
            this.Name = "Form1";
            this.Text = "Tìm lời bài hát";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox userInput;
        private System.Windows.Forms.Button getLyric;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox lyricShow;
        private System.Windows.Forms.Button _clearKeo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

