﻿namespace sendform
{
    partial class dbname1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.iptext = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtport = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtpath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dbuser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dbpassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dbname = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtds = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 12F);
            this.button1.Location = new System.Drawing.Point(233, 354);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 44);
            this.button1.TabIndex = 0;
            this.button1.Text = "开启发送";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // iptext
            // 
            this.iptext.Location = new System.Drawing.Point(216, 34);
            this.iptext.Name = "iptext";
            this.iptext.Size = new System.Drawing.Size(197, 21);
            this.iptext.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(111, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "目标地址：";
            // 
            // txtport
            // 
            this.txtport.Location = new System.Drawing.Point(216, 73);
            this.txtport.Name = "txtport";
            this.txtport.Size = new System.Drawing.Size(197, 21);
            this.txtport.TabIndex = 3;
            this.txtport.Text = "8989";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(111, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "端口：";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // txtpath
            // 
            this.txtpath.Location = new System.Drawing.Point(216, 111);
            this.txtpath.Name = "txtpath";
            this.txtpath.ReadOnly = true;
            this.txtpath.Size = new System.Drawing.Size(197, 21);
            this.txtpath.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(111, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "文件夹：";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(419, 111);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "选择";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F);
            this.label4.Location = new System.Drawing.Point(90, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "数据库用户名：";
            // 
            // dbuser
            // 
            this.dbuser.Location = new System.Drawing.Point(216, 193);
            this.dbuser.Name = "dbuser";
            this.dbuser.Size = new System.Drawing.Size(197, 21);
            this.dbuser.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F);
            this.label5.Location = new System.Drawing.Point(106, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "数据库密码：";
            // 
            // dbpassword
            // 
            this.dbpassword.Location = new System.Drawing.Point(216, 226);
            this.dbpassword.Name = "dbpassword";
            this.dbpassword.PasswordChar = '*';
            this.dbpassword.Size = new System.Drawing.Size(197, 21);
            this.dbpassword.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F);
            this.label6.Location = new System.Drawing.Point(106, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "数据库名称：";
            // 
            // dbname
            // 
            this.dbname.Location = new System.Drawing.Point(216, 259);
            this.dbname.Name = "dbname";
            this.dbname.Size = new System.Drawing.Size(197, 21);
            this.dbname.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F);
            this.label7.Location = new System.Drawing.Point(90, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "是否发送数据库：";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "是",
            "否"});
            this.comboBox1.Location = new System.Drawing.Point(218, 161);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F);
            this.label8.Location = new System.Drawing.Point(90, 291);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "备份时间分钟：";
            // 
            // txtds
            // 
            this.txtds.Location = new System.Drawing.Point(218, 292);
            this.txtds.Name = "txtds";
            this.txtds.Size = new System.Drawing.Size(197, 21);
            this.txtds.TabIndex = 18;
            this.txtds.Text = "5";
            // 
            // dbname1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 425);
            this.Controls.Add(this.txtds);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dbname);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dbpassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dbuser);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtpath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.iptext);
            this.Controls.Add(this.button1);
            this.Name = "dbname1";
            this.Text = "发送端";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Dbname1_FormClosed);
            this.Load += new System.EventHandler(this.Dbname1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox iptext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtpath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dbuser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox dbpassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox dbname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtds;
    }
}

