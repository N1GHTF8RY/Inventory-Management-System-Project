using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagementSystemProject
{
    public partial class OrderForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=SFT-ABHIJIT-N-P;Initial Catalog=InventoryManagementSystem;Persist Security Info=True;User ID=sa;Password=sa@123;Encrypt=False");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;

        public OrderForm()
        {
            InitializeComponent();
            LoadOrder();
        }


        public void LoadOrder()
        {
            int i = 0;
            double total = 0;
            OrderDgv.Rows.Clear();
            cmd = new SqlCommand("SELECT orderid, odate, O.pid, P.pname, O.cid, C.cname, qty, price, total FROM OrderTable AS O JOIN CustomerTable AS C ON O.cid = C.cid JOIN ProductTable AS P ON O.pid = P.pid WHERE CONCAT (orderid, odate, O.pid, P.pname, O.cid, C.cname, qty, price) LIKE '%" + SearchTxt.Text + "%'", conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                i++;
                OrderDgv.Rows.Add(i, reader[0].ToString(), Convert.ToDateTime(reader[1].ToString()).ToString("dd/MM/yyyy"), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString());
                total += Convert.ToDouble(reader[8].ToString());
            }
            reader.Close();
            conn.Close();

            QtyLbl.Text = i.ToString();
            TotalAmtLbl.Text = total.ToString();

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            OrderModuleForm orderForm = new OrderModuleForm();
            orderForm.ShowDialog();
            LoadOrder();
        }

        private void OrderDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = OrderDgv.Columns[e.ColumnIndex].Name;

            if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this order?", "Delete Order Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("DELETE FROM OrderTable WHERE orderid LIKE '" + OrderDgv.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Order record has been deleted successfully.");

                    cmd = new SqlCommand("UPDATE ProductTable SET pqty = (pqty+@pqty) WHERE pid LIKE '" + OrderDgv.Rows[e.RowIndex].Cells[3].Value.ToString() + "'", conn);
                    cmd.Parameters.AddWithValue("@pqty", Convert.ToInt32(OrderDgv.Rows[e.RowIndex].Cells[5].Value.ToString()));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            LoadOrder();
        }

        private void SearchTxt_TextChanged(object sender, EventArgs e)
        {
            LoadOrder();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
