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
    public partial class ClassesUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClassesFill();
                ClassDropDownFill();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ClassMaster Class = new ClassMaster
            {
                ID = Convert.ToInt32(ddl_Class.SelectedValue),
                ClassName = className.Text,
                NumberOfStudents= Convert.ToInt32(numberOfStudents.Text),
                Section = section.Text
            };
            ClassMasterBuss.UpdateClass(Class);
            ClassesFill();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ClassMasterBuss.DeleteClass(ddl_Class.SelectedValue);
            ClassesFill();
        }
        private void ClassesFill()
        {
            ClassMasterBuss Obj_Class = new ClassMasterBuss();
            List<ClassMaster> Obj_Cls = Obj_Class.GetClasses();
            if (Obj_Cls != null && Obj_Cls.Count > 0)
            {
                grd.DataSource = Obj_Cls;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = null;
                grd.DataBind();
            }
        }
        private void ClassDropDownFill()
        {
            ClassMasterBuss Obj_Coo = new ClassMasterBuss();
            List<ClassMaster> Obj_Stds_ID = Obj_Coo.GetClasses();

            if (Obj_Stds_ID != null && Obj_Stds_ID.Count > 0)
            {
                for (int i = 0; i < Obj_Stds_ID.Count; i++)
                {
                    ddl_Class.Items.Add(Obj_Stds_ID[i].ID.ToString());
                }
                ddl_Class.Items.Insert(0, new ListItem("Select Class", " "));
            }
            else
            {
                ddl_Class.Items.Clear();
            }
        }
        protected void ddl_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ClassMaster> Obj_Class = ClassMasterBuss.GetClassDetails(ddl_Class.SelectedValue);
            if (Obj_Class != null && Obj_Class.Count > 0)
            {
                for (int i = 0; i < Obj_Class.Count; i++)
                {
                    className.Text = Obj_Class[i].ClassName;
                    numberOfStudents.Text = Convert.ToString(Obj_Class[i].NumberOfStudents);
                    section.Text = Obj_Class[i].Section;
                }
            }
        }
    }
}