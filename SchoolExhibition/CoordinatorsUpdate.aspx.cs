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
    public partial class CoordinatorsUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CoordinatorFill();
                CoordinatorDropDownFill();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ExhibitionCoordinatorMaster Coordinator = new ExhibitionCoordinatorMaster
            {
                ID = Convert.ToInt32(ddl_Coordinator.SelectedValue),
                Name = coordinator.Text,
                
            };
            ExhibitionMasterBuss.UpdateCoordinator(Coordinator);
            CoordinatorFill();
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
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ExhibitionMasterBuss.DeleteCoordinator(ddl_Coordinator.SelectedValue);
            CoordinatorFill();
        }
        private void CoordinatorDropDownFill()
        {
            ExhibitionMasterBuss Obj_Coo = new ExhibitionMasterBuss();
            List<ExhibitionCoordinatorMaster> Obj_Stds_ID = Obj_Coo.GetCoordinators();

            if (Obj_Stds_ID != null && Obj_Stds_ID.Count > 0)
            {
                for (int i = 0; i < Obj_Stds_ID.Count; i++)
                {
                    ddl_Coordinator.Items.Add(Obj_Stds_ID[i].ID.ToString());
                }
                ddl_Coordinator.Items.Insert(0, new ListItem("Select Coordinator", " "));
            }
            else
            {
                ddl_Coordinator.Items.Clear();
            }
        }
        protected void ddl_Coordinator_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ExhibitionCoordinatorMaster> Obj_Coordinator = ExhibitionMasterBuss.GetCoordinatorDetails(ddl_Coordinator.SelectedValue);
            if (Obj_Coordinator != null && Obj_Coordinator.Count > 0)
            {
                for (int i = 0; i < Obj_Coordinator.Count; i++)
                {
                    coordinator.Text = Obj_Coordinator[i].Name;
                }
            }
        }
    }
}