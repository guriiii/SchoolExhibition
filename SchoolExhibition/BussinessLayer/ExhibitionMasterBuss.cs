using SchoolExhibition.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolExhibition.Bussiness
{
    public class ExhibitionMasterBuss
    {
        SchoolExhibitionEntities _db = new SchoolExhibitionEntities();
        public List<ExhibitionCoordinatorMaster> GetCoordinators()//Get coordinator master method
        {
            try
            {
                List<ExhibitionCoordinatorMaster> obj_Coordinator = null;
                obj_Coordinator = (from e in _db.ExhibitionCoordinatorMasters select e).ToList();
                return obj_Coordinator;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void SaveCoordinators(ExhibitionCoordinatorMaster Obj_Coordinator_Save)//save coordinator method.
        {
            try
            {
                using (SchoolExhibitionEntities db = new SchoolExhibitionEntities())
                {
                    db.ExhibitionCoordinatorMasters.Add(Obj_Coordinator_Save);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static List<ExhibitionCoordinatorMaster> GetCoordinatorDetails(string value)
        {
            try
            {
                List<ExhibitionCoordinatorMaster> Obj_Coordinator_Detail = null;
                using (SchoolExhibitionEntities db = new SchoolExhibitionEntities())
                {
                    Obj_Coordinator_Detail = (from c in db.ExhibitionCoordinatorMasters where c.ID.ToString() == value select c).ToList();
                }
                return Obj_Coordinator_Detail
;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int UpdateCoordinator(ExhibitionCoordinatorMaster Obj_Coordinator_Update)//update method
        {
            try
            {
                using (SchoolExhibitionEntities db = new SchoolExhibitionEntities())
                {
                    ExhibitionCoordinatorMaster c = db.ExhibitionCoordinatorMasters.SingleOrDefault(x => x.ID == Obj_Coordinator_Update.ID);//Lambda expression
                    c.Name = Obj_Coordinator_Update.Name;
                    db.SaveChanges();
                    return Obj_Coordinator_Update.ID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DeleteCoordinator(string Obj_Coordinator_Delete)//Delete method
        {
            try
            {
                using (SchoolExhibitionEntities db = new SchoolExhibitionEntities())
                {
                    ExhibitionCoordinatorMaster c = db.ExhibitionCoordinatorMasters.SingleOrDefault(x => x.ID.ToString().Trim() == Obj_Coordinator_Delete.Trim());//Lambda expression
                    if (c != null)
                    {
                        db.ExhibitionCoordinatorMasters.Remove(c);
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
