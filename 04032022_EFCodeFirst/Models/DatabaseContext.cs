using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _04032022_EFCodeFirst.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Kisiler> Kisiler { get; set; }
        public DbSet<Adresler> Adresler { get; set; }
        public DatabaseContext()
        {
            Database.SetInitializer(new VeriTabaniOlustur());
        }       

    }

    public class VeriTabaniOlustur:CreateDatabaseIfNotExists<DatabaseContext>
        {
        protected override void Seed(DatabaseContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                Kisiler k = new Kisiler();
                k.Ad = FakeData.NameData.GetFirstName();
                k.Soyad = FakeData.NameData.GetSurname();
                k.Yas = FakeData.NumberData.GetNumber(10, 80);
                context.Kisiler.Add(k);
            }

            context.SaveChanges();

            List<Kisiler> kisilistesi = context.Kisiler.ToList();

            foreach (var kisi in kisilistesi)
            {
                for (int i = 0; i < 3; i++)
                {  
                    Adresler a = new Adresler();
                    a.Kisi = kisi;                 
                    a.AdresTanim = FakeData.PlaceData.GetAddress();
                   
                   context.Adresler.Add(a);
                }
            }
            context.SaveChanges();
        

            context.SaveChanges();
        }




    }




}