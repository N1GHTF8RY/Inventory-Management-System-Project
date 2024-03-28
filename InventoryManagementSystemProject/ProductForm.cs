using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagementSystemProject
{
    public partial class ProductForm : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=SFT-ABHIJIT-N-P;Initial Catalog=InventoryManagementSystem;Persist Security Info=True;User ID=sa;Password=sa@123;Encrypt=False");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;

        public ProductForm()
        {
            InitializeComponent();
            LoadProduct();
        }

        public void LoadProduct()
        {
            int i = 1;
            ProductDgv.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM ProductTable WHERE CONCAT(pid, pname, pprice, pdescription, pcategory) LIKE '%" + SearchTxt.Text + "%'", conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ProductDgv.Rows.Add(i, reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3], reader[4].ToString(), reader[5].ToString());
                i++;
            }
            reader.Close();
            conn.Close();
        }

        private void ProductAddBtn_Click_1(object sender, EventArgs e)
        {
            ProductModuleForm productForm = new ProductModuleForm();
            productForm.SaveBtn.Enabled = true;
            productForm.UpdateBtn.Enabled = false;
            productForm.ShowDialog();
            LoadProduct();
        }

        private void ProductDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = ProductDgv.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                ProductModuleForm productModule = new ProductModuleForm();
                productModule.PIdLbl.Text = ProductDgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                productModule.ProdNameTxt.Text = ProductDgv.Rows[e.RowIndex].Cells[2].Value.ToString();
                productModule.ProdQtyTxt.Text = ProductDgv.Rows[e.RowIndex].Cells[3].Value.ToString();
                productModule.ProdPriceTxt.Text = ProductDgv.Rows[e.RowIndex].Cells[4].Value.ToString();
                productModule.ProdDescTxt.Text = ProductDgv.Rows[e.RowIndex].Cells[5].Value.ToString();
                productModule.CatCombo.Text = ProductDgv.Rows[e.RowIndex].Cells[6].Value.ToString();

                productModule.SaveBtn.Enabled = false;
                productModule.UpdateBtn.Enabled = true;
                productModule.ShowDialog();

            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this product?", "Delete Product Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("DELETE FROM ProductTable WHERE pid LIKE '" + ProductDgv.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Product record has been deleted successfully.");
                }
            }
            LoadProduct();
        }

        private void SearchTxt_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }
    }
}
