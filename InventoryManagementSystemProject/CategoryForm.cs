using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagementSystemProject
{
    public partial class CategoryForm : Form
    {
        static string connString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;

        public CategoryForm()
        {
            InitializeComponent();
            LoadCategory();
        }

        public void LoadCategory()
        {
            int i = 1;
            CategoryDgv.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM CategoryTable", conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CategoryDgv.Rows.Add(i, reader[0].ToString(), reader[1].ToString());
                i++;
            }
            reader.Close();
            conn.Close();
        }

        private void CustomerAddBtn_Click(object sender, System.EventArgs e)
        {
            CategoryModuleForm categoryForm = new CategoryModuleForm();
            categoryForm.SaveBtn.Enabled = true;
            categoryForm.UpdateBtn.Enabled = false;
            categoryForm.ShowDialog();
            LoadCategory();
        }

        private void CategoryDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = CategoryDgv.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                CategoryModuleForm categoryModule = new CategoryModuleForm();
                categoryModule.CatIdLbl.Text = CategoryDgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                categoryModule.CatNameTxt.Text = CategoryDgv.Rows[e.RowIndex].Cells[2].Value.ToString();

                categoryModule.SaveBtn.Enabled = false;
                categoryModule.UpdateBtn.Enabled = true;
                categoryModule.ShowDialog();

            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this category?", "Delete Category Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("DELETE FROM CategoryTable WHERE catid LIKE '" + CategoryDgv.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Category record has been deleted successfully.");
                }
            }
            LoadCategory();
        }
    }
}
