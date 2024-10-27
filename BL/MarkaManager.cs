using DAL;
using Entities;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace BL
{
    public class MarkaManager
    {
        DatabaseContext db = new DatabaseContext();

        public List<Marka> GetAll() //tüm listeyi döndürecek
        {
            return db.Markalar.ToList();
        }
        public Marka Get(int id) //bu işlem sadece 1 adet marka nesnesi döndürecek
        {
            return db.Markalar.Find(id);        
        }
        /// <summary>
        /// Marka ekleme metodu
        /// </summary>
        /// <param name="marka"></param>
        /// <returns></returns>
        public int Add(Marka marka)
        {
            db.Markalar.Add(marka);
            return db.SaveChanges();
        }
        /// <summary>
        /// Marka Güncelleme
        /// </summary>
        /// <param name="marka"></param>
        /// <returns></returns>
        public int Update(Marka marka)
        {
            db.Markalar.AddOrUpdate(marka);
            return db.SaveChanges();
        }
        /// <summary>
        /// Marka Silme Metodu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id) 
        {
            db.Markalar.Remove(Get(id));
            return db.SaveChanges();  
        }
    }
}
