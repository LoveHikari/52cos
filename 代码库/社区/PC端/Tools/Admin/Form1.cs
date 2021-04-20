using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBHelper;

namespace Admin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void 生成数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllMDIForm();
            DataForm df = new DataForm();
            this.IsMdiContainer = true;
            df.MdiParent = this;
            df.Show();
            
        }

        private void 数据库连接字符串加解密ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllMDIForm();
            DEncryptForm df = new DEncryptForm();
            this.IsMdiContainer = true;
            df.MdiParent = this;
            df.Show();
        }

        /// <summary>
        /// 关闭所有MDI子窗体
        /// </summary>
        private void CloseAllMDIForm()
        {
            Form[] frmList = this.MdiChildren;
            foreach (Form frm in frmList)
            {
                frm.Close();
            }
        }
    }
}
