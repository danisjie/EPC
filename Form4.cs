using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace 总包test
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        private void Form4_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(StringConnection.Instance().ToString());
            query();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            query();
        }

        private void query()
        {
            string c;
            if (textBox1.Text == "")
                c = "Select 项目,SUM(开票金额) as 开票金额,sum(收票金额) as 收票金额 ,sum(收款金额) as 收款金额 ,sum(付款金额) as 付款金额,sum(收款调整金额) as 收款调整金额 From 总包明细 group by 项目";
            else
                c = "Select 项目,SUM(开票金额) as 开票金额,sum(收票金额) as 收票金额 ,sum(收款金额) as 收款金额 ,sum(付款金额) as 付款金额 ,sum(收款调整金额) as 收款调整金额 From 总包明细 WHERE 项目 like'%" + textBox1.Text + "%' group by 项目";

            SqlCommand cmd = new SqlCommand(StringConnection.Instance().ToString());
            SqlDataAdapter sda = new SqlDataAdapter(c, conn);
         
            DataSet ds = new DataSet();
            sda.Fill(ds, "cs");
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
