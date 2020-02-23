namespace HardLinkTool
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnlink = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnbrowser2 = new System.Windows.Forms.Button();
            this.tbxlink = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnbrowser1 = new System.Windows.Forms.Button();
            this.tbxtarget = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnlink);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnbrowser2);
            this.panel1.Controls.Add(this.tbxlink);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnbrowser1);
            this.panel1.Controls.Add(this.tbxtarget);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 266);
            this.panel1.TabIndex = 0;
            // 
            // btnlink
            // 
            this.btnlink.Location = new System.Drawing.Point(161, 139);
            this.btnlink.Name = "btnlink";
            this.btnlink.Size = new System.Drawing.Size(109, 34);
            this.btnlink.TabIndex = 8;
            this.btnlink.Text = "开始链接";
            this.btnlink.UseVisualStyleBackColor = true;
            this.btnlink.Click += new System.EventHandler(this.btnlink_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(17, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(399, 59);
            this.label3.TabIndex = 7;
            this.label3.Text = "硬连接可复制文件并不占用磁盘空间 但修改会文件会同步到文件本体和所有链接上，覆盖操作则不会引起源文件变动。可直接将需链接文件或文件夹拖放至本程序上即可自动链接。 " +
    "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "链接路径(必须与源路径在同一文件夹下)";
            // 
            // btnbrowser2
            // 
            this.btnbrowser2.Location = new System.Drawing.Point(381, 98);
            this.btnbrowser2.Name = "btnbrowser2";
            this.btnbrowser2.Size = new System.Drawing.Size(54, 21);
            this.btnbrowser2.TabIndex = 5;
            this.btnbrowser2.Text = "浏览";
            this.btnbrowser2.UseVisualStyleBackColor = true;
            this.btnbrowser2.Click += new System.EventHandler(this.btnbrowser2_Click);
            // 
            // tbxlink
            // 
            this.tbxlink.Location = new System.Drawing.Point(3, 98);
            this.tbxlink.Name = "tbxlink";
            this.tbxlink.Size = new System.Drawing.Size(372, 21);
            this.tbxlink.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "源路径(支持拖放多文件或文件夹)";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(394, 245);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(41, 12);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Github";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnbrowser1
            // 
            this.btnbrowser1.Location = new System.Drawing.Point(381, 32);
            this.btnbrowser1.Name = "btnbrowser1";
            this.btnbrowser1.Size = new System.Drawing.Size(54, 21);
            this.btnbrowser1.TabIndex = 1;
            this.btnbrowser1.Text = "浏览";
            this.btnbrowser1.UseVisualStyleBackColor = true;
            this.btnbrowser1.Click += new System.EventHandler(this.btnbrowser1_Click);
            // 
            // tbxtarget
            // 
            this.tbxtarget.AllowDrop = true;
            this.tbxtarget.Location = new System.Drawing.Point(3, 32);
            this.tbxtarget.Name = "tbxtarget";
            this.tbxtarget.Size = new System.Drawing.Size(372, 21);
            this.tbxtarget.TabIndex = 0;
            this.tbxtarget.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbxtarget_DragDrop);
            this.tbxtarget.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbxtarget_DragEnter);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 289);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "硬链接工具";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnbrowser2;
        private System.Windows.Forms.TextBox tbxlink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnbrowser1;
        private System.Windows.Forms.TextBox tbxtarget;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnlink;
    }
}

