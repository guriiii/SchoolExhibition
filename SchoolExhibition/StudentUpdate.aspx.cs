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
    public partial class StudentUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ExhibitionFill();
                StudentFill();
                ClassFill();
                StudentDropDownFill();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            StudentMaster _Stu = new StudentMaster
            {
                ID = Convert.ToInt32(ddl_Student.SelectedValue),
                StudentName = studentName.Text,
                ExhibitionCoordinatorMasterID = Convert.ToInt32(ddl_Exhibition.SelectedValue),
                ClassMasterID = Convert.ToInt32(ddl_Class.SelectedValue)
            };
            StudentMasterBuss.UpdateStudent(_Stu);
            StudentFill();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            StudentMasterBuss.DeleteStudent(ddl_Student.SelectedValue);
            StudentFill();
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
        private void StudentDropDownFill()
        {
            StudentMasterBuss Obj_St = new StudentMasterBuss();
            List<StudentMaster> Obj_Stds_ID = Obj_St.GetStudents();

            if (Obj_Stds_ID != null && Obj_Stds_ID.Count > 0)
            {
                for (int i = 0; i < Obj_Stds_ID.Count; i++)
                {
                    ddl_Student.Items.Add(Obj_Stds_ID[i].ID.ToString());
                }
                ddl_Student.Items.Insert(0, new ListItem("Select Student", " "));
            }
            else
            {
                ddl_Student.Items.Clear();
            }
        }

        protected void ddl_Student_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<StudentMaster> Obj_St = StudentMasterBuss.GetStudentDetails(ddl_Student.SelectedValue);
            if (Obj_St != null && Obj_St.Count > 0)
            {
                for (int i = 0; i < Obj_St.Count; i++)
                {
                    studentName.Text = Obj_St[i].StudentName;
                    ddl_Class.SelectedValue = Convert.ToString(Obj_St[i].ClassMasterID);
                    ddl_Exhibition.SelectedValue = Convert.ToString(Obj_St[i].ExhibitionCoordinatorMasterID);
                }
            }
        }
    }
}