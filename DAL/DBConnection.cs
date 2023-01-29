using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBConnection
    {
        public  DBConnection() { }
        //שליפת רשימה גנרית
        public List<T> GetDbSet<T>() where T : class
        {
            using (MyShoppingEntities myShoppingEntity = new
                MyShoppingEntities())
            {
                return myShoppingEntity.GetDbSet<T>().ToList();
            }
        }
        public enum ExecuteActions
        {
            Insert,
            Update,
            Delete
        }
        //הוספה ,עדכון ומחיקה
        public void Execute<T>(T entity, ExecuteActions exAction) where T : class
        {
            using (MyShoppingEntities myShoppingEntity = new
               MyShoppingEntities())
            {
                var model = myShoppingEntity.Set<T>();
                switch (exAction)
                {

                    case ExecuteActions.Insert:
                        model.Add(entity);
                        break;

                    case ExecuteActions.Update:
                        model.Attach(entity);
                        myShoppingEntity.Entry(entity).State =
                            System.Data.Entity.EntityState.Modified;
                        break;

                    case ExecuteActions.Delete:
                        model.Attach(entity);
                        myShoppingEntity.Entry(entity).State =
                            System.Data.Entity.EntityState.Deleted;
                        break;

                    default:
                        break;
                }
                myShoppingEntity.SaveChanges();
            }
        }
    }
}
