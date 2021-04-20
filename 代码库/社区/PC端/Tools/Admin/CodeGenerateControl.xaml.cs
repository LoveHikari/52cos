using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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

namespace Admin
{
    /// <summary>
    /// CodeGenerateControl.xaml 的交互逻辑
    /// </summary>
    public partial class CodeGenerateControl : UserControl
    {
        public CodeGenerateControl()
        {
            InitializeComponent();
        }
        public DataTable ResultDataTable(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection connstr = new SqlConnection(txtConnstr.Text))
            {
                //打开数据库连接
                connstr.Open();
                using (SqlCommand command = connstr.CreateCommand())
                {

                    command.CommandText = sql;
                    command.Parameters.AddRange(parameters);
                    SqlDataAdapter sda = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    //获取表中的全部信息(如填充每个表中的主键和外键等)
                    sda.FillSchema(ds, SchemaType.Source);
                    sda.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }
        /// <summary>
        /// 连接按钮单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConn_Click(object sender, RoutedEventArgs e)
        {
            TablecomboBox.IsEnabled = false;
            btnCreateCode.IsEnabled = false;
            DataTable datatable;
            try
            {
                //获得选择数据库的所有表名
                string sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'";
                datatable = ResultDataTable(sql);
            }
            catch (SqlException se)
            {
                MessageBox.Show("数据库连接错误！" + se.Message);
                return;
            }
            TablecomboBox.IsEnabled = true;
            string[] tables = new string[datatable.Rows.Count];
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                DataRow row = datatable.Rows[i];
                tables[i] = (string)row["TABLE_NAME"];
            }
            //把表名放在下拉框中
            TablecomboBox.ItemsSource = tables;
            TablecomboBox.SelectedIndex = 0;
            btnCreateCode.IsEnabled = true;

            ConfigHelper.Instance.WriteDataBaseConfig(txtConnstr.Text);//把字符串存到根文件夹下面;

        }
        /// <summary>
        /// 生成代码单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateCode_Click(object sender, RoutedEventArgs e)
        {
            string modelpath = ConfigHelper.Instance._ModelPath;
            string dalpath = ConfigHelper.Instance._DalPath;
            string bllpath = ConfigHelper.Instance._BllPath;
            if (TablecomboBox.SelectedIndex < 0)
            {
                MessageBox.Show("请选择一个表");
                return;
            }
            string tableName = TablecomboBox.SelectedItem.ToString();
            DataColumnCollection columns = Returncolumns(tableName);

            //生成实体类
            BuilderModel builderModel = new BuilderModel(GetTableColumnInfo(tableName), tableName, modelpath);
            txtModel.Text = builderModel.CreatModel();
            //生成数据访问代码
            BuilderDAL builderDal = new BuilderDAL(tableName, GetTableColumnInfo(tableName), "SqlHelper.Instance", dalpath);
            txtDAL.Text = builderDal.GetDALCode(true, true, true, true, true, true, true);
            //生成业务逻辑层代码
            BuilderBLL builderBll = new BuilderBLL(tableName, GetTableColumnInfo(tableName), bllpath);
            txtBLL.Text = builderBll.GetBLLCode(true, true, true, true, true, true, true);

            ConfigHelper.Instance.WriteNamespaceConfig("modelpath", txtModelPath.Text);
            ConfigHelper.Instance.WriteNamespaceConfig("dalpath", txtDalPath.Text);
            ConfigHelper.Instance.WriteNamespaceConfig("bllpath", txtBllPath.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TablecomboBox.IsEnabled = false;
            btnCreateCode.IsEnabled = false;
            //把每次连接的字符串存储到1.txt
            txtConnstr.Text = ConfigHelper.Instance._Connstr;
            txtModelPath.Text = ConfigHelper.Instance._ModelPath;
            txtDalPath.Text = ConfigHelper.Instance._DalPath;
            txtBllPath.Text = ConfigHelper.Instance._BllPath;
        }

        #region 返回数据表列名+Returncolumns(string tablename)
        /// <summary>
        /// 返回数据表列名
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <returns></returns>
        public DataColumnCollection Returncolumns(string tablename)
        {
            DataTable datatable = ResultDataTable("select top 0 * from " + tablename);
            DataColumnCollection columns = datatable.Columns;
            return columns;
        }
        #endregion


        #region 返回表的主键集合
        /// <summary>
        /// 返回表的主键集合
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public DataColumn[] GetTablePrimaryKey1(string tablename)
        {
            DataTable datatable = ResultDataTable("select top 0 * from " + tablename);
            DataColumn[] PrimaryKey = datatable.PrimaryKey;
            if (PrimaryKey.Length <= 0)
            {
                return null;
            }
            return PrimaryKey;

        }
        #endregion

        #region 表改变时发生事件
        /// <summary>
        /// 表改变时发生事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TablecomboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtModel.Text = " ";//清空实体模型层代码
            txtDAL.Text = "";//清空数据访问层代码
            txtBLL.Text = "";

            DataColumn[] dc = GetTablePrimaryKey1(TablecomboBox.SelectedValue.ToString());
            List<string> list = new List<string>();
            for (int i = 0; dc != null && i < dc.Length; i++)
            {
                list.Add(dc[i].ToString());
            }
            //加载数据表主键
            cbPrimaryKey.ItemsSource = list;
            cbPrimaryKey.SelectedIndex = 0;
        }
        #endregion

