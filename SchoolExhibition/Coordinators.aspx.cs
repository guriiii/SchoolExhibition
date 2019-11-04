using SchoolExhibition.Bussiness;
using SchoolExhibition.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolExhibition
{
    public partial class Coordinators : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CoordinatorFill();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ExhibitionCoordinatorMaster Obj_Add_Coor = new ExhibitionCoordinatorMaster
            {
                Name = name.Text,
            };
            ExhibitionMasterBuss.SaveCoordinators(Obj_Add_Coor);
            CoordinatorFill();
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("Coordinators.aspx");
        }
        private void CoordinatorFill()
        {
            ExhibitionMasterBuss Obj_Coor = new ExhibitionMasterBuss();
            List<ExhibitionCoordinatorMaster> Obj_Co = Obj_Coor.GetCoordinators();
            if (Obj_Co != null && Obj_Co.Count > 0)
            {
                grd.DataSource = Obj_Co;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = null;
                grd.DataBind();
            }
        }
    }
}