using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagementSystemProject
{
    public partial class ProductModuleForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=SFT-ABHIJIT-N-P;Initial Catalog=InventoryManagementSystem;Persist Security Info=True;User ID=sa;Password=sa@123;Encrypt=False");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;

        public ProductModuleForm()
        {
            InitializeComponent();
            LoadCategory();
        }

        public void LoadCategory()
        {
            CatCombo.Items.Clear();
            cmd = new SqlCommand("SELECT catname FROM CategoryTable", conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CatCombo.Items.Add(reader[0].ToString());
            }
            reader.Close();
            conn.Close();
        }

        private void CloseBtn_Click(object sender, System.EventArgs e)
        {
            this.Dispose();
        }

        private void SaveBtn_Click(object sender, System.EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Are you sure you want to save this product?", "Saving Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("INSERT INTO ProductTable(pname,pqty,pprice,pdescription,pcategory) VALUES(@pname,@pqty,@pprice,@pdescription,@pcategory)", conn);
                    cmd.Parameters.AddWithValue("@pname", ProdNameTxt.Text);
                    cmd.Parameters.AddWithValue("@pqty", Convert.ToInt32(ProdQtyTxt.Text));
                    cmd.Parameters.AddWithValue("@pprice", Convert.ToDecimal(ProdPriceTxt.Text));
                    cmd.Parameters.AddWithValue("@pdescription", ProdDescTxt.Text);
                    cmd.Parameters.AddWithValue("@pcategory", CatCombo.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Product has been successfully saved.");
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
            ProdNameTxt.Clear();
            ProdQtyTxt.Clear();
            ProdPriceTxt.Clear();
            ProdDescTxt.Clear();
            CatCombo.Text = string.Empty;
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
            SaveBtn.Enabled = true;
            UpdateBtn.Enabled = false;
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this product record?", "Update Product Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("UPDATE ProductTable SET pname = @pname,pqty = @pqty,pprice = @pprice,pdescription = @pdescription,pcategory = @pcategory WHERE pid LIKE '" + PIdLbl.Text + "'", conn);
                    cmd.Parameters.AddWithValue("@pname", ProdNameTxt.Text);
                    cmd.Parameters.AddWithValue("@pqty", Convert.ToInt32(ProdQtyTxt.Text));
                    cmd.Parameters.AddWithValue("@pprice", Convert.ToDecimal(ProdPriceTxt.Text));
                    cmd.Parameters.AddWithValue("@pdescription", ProdDescTxt.Text);
                    cmd.Parameters.AddWithValue("@pcategory", CatCombo.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Product has been successfully updated.");
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
