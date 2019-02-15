using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace 总包test
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        string strCon = StringConnection.Instance().ToString();
        DataClasses1DataContext linq;
    private void Form3_Load(object sender, EventArgs e)
        {
            BindInfo();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindInfo();
        }
        private void BindInfo()
        {
            linq = new DataClasses1DataContext(strCon);
            if (textBox1.Text == "")
            {
                
                var result = from info in linq.总包明细
               
                              select new
                             {
                                 项目 = info.项目,
                                 开票金额 = info.开票金额,
                                 收款金额 = info.收款金额,
                                 收票金额 = info.收票金额,
                                 付款金额 = info.付款金额,
                                 收款调整金额=info.收款调整金额,
                                 日期=info.日期

                             };
                
              dataGridView1.DataSource = result;
            }
            else
            {
                
                        var resultid = from info in linq.总包明细
                                       where info.项目.Contains(textBox1.Text)
                                       select new
                                       {
                                           项目 = info.项目,
                                           开票金额 = info.开票金额,
                                           收款金额 = info.收款金额,
                                           收票金额 = info.收票金额,
                                           付款金额 = info.付款金额,
                                           收款调整金额 = info.收款调整金额,
                                           日期 = info.日期
                                       };
                        dataGridView1.DataSource = resultid;
                        
              
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
}
