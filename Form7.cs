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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        string strCon = StringConnection.Instance().ToString();
        DataClasses1DataContext linq;
        string ID = "";
        private void Form7_Load(object sender, EventArgs e)
        {
            BindInfo();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex > -1)
            {
                ID = Convert.ToString(dataGridView1[0, e.RowIndex].Value).Trim();
            }
        }






      
            

        
        private void BindInfo()
        {
            linq = new DataClasses1DataContext(strCon);

            {

                var result = from info in linq.总包明细

                             select new
                             {
                                 编号=info.编号,
                                 项目 = info.项目,
                                 开票金额 = info.开票金额,
                                 收款金额 = info.收款金额,
                                 收票金额 = info.收票金额,
                                 付款金额 = info.付款金额,
                                 收款调整金额=info.收款调整金额,
                                 日期 = info.日期
                             };

                dataGridView1.DataSource = result;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 删除ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (ID == "")
            {
                MessageBox.Show("请选择要删除的记录");
                return;
            }
            linq = new DataClasses1DataContext(strCon);
            var result = from info in linq.总包明细
                         where info.编号.ToString() == ID
                         select info;
            linq.总包明细.DeleteAllOnSubmit(result);
            linq.SubmitChanges();
            MessageBox.Show("信息删除成功");
            BindInfo();
        }
    }
}
