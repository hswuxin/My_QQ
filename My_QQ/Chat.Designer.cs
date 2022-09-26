namespace My_QQ
{
    partial class Chat
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chat));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.closeText = new System.Windows.Forms.Button();
            this.sendText = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.richTextBox_tm2 = new My_QQ.RichTextBox_tm();
            this.richTextBox_tm1 = new My_QQ.RichTextBox_tm();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(7, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.label1.Location = new System.Drawing.Point(96, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::My_QQ.Properties.Resources.min_;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Location = new System.Drawing.Point(368, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 23);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click_1);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = global::My_QQ.Properties.Resources.close;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Location = new System.Drawing.Point(431, 6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(27, 23);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // closeText
            // 
            this.closeText.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.closeText.Location = new System.Drawing.Point(279, 478);
            this.closeText.Name = "closeText";
            this.closeText.Size = new System.Drawing.Size(83, 31);
            this.closeText.TabIndex = 5;
            this.closeText.TabStop = false;
            this.closeText.Text = "关闭";
            this.closeText.UseVisualStyleBackColor = true;
            this.closeText.Click += new System.EventHandler(this.closeText_Click);
            // 
            // sendText
            // 
            this.sendText.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.sendText.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sendText.Location = new System.Drawing.Point(368, 478);
            this.sendText.Name = "sendText";
            this.sendText.Size = new System.Drawing.Size(83, 31);
            this.sendText.TabIndex = 5;
            this.sendText.TabStop = false;
            this.sendText.Text = "发送";
            this.sendText.UseVisualStyleBackColor = false;
            this.sendText.Click += new System.EventHandler(this.sendText_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1.bmp");
            this.imageList1.Images.SetKeyName(1, "2.bmp");
            this.imageList1.Images.SetKeyName(2, "3.bmp");
            this.imageList1.Images.SetKeyName(3, "4.bmp");
            this.imageList1.Images.SetKeyName(4, "5.bmp");
            this.imageList1.Images.SetKeyName(5, "6.bmp");
            this.imageList1.Images.SetKeyName(6, "7.bmp");
            this.imageList1.Images.SetKeyName(7, "8.bmp");
            this.imageList1.Images.SetKeyName(8, "9.bmp");
            this.imageList1.Images.SetKeyName(9, "10.bmp");
            this.imageList1.Images.SetKeyName(10, "11.bmp");
            this.imageList1.Images.SetKeyName(11, "12.bmp");
            this.imageList1.Images.SetKeyName(12, "13.bmp");
            this.imageList1.Images.SetKeyName(13, "14.bmp");
            this.imageList1.Images.SetKeyName(14, "15.bmp");
            this.imageList1.Images.SetKeyName(15, "16.bmp");
            this.imageList1.Images.SetKeyName(16, "17.bmp");
            this.imageList1.Images.SetKeyName(17, "18.bmp");
            this.imageList1.Images.SetKeyName(18, "19.bmp");
            this.imageList1.Images.SetKeyName(19, "20.bmp");
            this.imageList1.Images.SetKeyName(20, "21.bmp");
            this.imageList1.Images.SetKeyName(21, "22.bmp");
            this.imageList1.Images.SetKeyName(22, "23.bmp");
            this.imageList1.Images.SetKeyName(23, "24.bmp");
            this.imageList1.Images.SetKeyName(24, "25.bmp");
            this.imageList1.Images.SetKeyName(25, "26.bmp");
            this.imageList1.Images.SetKeyName(26, "27.bmp");
            this.imageList1.Images.SetKeyName(27, "28.bmp");
            this.imageList1.Images.SetKeyName(28, "29.bmp");
            this.imageList1.Images.SetKeyName(29, "30.bmp");
            this.imageList1.Images.SetKeyName(30, "31.bmp");
            this.imageList1.Images.SetKeyName(31, "32.bmp");
            this.imageList1.Images.SetKeyName(32, "33.bmp");
            this.imageList1.Images.SetKeyName(33, "34.bmp");
            this.imageList1.Images.SetKeyName(34, "35.bmp");
            this.imageList1.Images.SetKeyName(35, "36.bmp");
            this.imageList1.Images.SetKeyName(36, "37.bmp");
            this.imageList1.Images.SetKeyName(37, "38.bmp");
            this.imageList1.Images.SetKeyName(38, "39.bmp");
            this.imageList1.Images.SetKeyName(39, "40.bmp");
            this.imageList1.Images.SetKeyName(40, "41.bmp");
            this.imageList1.Images.SetKeyName(41, "42.bmp");
            this.imageList1.Images.SetKeyName(42, "43.bmp");
            this.imageList1.Images.SetKeyName(43, "44.bmp");
            this.imageList1.Images.SetKeyName(44, "45.bmp");
            this.imageList1.Images.SetKeyName(45, "46.bmp");
            this.imageList1.Images.SetKeyName(46, "47.bmp");
            this.imageList1.Images.SetKeyName(47, "48.bmp");
            this.imageList1.Images.SetKeyName(48, "49.bmp");
            this.imageList1.Images.SetKeyName(49, "50.bmp");
            this.imageList1.Images.SetKeyName(50, "51.bmp");
            this.imageList1.Images.SetKeyName(51, "52.bmp");
            this.imageList1.Images.SetKeyName(52, "53.bmp");
            this.imageList1.Images.SetKeyName(53, "54.bmp");
            this.imageList1.Images.SetKeyName(54, "55.bmp");
            this.imageList1.Images.SetKeyName(55, "56.bmp");
            this.imageList1.Images.SetKeyName(56, "57.bmp");
            this.imageList1.Images.SetKeyName(57, "58.bmp");
            this.imageList1.Images.SetKeyName(58, "59.bmp");
            this.imageList1.Images.SetKeyName(59, "60.bmp");
            this.imageList1.Images.SetKeyName(60, "61.bmp");
            this.imageList1.Images.SetKeyName(61, "62.bmp");
            this.imageList1.Images.SetKeyName(62, "63.bmp");
            this.imageList1.Images.SetKeyName(63, "64.bmp");
            this.imageList1.Images.SetKeyName(64, "65.bmp");
            this.imageList1.Images.SetKeyName(65, "66.bmp");
            this.imageList1.Images.SetKeyName(66, "67.bmp");
            this.imageList1.Images.SetKeyName(67, "68.bmp");
            this.imageList1.Images.SetKeyName(68, "69.bmp");
            this.imageList1.Images.SetKeyName(69, "70.bmp");
            this.imageList1.Images.SetKeyName(70, "71.bmp");
            this.imageList1.Images.SetKeyName(71, "72.bmp");
            this.imageList1.Images.SetKeyName(72, "73.bmp");
            this.imageList1.Images.SetKeyName(73, "74.bmp");
            this.imageList1.Images.SetKeyName(74, "75.bmp");
            this.imageList1.Images.SetKeyName(75, "76.bmp");
            this.imageList1.Images.SetKeyName(76, "77.bmp");
            this.imageList1.Images.SetKeyName(77, "78.bmp");
            this.imageList1.Images.SetKeyName(78, "79.bmp");
            this.imageList1.Images.SetKeyName(79, "80.bmp");
            this.imageList1.Images.SetKeyName(80, "81.bmp");
            this.imageList1.Images.SetKeyName(81, "82.bmp");
            this.imageList1.Images.SetKeyName(82, "83.bmp");
            this.imageList1.Images.SetKeyName(83, "84.bmp");
            this.imageList1.Images.SetKeyName(84, "85.bmp");
            this.imageList1.Images.SetKeyName(85, "86.bmp");
            this.imageList1.Images.SetKeyName(86, "87.bmp");
            this.imageList1.Images.SetKeyName(87, "88.bmp");
            this.imageList1.Images.SetKeyName(88, "89.bmp");
            this.imageList1.Images.SetKeyName(89, "90.bmp");
            this.imageList1.Images.SetKeyName(90, "91.bmp");
            this.imageList1.Images.SetKeyName(91, "92.bmp");
            this.imageList1.Images.SetKeyName(92, "93.bmp");
            this.imageList1.Images.SetKeyName(93, "94.bmp");
            this.imageList1.Images.SetKeyName(94, "95.bmp");
            this.imageList1.Images.SetKeyName(95, "96.bmp");
            this.imageList1.Images.SetKeyName(96, "97.bmp");
            this.imageList1.Images.SetKeyName(97, "98.bmp");
            this.imageList1.Images.SetKeyName(98, "99.bmp");
            this.imageList1.Images.SetKeyName(99, "100.bmp");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(102, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(179, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "label3";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // richTextBox_tm2
            // 
            this.richTextBox_tm2.BackColor = System.Drawing.Color.Black;
            this.richTextBox_tm2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_tm2.Location = new System.Drawing.Point(3, 324);
            this.richTextBox_tm2.Name = "richTextBox_tm2";
            this.richTextBox_tm2.Size = new System.Drawing.Size(460, 127);
            this.richTextBox_tm2.TabIndex = 8;
            this.richTextBox_tm2.Text = "";
            // 
            // richTextBox_tm1
            // 
            this.richTextBox_tm1.Location = new System.Drawing.Point(1, 80);
            this.richTextBox_tm1.Name = "richTextBox_tm1";
            this.richTextBox_tm1.Size = new System.Drawing.Size(460, 232);
            this.richTextBox_tm1.TabIndex = 9;
            this.richTextBox_tm1.Text = "";
            // 
            // Chat
            // 
            this.AcceptButton = this.sendText;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BackgroundImage = global::My_QQ.Properties.Resources.chat_bg;
            this.ClientSize = new System.Drawing.Size(463, 521);
            this.Controls.Add(this.richTextBox_tm2);
            this.Controls.Add(this.richTextBox_tm1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sendText);
            this.Controls.Add(this.closeText);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Chat";
            this.Text = "Chat";
            this.Load += new System.EventHandler(this.Chat_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Chat_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button closeText;
        private System.Windows.Forms.Button sendText;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private RichTextBox_tm richTextBox_tm1;
        private RichTextBox_tm richTextBox_tm2;
    }
}