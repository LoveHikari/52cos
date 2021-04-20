using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Api;
using System.Data.SqlClient;
using System.IO;
using System.Threading;

namespace WpfApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string Connstr;
        /// <summary>
        /// 连接按钮单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConn_Click(object sender, RoutedEventArgs e)
        {
            Connstr = $"SERVER={txtServer.Text};uid={txtUid.Text};pwd={txtPwd.Text};DATABASE={txtDataBase.Text}";
            try
            {
                //获得选择数据库的所有表名
                SqlHelper sqlHelper = new SqlHelper(Connstr);
                string sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'";
                sqlHelper.ExecSqlDataTable(sql);

                btnNowBack.IsEnabled = true;
                btnAutoBack.IsEnabled = true;
                btnConn.IsEnabled = false;
                txtServer.IsEnabled = false;
                txtUid.IsEnabled = false;
                txtPwd.IsEnabled = false;
                txtDataBase.IsEnabled = false;
            }
            catch (SqlException se)
            {
                WriteLog.WriteError(se);
                MessageBox.Show("数据库连接错误！" + se.Message);
                throw se;
            }
        }
        /// <summary>
        /// 立即备份单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNowBack_Click(object sender, RoutedEventArgs e)
        {

            DataBaseActions.Instance.BackUPDB(Connstr, "ESSoft2");

            WriteLog.WriteSucceed(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "备份成功");
            MessageBox.Show("备份完成");

        }

        private void btnAutoBack_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(Scheduler));
            thread.Start();
        }


        private void Scheduler()
        {
            this.txtLog.Dispatcher.Invoke(new Action(() => { this.txtLog.AppendText("启动自动备份\r\n"); this.txtLog.ScrollToEnd(); }));
            while (true)
            {
                string str = DateTime.Now.ToString("HH:mm:ss");
                if (str == "03:30:00")
                {
                    this.txtLog.Dispatcher.Invoke(new Action(() => { this.txtLog.AppendText("开始备份\r\n"); this.txtLog.ScrollToEnd(); }));
                    new Thread(new ThreadStart(SampleJob)).Start();
                }

                Thread.Sleep(1000);
            }
        }

        private void SampleJob()
        {
            try
            {

                DataBaseActions.Instance.BackUPDB(Connstr, "ESSoft2");
                WriteLog.WriteSucceed(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "备份成功");

            }
            catch (Exception ex)
            {
                WriteLog.WriteError(ex);
            }
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //终止所有线程 
            Environment.Exit(Environment.ExitCode);
        }
    }
}
