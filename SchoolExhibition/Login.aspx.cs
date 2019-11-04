using SchoolExhibition.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolExhibition
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserVModel vmModel = new UserVModel();

            Response.Cookies["UserName"].Value = Email.Text.Trim();
            Response.Cookies["Password"].Value = Password.Text.Trim();
            vmModel.UserName = Email.Text.Trim();
            vmModel.Password = Password.Text.Trim();
            UserMasterBuss login_Business = new UserMasterBuss();
            bool msg = login_Business.LoginUser(vmModel);
            if (msg)
            {

                Response.Redirect("Classes.aspx");
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Login ID and Password is invalid.";
            }
        }
    }
}