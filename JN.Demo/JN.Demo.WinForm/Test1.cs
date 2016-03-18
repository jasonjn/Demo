using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JN.Demo.WinForm
{
    public partial class Test1 : Form
    {
        public Test1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormManager.Excute(() =>
            {
                ShowText();
                AsyncShow();
            });
        }

        public async void AsyncShow()
        {
            //Thread thread = new Thread(ShowText);
            //thread.Start();            

            await  Task.Run(()=>ShowText());
        }

        private void ShowText()
        {
            if (this.InvokeRequired)
            {
                Action action = () => { listBox1.Items.Add("这是分线程的添加"); };
                this.Invoke(action);
            }
            else
            {
                listBox1.Items.Add("这是主线程的添加");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormManager.Return();
        }
    }
}
