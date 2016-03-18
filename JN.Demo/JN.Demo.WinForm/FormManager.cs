using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JN.Demo.WinForm
{
   public class FormManager
    {

        public static void Show(Form form)
        {
            Form1.ActiveForm.Hide();
            form.Show();
        }
        public static void Return()
        {
            Form1.ActiveForm.Hide();
            new Form1().Show();
        }


        public static void Excute(Action action)
        {
            action();
        }
    }
}
