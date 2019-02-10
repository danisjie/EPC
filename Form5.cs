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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        string strCon = StringConnection.Instance().ToString();
        DataClasses1DataContext linq;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            linq = new DataClasses1DataContext(strCon);
            string id;
            if (e.RowIndex > -1)
            {
                id = Convert.ToString(dataGridView1[0, e.RowIndex].Value).Trim();
                var result = from info in linq.总包test明细
                             where id == info.项目
                             select new
                             {
                                 项目 = info.项目,
                                 开票金额 = info.开票金额,
                                 收款金额 = info.收款金额,
                                 收票金额 = info.收票金额,
                                 付款金额 = info.付款金额,
                                 日期 = info.日期,
                                 编号 = info.编号
                             };

                foreach (var item in result)
                {
                    textBox1.Text = item.项目;
                    textBox2.Text = item.开票金额.ToString();
                    textBox3.Text = item.收款金额.ToString();
                    textBox4.Text = item.日期.Value.ToString("yyyy/MM/dd");
                    textBox5.Text = item.收票金额.ToString();
                    textBox6.Text = item.付款金额.ToString();
                    m_selectedIndex = item.编号;
                }
            }
        }

        private void BindInfo()
        {
            linq = new DataClasses1DataContext(strCon);

            {

                var result = from info in linq.总包test明细

                             select new
                             {
                                 项目 = info.项目,
                                 开票金额 = info.开票金额,
                                 收款金额 = info.收款金额,
                                 收票金额 = info.收票金额,
                                 付款金额 = info.付款金额,
                                 日期 = info.日期
                             };

                dataGridView1.DataSource = result;
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            BindInfo();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请选择要修改的记录");
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("请输入日期");
                return;
            }
            linq = new DataClasses1DataContext(strCon);

            var result = from info in linq.总包test明细
                         where m_selectedIndex == info.编号
                         select info;

            if (result.Count() == 1)
            {
                foreach (总包test明细 item in result)
                {
                    item.项目 = textBox1.Text;
                    item.开票金额 = double.Parse(textBox2.Text);
                    item.收款金额 = double.Parse(textBox3.Text);
                    item.日期 = DateTime.Parse(textBox4.Text);
                    item.收票金额 = double.Parse(textBox5.Text);
                    item.付款金额 = double.Parse(textBox6.Text);
                }
                linq.SubmitChanges();
                MessageBox.Show("员工信息修改成功");
                BindInfo();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private int m_selectedIndex;
    }
}
