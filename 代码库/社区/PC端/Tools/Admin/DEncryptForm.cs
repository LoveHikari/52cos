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
    public partial class DEncryptForm : Form
    {
        public DEncryptForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 数据库字符串加密
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = DEncryptUtils.DESEncrypt(textBox1.Text);
        }
        /// <summary>
        /// 数据库字符串解密
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = DEncryptUtils.DESDecrypt(textBox2.Text);
        }
        /// <summary>
        /// 密码加密
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = DEncryptUtils.Encrypt3DES(textBox1.Text);
        }
        /// <summary>
        /// 密码解密
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = DEncryptUtils.Decrypt3DES(textBox2.Text);
        }
    }
}
