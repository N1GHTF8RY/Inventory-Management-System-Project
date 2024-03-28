using System.Windows.Forms;

namespace InventoryManagementSystemProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            OpenChildForm(new ProductForm());
        }

        //To show the subform in the main form
        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(childForm);
            MainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void UsersBtn_Click(object sender, System.EventArgs e)
        {
            OpenChildForm(new UserForm());
        }

        private void CustomerBtn_Click(object sender, System.EventArgs e)
        {
            OpenChildForm(new CustomerForm());
        }

        private void CategoryBtn_Click(object sender, System.EventArgs e)
        {
            OpenChildForm(new CategoryForm());
        }

        private void ProductBtn_Click(object sender, System.EventArgs e)
        {
            OpenChildForm(new ProductForm());
        }

        private void OrdersBtn_Click(object sender, System.EventArgs e)
        {
            OpenChildForm(new OrderForm());
        }
    }
}
