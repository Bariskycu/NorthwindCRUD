using _BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _NorthwindCRUD
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }
        DatabaseBusiness db = new DatabaseBusiness();
        private void dgvProducts_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvProducts.Rows[e.RowIndex];

            txtId.Text = dr.Cells["ProductID"].Value.ToString();
            txtName.Text = dr.Cells["ProductName"].Value.ToString();
            txtQuantityPerUnit.Text = dr.Cells["QuantityPerUnit"].Value.ToString();
            txtReordersLevel.Text = dr.Cells["ReorderLevel"].Value.ToString();
            txtUnitPrice.Text = dr.Cells["UnitPrice"].Value.ToString();
            txtUnitsInStock.Text = dr.Cells["UnitsInStock"].Value.ToString();
            txtUnitsOnOrder.Text = dr.Cells["UnitsOnOrder"].Value.ToString();
            cbDiscontinued.Checked = Convert.ToBoolean(dr.Cells["Discontinued"].Value);
            cmbCategories.SelectedValue = dr.Cells["CategoryID"].Value;
            cmbSuppliers.SelectedValue = dr.Cells["SupplierID"].Value;
        }

        private void Products_Load(object sender, EventArgs e)
        {

            cmbCategories.SetFirstRow("SP_GetCategories", "CategoryName", "CategoryID");

            cmbSuppliers.SetFirstRow("SP_GetSuppliers", "CompanyName", "SupplierID");


            dgvProducts.DataSource = db.ExecuteAdapter("SP_GetProducts");
        }
    }
}
