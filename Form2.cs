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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string strCon = StringConnection.Instance().ToString();
        DataClasses1DataContext linq;
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            BindInfo();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            linq = new DataClasses1DataContext(strCon);
            总包明细 test = new 总包明细();
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入项目名称");
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("请输入日期");
                return;

            }
            if (textBox2.Text == "")
            {
                textBox2.Text = "0";
            }
            if (textBox3.Text == "")
            {
                textBox3.Text = "0";
            }
            if (textBox5.Text == "")
            {
                textBox5.Text = "0";
            }
            if (textBox6.Text == "")
            {
                textBox6.Text = "0";
            }
            test.项目 = textBox1.Text;
            test.开票金额 = double.Parse(textBox2.Text);
            test.收款金额 = double.Parse(textBox3.Text);
            test.日期 = DateTime.Parse(textBox4.Text);
            test.收票金额 = double.Parse(textBox5.Text);
            test.付款金额 = double.Parse(textBox6.Text);
            test.调整金额 = 0;
            linq.总包明细.InsertOnSubmit(test);
            linq.SubmitChanges();
            MessageBox.Show("数据添加成功");
            BindInfo();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
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
        private void BindInfo()
        {
            linq = new DataClasses1DataContext(strCon);
            
            {

                var result = from info in linq.总包明细

                             select new
                             {
                                 项目 = info.项目,
                                 开票金额 = info.开票金额,
                                 收款金额 = info.收款金额,
                                 收票金额 = info.收票金额,
                                 付款金额 = info.付款金额,
                                 日期=info.日期
                             };

                dataGridView1.DataSource = result;
            }
        }
}
}
