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
    public partial class IndexForm : Form
    {
        public IndexForm(Login login)
        {
            InitializeComponent();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Products pl = new Products();
            pl.MdiParent = this;
            pl.Show();
        }
    }
}
