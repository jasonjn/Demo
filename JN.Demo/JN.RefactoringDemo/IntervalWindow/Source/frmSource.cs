using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JN.RefactoringDemo.IntervalWindow.Source
{
    public partial class frmSource : Form
    {
        public frmSource()
        {
            InitializeComponent();

            textBox1.LostFocus += TextBox1_LostFocus;
            textBox2.LostFocus += TextBox2_LostFocus;
            this.Click += FrmSource_Click;
        }

        private void FrmSource_Click(object sender, EventArgs e)
        {
            Computer();
        }

        private void TextBox2_LostFocus(object sender, EventArgs e)
        {
            Computer();
        }

        private void TextBox1_LostFocus(object sender, EventArgs e)
        {
            Computer();
        }

        private void Computer()
        {

            try
            {
                int text1 = int.Parse(textBox1.Text);
                int text2 = int.Parse(textBox2.Text);
                textBox3.Text = (text1 + text2).ToString(); ;
            }
            catch
            {
                return;
            } 

          
        }
    }
}
