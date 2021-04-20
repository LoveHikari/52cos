using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Api;
using DBHelper;
using Entity;

namespace Admin
{
    public partial class DataForm : Form
    {
        //private DataAccess da;
        public DataForm()
        {
            InitializeComponent();
        }
        private void DataForm_Load(object sender, EventArgs e)
        {
            //da = new DataAccess("ConnLink");
            //da.CreateConnection();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //textBox1.Text += "MySQL>正在创建数据库...";
            //da.ExecuteCommand("create datebase ESSoft");
            //textBox1.Text += "MySQL>正在创建表（）...";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataAccess oldda = new DataAccess("oldConnLink");
            oldda.CreateConnection();
            string sql = "SELECT * FROM dbo.cos_member";
            DataTable dt = oldda.GetDataTable(sql);

            foreach (DataRow dataRow in dt.Rows)
            {
                MemberEntity newMemberEntity = new MemberEntity();
                newMemberEntity.User_name = dataRow["User_name"].ToString();
                newMemberEntity.Password = dataRow["Password"].ToString();
                newMemberEntity.Real_name = dataRow["Real_name"].ToString();
                newMemberEntity.Gender = dataRow["Gender"].ToString();
                newMemberEntity.Birthday = dataRow["Birthday"].ToString();
                newMemberEntity.Reg_time = Convert.ToDateTime(dataRow["Reg_time"]);
                newMemberEntity.Last_login = Convert.ToDateTime(dataRow["Last_login"].ToString());
                newMemberEntity.Portrait = dataRow["Portrait"].ToString();
                newMemberEntity.integral = Convert.ToInt32(dataRow["integral"].ToString());
                newMemberEntity.ardent = Convert.ToInt32(dataRow["ardent"].ToString());
                newMemberEntity.Growth = Convert.ToInt32(dataRow["Growth"].ToString());
                int userid = MemberDb.Instance.Add(newMemberEntity);

                sql = $@"SELECT * FROM dbo.sns_ordinaryNote
                        WHERE User_id='{dataRow["User_id"]}'";
                DataTable note = oldda.GetDataTable(sql);
                foreach (DataRow row in note.Rows)
                {
                    sql = $@"SELECT * FROM dbo.sns_noteImg
                        WHERE NoteId='{row["NoteId"]}'";
                    DataTable img = oldda.GetDataTable(sql);
                    string iss = "";
                    foreach (DataRow dataRow1 in img.Rows)
                    {
                        ImgEntity imgEntity = new ImgEntity();
                        imgEntity.ImgUrl = "/" + dataRow1["ImgUrl"].ToString();
                        imgEntity.addtime = DateTime.Now;
                        imgEntity.Status = 1;
                        MemberDb.Instance.Add(imgEntity);
                        iss += "<img src='/"+ dataRow1["ImgUrl"] + "' alt=''>";
                    }

                    WorksEntity worksEntity = new WorksEntity();
                    worksEntity.User_id = userid.ToString();
                    worksEntity.WorksTitle = row["notetitle"].ToString();
                    worksEntity.WorksType = "20";
                    worksEntity.Type2 = "24";
                    worksEntity.LabelDesc = row["LabelDesc"].ToString();
                    worksEntity.WorksContent = "<div>" + row["notecontent"] + "</div>" + iss;
                    worksEntity.Root = "0";
                    worksEntity.Keep = "1";
                    worksEntity.Watermark = "1";
                    worksEntity.ReleaseTime = Convert.ToDateTime(row["ReleaseTime"]);
                    worksEntity.UpdateTime = Convert.ToDateTime(row["UpdateTime"]);
                    worksEntity.Status = 1;
                    worksEntity.source = "original";
                    MemberDb.Instance.Add(worksEntity);
                }
                

            }
            MessageBox.Show("完成");

        }
    }
}
