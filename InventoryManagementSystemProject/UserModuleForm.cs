using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace InventoryManagementSystemProject
{
    public partial class UserModuleForm : Form
    {
        static string connString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand();

        public UserModuleForm()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PasswordTxt.Text != ConfirmPassTxt.Text)
                {
                    MessageBox.Show("Passwords did not Match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Are you sure you want to save this user?", "Saving User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                    MessageBox.Show("User has been successfully saved.");
                    Clear();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
            SaveBtn.Enabled = true;
            UpdateBtn.Enabled = false;
        }

        public void Clear()
        {
            UserNameTxt.Clear();
            FullNameTxt.Clear();
            PasswordTxt.Clear();
            ConfirmPassTxt.Clear();
            PhoneTxt.Clear();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PasswordTxt.Text != ConfirmPassTxt.Text)
                {
                    MessageBox.Show("Passwords did not Match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Are you sure you want to update this user record?", "Update User Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("UPDATE UserTable SET fullname = @fullname,password = @password,phone = @phone WHERE username LIKE '" + UserNameTxt.Text + "'", conn);
                    cmd.Parameters.AddWithValue("@fullname", FullNameTxt.Text);
                    cmd.Parameters.AddWithValue("@password", PasswordTxt.Text);
                    cmd.Parameters.AddWithValue("@phone", PhoneTxt.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("User has been successfully updated.");
                    this.Dispose();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
