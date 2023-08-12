using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _BusinessLayer;


namespace _NorthwindCRUD
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        DatabaseBusiness _dbBusiness = new DatabaseBusiness();

        public string UserInfo
        {
            get { return txtUserName.Text; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                validationMessage.SetError(txtUserName, "Kullanıcı adı gerekli!");
                validationMessage.SetError(txtPassword, "Şifre gerekli!");
            }
            else
            {
                SqlParameter[] _parameters = new SqlParameter[]
                {
                    new SqlParameter("@UName",txtUserName.Text),
                    new SqlParameter("@Pass",txtPassword.Text)
                };

                LoginState state;

                DataTable dt = _dbBusiness.ExecuteAdapter("SP_GetUser", CommandType.StoredProcedure, _parameters, out state);

                switch (state)
                {
                    case LoginState.UserExistsPasswordWrong:
                        MessageBox.Show("Kullanıcı adına ait şifre doğrulanamadı!", "Kullanıcı Girişi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case LoginState.UserNotExists:
                        MessageBox.Show("Kullanıcı adını ve şifreyi kontrol ediniz!", "Kullanıcı Girişi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case LoginState.UserExists:


                        IndexForm _indexForm = new IndexForm(this);
                        _indexForm.Show();
                        break;
                }
            }

        }
    }
}
