using SchoolExhibition.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolExhibition.Bussiness
{
    public class StudentMasterBuss
    {
        SchoolExhibitionEntities _db = new SchoolExhibitionEntities();
        public List<StudentMaster> GetStudents()//Students list method
        {
            try
            {
                List<StudentMaster> obj_Student = null;
                obj_Student = (from o in _db.StudentMasters select o).ToList();
                return obj_Student;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void SaveStudents(StudentMaster Obj_Student_Save)//save method.
        {
            try
            {
                using (SchoolExhibitionEntities db = new SchoolExhibitionEntities())
                {
                    db.StudentMasters.Add(Obj_Student_Save);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static List<StudentMaster> GetStudentDetails(string value)//get student detail method
        {
            try
            {
                List<StudentMaster> Obj_Student_Detail = null;
                using (SchoolExhibitionEntities db = new SchoolExhibitionEntities())
                {
                    Obj_Student_Detail = (from c in db.StudentMasters where c.ID.ToString() == value select c).ToList();
                }
                return Obj_Student_Detail
;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int UpdateStudent(StudentMaster Obj_Student_Update)//update method
        {
            try
            {
                using (SchoolExhibitionEntities db = new SchoolExhibitionEntities())
                {
                    //Lambda expression
                    StudentMaster c = db.StudentMasters.SingleOrDefault(x => x.ID == Obj_Student_Update.ID);
                    c.StudentName = Obj_Student_Update.StudentName;
                    c.ExhibitionCoordinatorMasterID = Obj_Student_Update.ExhibitionCoordinatorMasterID;
                    c.ClassMasterID = Obj_Student_Update.ClassMasterID;
                    db.SaveChanges();
                    return Obj_Student_Update.ID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DeleteStudent(string Obj_Student_Delete)//delete method
        {
            try
            {
                using (SchoolExhibitionEntities db = new SchoolExhibitionEntities())
                {
                    //Lambda expression
                    StudentMaster c = db.StudentMasters.SingleOrDefault(x => x.ID.ToString().Trim() == Obj_Student_Delete.Trim());
                    if (c != null)
                    {
                        db.StudentMasters.Remove(c);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}