using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagementSystemProject
{
    public partial class UserModuleForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=SFT-ABHIJIT-N-P;Initial Catalog=InventoryManagementSystem;Persist Security Info=True;User ID=sa;Password=sa@123;Encrypt=False");
        SqlCommand cmd = new SqlCommand();

        public UserModuleForm()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
                    cmd = new SqlCommand("INSERT INTO UserTable(username,fullname,password,phone) VALUES(@username,@fullname,@password,@phone)", conn);
                    cmd.Parameters.AddWithValue("@username", UserNameTxt.Text);
                    cmd.Parameters.AddWithValue("@fullname", FullNameTxt.Text);
                    cmd.Parameters.AddWithValue("@password", PasswordTxt.Text);
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
