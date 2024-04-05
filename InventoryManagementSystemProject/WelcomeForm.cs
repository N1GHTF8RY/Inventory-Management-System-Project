using System;
using System.Windows.Forms;

namespace InventoryManagementSystemProject
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
            timer1.Start();
        }

        int startPoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startPoint += 5;
            progressBar1.Value = startPoint;
            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
                timer1.Stop();
                RegisterForm register = new RegisterForm();
                this.Hide();
                register.ShowDialog();
            }

        }
    }
}
