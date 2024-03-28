using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace InventoryManagementSystemProject
{
    public partial class LoginForm : Form
    {
        static string connString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        SqlConnection conn = new SqlConnection(connString);
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
                cmd = new SqlCommand("SELECT * FROM UserTable WHERE username=@username", conn);
                cmd.Parameters.AddWithValue("@username", textName.Text);
                conn.Open();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string storedHashedPassword = reader["password"].ToString();
                    string userInputPassword = textPass.Text;

                    string hashedInputPassword = HashPassword(userInputPassword);

                    if (ComparePasswords(hashedInputPassword, storedHashedPassword))
                    {
                        MessageBox.Show("Welcome " + reader["fullname"].ToString() + "! ", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MainForm main = new MainForm();
                        this.Hide();
                        main.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Invalid password!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

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

        public bool ComparePasswords(string hashedInputPassword, string storedHashedPassword)
        {
            return string.Equals(hashedInputPassword, storedHashedPassword, StringComparison.OrdinalIgnoreCase);
        }

    }
}
