using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagementSystemProject
{
    public partial class CustomerModuleForm : Form
    {
        static string connString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand();

        public CustomerModuleForm()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this customer?", "Saving Customer Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("INSERT INTO CustomerTable(cname,cphone) VALUES(@cname,@cphone)", conn);
                    cmd.Parameters.AddWithValue("@cname", CNameTxt.Text);
                    cmd.Parameters.AddWithValue("@cphone", CPhoneTxt.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Customer has been successfully saved.");
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
            CNameTxt.Clear();
            CPhoneTxt.Clear();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
            SaveBtn.Enabled = true;
            UpdateBtn.Enabled = false;
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this customer record?", "Update Customer Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("UPDATE CustomerTable SET cname = @cname,cphone = @cphone WHERE cid LIKE '" + CIdLbl.Text + "'", conn);
                    cmd.Parameters.AddWithValue("@cname", CNameTxt.Text);
                    cmd.Parameters.AddWithValue("@cphone", CPhoneTxt.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Customer has been successfully updated.");
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
