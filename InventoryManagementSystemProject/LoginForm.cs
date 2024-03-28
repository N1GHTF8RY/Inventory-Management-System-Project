using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagementSystemProject
{
    public partial class LoginForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=SFT-ABHIJIT-N-P;Initial Catalog=InventoryManagementSystem;Persist Security Info=True;User ID=sa;Password=sa@123;Encrypt=False");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPass.Checked)
            {
                textPass.UseSystemPasswordChar = false;
            }
            else
            {
                textPass.UseSystemPasswordChar = true;
            }
        }

        private void ClearLabel_Click(object sender, EventArgs e)
        {
            textName.Clear();
            textPass.Clear();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            bool exit = MessageBox.Show("Are you sure you want to Exit? ", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            if (exit)
            {
                Application.Exit();
            }
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("SELECT * FROM UserTable WHERE username=@username AND password=@password", conn);
                cmd.Parameters.AddWithValue("@username", textName.Text);
                cmd.Parameters.AddWithValue("@password", textPass.Text);
                conn.Open();
                reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    MessageBox.Show("Welcome " + reader["fullname"].ToString() + " | ", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm main = new MainForm();
                    this.Hide();
                    main.ShowDialog();
                    //this.Dispose();
                }
                else
                {
                    MessageBox.Show("Invalid username or password!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                reader.Close();
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