        /// <summary>
        /// 获得字段集合
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        private List<ColumnInfo> GetTableColumnInfo(string tablename)
        {
            DataTable datatable = ResultDataTable($@"SELECT 
                                                    表名   = CASE a.colorder WHEN 1 THEN c.name ELSE '' END, 
                                                    序号     = a.colorder, 
                                                    字段名 = a.name, 
                                                    标识   = CASE COLUMNPROPERTY(a.id,a.name,'IsIdentity') WHEN 1 THEN '√' ELSE '' END, 
                                                    主键   = CASE 
                                                    WHEN EXISTS ( 
                                                    SELECT * 
                                                    FROM sysobjects 
                                                    WHERE xtype='PK' AND name IN ( 
                                                    SELECT name 
                                                    FROM sysindexes 
                                                    WHERE id=a.id AND indid IN ( 
                                                        SELECT indid 
                                                        FROM sysindexkeys 
                                                        WHERE id=a.id AND colid IN ( 
                                                        SELECT colid 
                                                        FROM syscolumns 
                                                        WHERE id=a.id AND name=a.name 
                                                        ) 
                                                    ) 
                                                    ) 
                                                    ) 
                                                    THEN '√' 
                                                    ELSE '' 
                                                    END, 
                                                    类型   = b.name, 
                                                    字节数 = a.length, 
                                                    长度   = COLUMNPROPERTY(a.id,a.name,'Precision'), 
                                                    小数   = CASE ISNULL(COLUMNPROPERTY(a.id,a.name,'Scale'),0) 
                                                    WHEN 0 THEN '' 
                                                    ELSE CAST(COLUMNPROPERTY(a.id,a.name,'Scale') AS VARCHAR) 
                                                    END, 
                                                    允许空 = CASE a.isnullable WHEN 1 THEN '√' ELSE '' END, 
                                                    默认值 = ISNULL(d.[text],''), 
                                                    说明   = ISNULL(e.[value],'') 
                                                    FROM syscolumns a 
                                                    LEFT  JOIN systypes      b ON a.xtype=b.xusertype 
                                                    INNER JOIN sysobjects    c ON a.id=c.id AND c.xtype='U' AND c.name<>'dtproperties' 
                                                    LEFT  JOIN syscomments   d ON a.cdefault=d.id 
                                                    LEFT  JOIN sys.extended_properties e ON a.id=e.major_id AND a.colid=e.minor_id 
                                                    WHERE c.name = '{tablename}'
                                                    ORDER BY c.name, a.colorder");
            List<ColumnInfo> fieldlist = new List<ColumnInfo>();
            foreach (DataRow dataRow in datatable.Rows)
            {
                ColumnInfo field = new ColumnInfo();
                field.ColumnOrder = dataRow["序号"].ToString();
                field.ColumnName = dataRow["字段名"].ToString();
                field.TypeName = dataRow["类型"].ToString();
                field.Length = int.Parse(dataRow["长度"].ToString());
                field.Precision = int.Parse(dataRow["字节数"].ToString());
                field.Scale = dataRow["小数"].ToString();
                field.IsIdentity = dataRow["标识"].ToString() == "√";
                field.IsPrimaryKey = dataRow["主键"].ToString() == "√";
                field.IsCanNull = dataRow["允许空"].ToString() == "√";
                field.DefaultVal = dataRow["默认值"].ToString();
                field.Description = dataRow["说明"].ToString();
                fieldlist.Add(field);
            }
            return fieldlist;
        }
    }
}
