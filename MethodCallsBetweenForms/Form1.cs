using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MethodCallsBetweenForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InstanceForm2_Click(object sender, EventArgs e)
        {
            la.Add(a1f1);
            la.Add(a2f1);
            f2 = new Form2(la);
            f2.Show();
        }
        List<Action<string >> la = new List<Action<string >>();
        Form2 f2;
        private void a1f1(string s)
        {
            textBox1.Text = System.DateTime.Now.ToString() + ":调用了Form1的a1,"+s;
        }
        private void a2f1(string s)
        {
            textBox2.Text = System.DateTime.Now.ToString() + ":调用了Form1的a2," + s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Action[] la = f2.ll.ToArray();
            for (int i = 0; i < la.Length; i++)
            {
                la[i].Invoke();
                //Thread.Sleep(1000);
            }
        }
    }
}
