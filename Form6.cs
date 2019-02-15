using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 总包test
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringConnection s = StringConnection.Instance();
            s.Database = 数据库.Text;
            s.Uid = 账号.Text;
            s.Pwd = 密码.Text;

            var linq = new DataClasses1DataContext(s.ToString());

            var result = from info in linq.总包明细
                            select new
                            {
                                项目 = info.项目
                            };
            try
            {
                foreach (var item in result)
                {
                }

                this.Visible = false;
                new Form1().Show();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
