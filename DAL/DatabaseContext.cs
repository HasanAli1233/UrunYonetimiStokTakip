using Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
       
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
            Database.SetInitializer(new DatabaseInitilializer());
        }
        public virtual DbSet<Kategori> Kategoriler { get; set; } //veritabanı tablolarımızı temsil eden yapılar
        public virtual DbSet<Kullanici> Kullanicilar { get; set; }
        public virtual DbSet<Marka> Markalar { get; set; }
        public virtual DbSet<Urun> Urunler { get; set; }
        public virtual DbSet<Musteri> Musteriler { get; set; }
        public virtual DbSet<Siparis> Siparisler { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//veritabanında oluşacak tabloların sonuna s takısı gelmemesi için 
            base.OnModelCreating(modelBuilder);
        }
        /*Migration : Veritabanı güncelleme 
         * Kullanım:
         * Package Manager Console aç > enable-migrations  (bunu bir kere kullanıyoruz
         * yapacağımız değişiklik için > update-database 
         * Yapacağımız işlemin kaydını tutmak için add-migration MigratioAdı sonrasında tekrar update-database
        */
        public class DatabaseInitilializer : CreateDatabaseIfNotExists<DatabaseContext>//1 kere çalıştırılır.Database yoksa oluşturur. Fakat proje içerisinde örneğin model tarafında bir değişiklik olursa hata verir.
        //CreateDatabaseIfNotExists eğer database yoksa oluştur DatabaseContext içerisindeki dbset lere göre 
        //****************DropCreateDatabaseIfModelChanges<DatabaseContext>
        //Modelde bir değişiklik olursa veritabanını sıfırlar yeniden oluştur,Bu metot test aşamasındayken kullanılabilir fakat canlı sistemlerde kullanmak mantıklı değildir.
        {
            protected override void Seed(DatabaseContext context)//seed metodu veritabnı oluşturduktan sonra devreye girip işlem yapmamızı sağlar
            {
                if (!context.Kullanicilar.Any())
                {
                    context.Kullanicilar.Add(new Kullanici
                    {
                        Aktif = true,
                        KullaniciAdi = "Admin",
                        Sifre = "12345",
                    });
                    context.SaveChanges();
                }
                base.Seed(context);
            }
        }
    }
}