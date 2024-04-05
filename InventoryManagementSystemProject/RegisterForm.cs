using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace InventoryManagementSystemProject
{
    public partial class RegisterForm : Form
    {
        static string connString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand();

        public RegisterForm()
        {
            InitializeComponent();
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert the byte array to hexadecimal string
                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    strBuilder.Append(hashedBytes[i].ToString("x2"));
                }

                return strBuilder.ToString();
            }
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PasswordTxt.Text != ConfirmPassTxt.Text)
                {
                    MessageBox.Show("Passwords did not Match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Are you sure you want to register this user?", "Register User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string hashedPassword = HashPassword(PasswordTxt.Text);

                    cmd = new SqlCommand("INSERT INTO UserTable(username,fullname,password,phone) VALUES(@username,@fullname,@password,@phone)", conn);
                    cmd.Parameters.AddWithValue("@username", UserNameTxt.Text);
                    cmd.Parameters.AddWithValue("@fullname", FullNameTxt.Text);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);
                    cmd.Parameters.AddWithValue("@phone", PhoneTxt.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("User has been successfully registered.");
                    Clear();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void Clear()
        {
            UserNameTxt.Clear();
            FullNameTxt.Clear();
            PasswordTxt.Clear();
            ConfirmPassTxt.Clear();
            PhoneTxt.Clear();
        }

        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPass.Checked)
            {
                PasswordTxt.UseSystemPasswordChar = false;
            }
            else
            {
                PasswordTxt.UseSystemPasswordChar = true;
            }
        }

        private void ClearLabel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void LoginLbl_MouseHover(object sender, EventArgs e)
        {
            LoginLbl.ForeColor = Color.Blue;
        }

        private void LoginLbl_MouseLeave(object sender, EventArgs e)
        {
            LoginLbl.ForeColor = Color.Black;
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            bool exit = MessageBox.Show("Are you sure you want to Exit? ", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            if (exit)
            {
                Application.Exit();
            }
        }

        private void LoginLbl_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm logForm = new LoginForm();
            logForm.ShowDialog();
        }
    }
}
