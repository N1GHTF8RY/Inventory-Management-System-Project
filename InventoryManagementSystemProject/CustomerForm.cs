using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagementSystemProject
{
    public partial class CustomerForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=SFT-ABHIJIT-N-P;Initial Catalog=InventoryManagementSystem;Persist Security Info=True;User ID=sa;Password=sa@123;Encrypt=False");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;

        public CustomerForm()
        {
            InitializeComponent();
            LoadCustomer();
        }

        public void LoadCustomer()
        {
            int i = 1;
            CustomersDgv.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM CustomerTable", conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CustomersDgv.Rows.Add(i, reader[0].ToString(), reader[1].ToString(), reader[2].ToString());
                i++;
            }
            reader.Close();
            conn.Close();
        }

        private void CustomerAddBtn_Click(object sender, System.EventArgs e)
        {
            CustomerModuleForm customerForm = new CustomerModuleForm();
            customerForm.SaveBtn.Enabled = true;
            customerForm.UpdateBtn.Enabled = false;
            customerForm.ShowDialog();
            LoadCustomer();
        }

        private void CustomersDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = CustomersDgv.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                CustomerModuleForm customerModule = new CustomerModuleForm();
                customerModule.CIdLbl.Text = CustomersDgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                customerModule.CNameTxt.Text = CustomersDgv.Rows[e.RowIndex].Cells[2].Value.ToString();
                customerModule.CPhoneTxt.Text = CustomersDgv.Rows[e.RowIndex].Cells[3].Value.ToString();

                customerModule.SaveBtn.Enabled = false;
                customerModule.UpdateBtn.Enabled = true;
                customerModule.ShowDialog();

            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this customer?", "Delete Customer Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("DELETE FROM CustomerTable WHERE cid LIKE '" + CustomersDgv.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Customer record has been deleted successfully.");
                }
            }
            LoadCustomer();
        }

    }
}
