using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new FilmContext())
            {
                // create and save new Studio
                Console.Write("Enter the name of a new studio: ");
                var name = Console.ReadLine();

                var studio1 = new Studio { SName = name };
                db.Studios.Add(studio1);
                db.SaveChanges();

                // display all Studios from db
                var query = from s in db.Studios
                            orderby s.SName
                            select s;
                Console.WriteLine("All Studios in the database: ");
                foreach (var item in query)
                {
                    Console.WriteLine(item.SName);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }

    public class Studio
    {
        public int StudioID { get; set; }
        public string SName { get; set; }

        public virtual List<Film> Films { get; set; }
    }

    public class Film           // classes for FilmInfo domain
    {
        public int FilmID { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Star1 { get; set; }
        public string Star2 { get; set; }
        public int Year { get; set; }
        public byte[] Promo { get; set; }

        public int StudioID { get; set; }
        public virtual Studio Studio { get; set; }
    }

    public class FilmContext : DbContext
    {
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Film> Films { get; set; }
    }
}
