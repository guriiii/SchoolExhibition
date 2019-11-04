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
    public partial class Classes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClassesFill();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ClassMaster Obj_Add_Cls = new ClassMaster
            {
                ClassName = className.Text,
                NumberOfStudents = Convert.ToInt32(numberOfStudents.Text),
                Section = section.Text,
            };
            ClassMasterBuss.SaveClasses(Obj_Add_Cls);
            ClassesFill();
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("Classes.aspx");
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
    }
}