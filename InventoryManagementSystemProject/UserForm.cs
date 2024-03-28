using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagementSystemProject
{
    public partial class UserForm : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=SFT-ABHIJIT-N-P;Initial Catalog=InventoryManagementSystem;Persist Security Info=True;User ID=sa;Password=sa@123;Encrypt=False");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;

        public UserForm()
        {
            InitializeComponent();
            LoadUser();
        }

        public void LoadUser()
        {
            int i = 1;
            UserDgv.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM UserTable", conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                UserDgv.Rows.Add(i, reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString());
                i++;
            }
            reader.Close();
            conn.Close();
        }

        private void AddBtn_Click(object sender, System.EventArgs e)
        {
            UserModuleForm userModule = new UserModuleForm();
            userModule.SaveBtn.Enabled = true;
            userModule.UpdateBtn.Enabled = false;
            userModule.ShowDialog();
            LoadUser();
        }

        private void UserDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = UserDgv.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                UserModuleForm userModule = new UserModuleForm();
                userModule.UserNameTxt.Text = UserDgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                userModule.FullNameTxt.Text = UserDgv.Rows[e.RowIndex].Cells[2].Value.ToString();
                userModule.PasswordTxt.Text = UserDgv.Rows[e.RowIndex].Cells[3].Value.ToString();
                userModule.PhoneTxt.Text = UserDgv.Rows[e.RowIndex].Cells[4].Value.ToString();

                userModule.SaveBtn.Enabled = false;
                userModule.UpdateBtn.Enabled = true;
                userModule.UserNameTxt.Enabled = false;
                userModule.ShowDialog();

            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this user?", "Delete User Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("DELETE FROM UserTable WHERE username LIKE '" + UserDgv.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("User record has been deleted successfully.");
                }
            }
            LoadUser();
        }

    }
}
