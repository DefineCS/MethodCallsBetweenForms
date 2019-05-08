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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(List<Action<string>> a) //public List<Action>  Form2m(params Action[] a)
        {
            ll.Add(a1);
            ll.Add(a2);
            lmF1 = a;
            InitializeComponent();

        }
        //定义公共属性，以便Form1中实例化对象调用
        public List<Action> ll { get; }
        = new List<Action>();
        //List<Action> lm = new List<Action>();
        //public List<Action> ll { get { return lm; } } //定义公共属性，以便Form1中实例化对象调用
        List<Action<string>> lmF1 = new List<Action<string>>();//接收Form1实例化Form2时传过来的参数（Form1中的方法的集合）

        private void a1()
        {
            textBox1.Text = System.DateTime.Now.ToString() + ":调用了Form2的a1";
        }
        private void a2()
        {
            textBox2.Text = System.DateTime.Now.ToString() + ":调用了Form2的a2";
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Action<string>[] a = lmF1.ToArray();
            for (int i = 0; i < a.Length; i++)
            {
                a[i].Invoke("Form2传递参数并调用Form1的方法！");
                //Thread.Sleep(1000);
            }
        }

    }
}
