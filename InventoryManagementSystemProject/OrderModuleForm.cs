using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagementSystemProject
{
    public partial class OrderModuleForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=SFT-ABHIJIT-N-P;Initial Catalog=InventoryManagementSystem;Persist Security Info=True;User ID=sa;Password=sa@123;Encrypt=False");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        int qty = 0;

        public OrderModuleForm()
        {
            InitializeComponent();
            LoadCustomer();
            LoadProduct();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadCustomer()
        {
            int i = 1;
            CustomersDgv.Rows.Clear();
            cmd = new SqlCommand("SELECT cid,cname FROM CustomerTable WHERE CONCAT(cid, cname) LIKE '%" + SearchCustTxt.Text + "%'", conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CustomersDgv.Rows.Add(i, reader[0].ToString(), reader[1].ToString());
                i++;
            }
            reader.Close();
            conn.Close();
        }

        public void LoadProduct()
        {
            int i = 1;
            ProductDgv.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM ProductTable WHERE CONCAT(pid, pname, pprice, pdescription, pcategory) LIKE '%" + SearchProdTxt.Text + "%'", conn);
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

        private void SearchCustTxt_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void SearchProdTxt_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            GetQty();
            if (Convert.ToDecimal(QtyNumericUpDown.Value) > qty)
            {
                MessageBox.Show("Instock quantity is not enough!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                QtyNumericUpDown.Value -= 1;
                return;
            }

            if (Convert.ToDecimal(QtyNumericUpDown.Value) > 0)
            {
                decimal total = Convert.ToDecimal(PriceTxt.Text) * Convert.ToDecimal(QtyNumericUpDown.Value);
                TotalTxt.Text = total.ToString();

            }


        }

        private void CustomersDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CustIdTxt.Text = CustomersDgv.Rows[e.RowIndex].Cells[1].Value.ToString();
            CustNameTxt.Text = CustomersDgv.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void ProductDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ProdIdTxt.Text = ProductDgv.Rows[e.RowIndex].Cells[1].Value.ToString();
            ProdNameTxt.Text = ProductDgv.Rows[e.RowIndex].Cells[2].Value.ToString();
            PriceTxt.Text = ProductDgv.Rows[e.RowIndex].Cells[4].Value.ToString();
            //qty = Convert.ToInt32(ProductDgv.Rows[e.RowIndex].Cells[3].Value.ToString());
        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CustIdTxt.Text == "")
                {
                    MessageBox.Show("Please select a customer!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (ProdIdTxt.Text == "")
                {
                    MessageBox.Show("Please select a product!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to insert this order?", "Saving Order Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("INSERT INTO OrderTable(odate,pid,cid,qty,price,total) VALUES(@odate,@pid,@cid,@qty,@price,@total)", conn);
                    cmd.Parameters.AddWithValue("@odate", OrderDate.Value);
                    cmd.Parameters.AddWithValue("@pid", Convert.ToInt32(ProdIdTxt.Text));
                    cmd.Parameters.AddWithValue("@cid", Convert.ToInt32(CustIdTxt.Text));
                    cmd.Parameters.AddWithValue("@qty", Convert.ToInt32(QtyNumericUpDown.Value));
                    cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(PriceTxt.Text));
                    cmd.Parameters.AddWithValue("@total", Convert.ToDecimal(TotalTxt.Text));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Customer has been successfully saved.");


                    cmd = new SqlCommand("UPDATE ProductTable SET pqty = (pqty-@pqty) WHERE pid LIKE '" + ProdIdTxt.Text + "'", conn);
                    cmd.Parameters.AddWithValue("@pqty", Convert.ToInt32(QtyNumericUpDown.Text));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Clear();
                    LoadProduct();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        public void Clear()
        {
            CustIdTxt.Clear();
            CustNameTxt.Clear();

            ProdIdTxt.Clear();
            ProdNameTxt.Clear();

            PriceTxt.Clear();
            QtyNumericUpDown.Value = 0;
            TotalTxt.Clear();
            OrderDate.Value = DateTime.Now;
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void GetQty()
        {
            cmd = new SqlCommand("SELECT pqty FROM ProductTable WHERE pid ='" + ProdIdTxt.Text + "'", conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                qty = Convert.ToInt32(reader[0].ToString());
            }
            reader.Close();
            conn.Close();
        }
    }
}
