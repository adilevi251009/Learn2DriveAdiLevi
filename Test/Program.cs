using Model;
using ViewModel;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            CityDB cdb = new();
            CityList cList = cdb.SelectAll();
            foreach (City c in cList)
                Console.WriteLine(c.CityName);




            //City myCity = new City() { CityName = "ירושלים" };
            //cdb.Insert(myCity);
            //int x = cdb.SaveChanges();
            //Console.WriteLine($"{x} rows  inserted");

            #region

            //PersonDB pdb = new();
            //PersonList pList = pdb.SelectAll();
            //foreach (Person c in pList)
            //    Console.WriteLine(c.FirstName);
            #endregion

            #region

            //StudentDB sdb = new();
            //StudentList sList = sdb.SelectAll();
            //foreach (Student c in sList)
            //    Console.WriteLine(c.FirstName + " " + c.Tel);
            //sdb.Insert(new Student() { FirstName = "דודו", LastName = "מלכי", Tel = "052-1234567", LivingCity = cList[0] });
            //sdb.Insert(new Student() { FirstName = "חנה", LastName = "אלול", Tel = "052-7654321", LivingCity = cList[1] });
            //int y = sdb.SaveChanges();
            //sdb = new();
            //Console.BackgroundColor = ConsoleColor.DarkBlue;
            //sList = sdb.SelectAll();
            //foreach (Student c in sList)
            //    Console.WriteLine(c.FirstName + " " + c.Tel);
            //Student s1 = sList.Last();
            //s1.Tel = "054-1111111";
            //sdb.Update(s1);
            //y = sdb.SaveChanges();

            //Student s2 = sList[0];
            //sdb.Delete(s2);
            //y = sdb.SaveChanges();
            //Console.WriteLine(y);
            #endregion
        }
    }
}
