using SchoolExhibition.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolExhibition.Bussiness
{
    public class ClassMasterBuss
    {
        SchoolExhibitionEntities _db = new SchoolExhibitionEntities();
        public List<ClassMaster> GetClasses()//Get classes method
        {
            try
            {
                List<ClassMaster> obj_Class = null;
                obj_Class = (from o in _db.ClassMasters select o).ToList();
                return obj_Class;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void SaveClasses(ClassMaster Class_Save)//save class method.
        {
            try
            {
                using (SchoolExhibitionEntities db = new SchoolExhibitionEntities())
                {
                    db.ClassMasters.Add(Class_Save);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static List<ClassMaster> GetClassDetails(string value)//get class detail method code
        {
            try
            {
                List<ClassMaster> Obj_Class_Detail = null;
                using (SchoolExhibitionEntities db = new SchoolExhibitionEntities())
                {
                    Obj_Class_Detail = (from c in db.ClassMasters where c.ID.ToString() == value select c).ToList();
                }
                return Obj_Class_Detail
;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int UpdateClass(ClassMaster Obj_Class_Update)//updte class method
        {
            try
            {
                using (SchoolExhibitionEntities db = new SchoolExhibitionEntities())
                {
                    ClassMaster c = db.ClassMasters.SingleOrDefault(x => x.ID == Obj_Class_Update.ID);//Lambda expression
                    c.ClassName = Obj_Class_Update.ClassName;
                    c.NumberOfStudents = Obj_Class_Update.NumberOfStudents;
                    c.Section = Obj_Class_Update.Section;
                    db.SaveChanges();
                    return Obj_Class_Update.ID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DeleteClass(string Obj_Class_Delete)//delete class method
        {
            try
            {
                using (SchoolExhibitionEntities db = new SchoolExhibitionEntities())
                {
                    ClassMaster c = db.ClassMasters.SingleOrDefault(x => x.ID.ToString().Trim() == Obj_Class_Delete.Trim());//Lambda expression
                    if (c != null)
                    {
                        db.ClassMasters.Remove(c);
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