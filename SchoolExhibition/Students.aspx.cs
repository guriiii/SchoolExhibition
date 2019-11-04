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
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ExhibitionFill();
                StudentFill();
                ClassFill();
            }
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            StudentMaster Obj_Add_Stu = new StudentMaster
            {
                StudentName = studentName.Text,
                ClassMasterID = Convert.ToInt32(ddl_Class.SelectedValue),
                ExhibitionCoordinatorMasterID = Convert.ToInt32(ddl_Exhibition.SelectedValue)
            };
            StudentMasterBuss.SaveStudents(Obj_Add_Stu);
            StudentFill();
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("Students.aspx");
        }
        private void StudentFill()
        {
            StudentMasterBuss Obj_Stu = new StudentMasterBuss();
            List<StudentMaster> Obj_St = Obj_Stu.GetStudents();
            if (Obj_St != null && Obj_St.Count > 0)
            {
                grd.DataSource = Obj_St;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = null;
                grd.DataBind();
            }
        }
        private void ExhibitionFill()
        {
            ExhibitionMasterBuss Obj_Coor = new ExhibitionMasterBuss();
            List<ExhibitionCoordinatorMaster> Obj_Coordinator_ID = Obj_Coor.GetCoordinators();

            if (Obj_Coordinator_ID != null && Obj_Coordinator_ID.Count > 0)
            {
                for (int i = 0; i < Obj_Coordinator_ID.Count; i++)
                {
                    ddl_Exhibition.Items.Add(Obj_Coordinator_ID[i].ID.ToString());
                }
                ddl_Exhibition.Items.Insert(0, new ListItem("Select Coordinator", " "));
            }
            else
            {
                ddl_Exhibition.Items.Clear();
            }
        }
        private void ClassFill()
        {
            ClassMasterBuss Obj_Cls = new ClassMasterBuss();
            List<ClassMaster> Obj_Class_ID = Obj_Cls.GetClasses();

            if (Obj_Class_ID != null && Obj_Class_ID.Count > 0)
            {
                for (int i = 0; i < Obj_Class_ID.Count; i++)
                {
                    ddl_Class.Items.Add(Obj_Class_ID[i].ID.ToString());
                }
                ddl_Class.Items.Insert(0, new ListItem("Select Class", " "));
            }
            else
            {
                ddl_Class.Items.Clear();
            }
        }
    }
}