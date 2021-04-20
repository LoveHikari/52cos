namespace Admin
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.工具栏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成数据库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库连接字符串加解密ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.工具栏ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(836, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 工具栏ToolStripMenuItem
            // 
            this.工具栏ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.生成数据库ToolStripMenuItem,
            this.数据库连接字符串加解密ToolStripMenuItem});
            this.工具栏ToolStripMenuItem.Name = "工具栏ToolStripMenuItem";
            this.工具栏ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.工具栏ToolStripMenuItem.Text = "工具栏";
            // 
            // 生成数据库ToolStripMenuItem
            // 
            this.生成数据库ToolStripMenuItem.Name = "生成数据库ToolStripMenuItem";
            this.生成数据库ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.生成数据库ToolStripMenuItem.Text = "生成数据库";
            this.生成数据库ToolStripMenuItem.Click += new System.EventHandler(this.生成数据库ToolStripMenuItem_Click);
            // 
            // 数据库连接字符串加解密ToolStripMenuItem
            // 
            this.数据库连接字符串加解密ToolStripMenuItem.Name = "数据库连接字符串加解密ToolStripMenuItem";
            this.数据库连接字符串加解密ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.数据库连接字符串加解密ToolStripMenuItem.Text = "数据库连接字符串加解密";
            this.数据库连接字符串加解密ToolStripMenuItem.Click += new System.EventHandler(this.数据库连接字符串加解密ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 392);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "工具箱";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 工具栏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成数据库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据库连接字符串加解密ToolStripMenuItem;
    }
}

