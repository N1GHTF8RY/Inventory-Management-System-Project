using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagementSystemProject
{
    public partial class CategoryModuleForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=SFT-ABHIJIT-N-P;Initial Catalog=InventoryManagementSystem;Persist Security Info=True;User ID=sa;Password=sa@123;Encrypt=False");
        SqlCommand cmd = new SqlCommand();

        public CategoryModuleForm()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this category?", "Saving Category Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("INSERT INTO CategoryTable(catname) VALUES(@catname)", conn);
                    cmd.Parameters.AddWithValue("@catname", CatNameTxt.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Category has been successfully saved.");
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
            CatNameTxt.Clear();
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
                if (MessageBox.Show("Are you sure you want to update this category record?", "Update Category Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("UPDATE CategoryTable SET catname = @catname WHERE catid LIKE '" + CatIdLbl.Text + "'", conn);
                    cmd.Parameters.AddWithValue("@catname", CatNameTxt.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Category has been successfully updated.");
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
