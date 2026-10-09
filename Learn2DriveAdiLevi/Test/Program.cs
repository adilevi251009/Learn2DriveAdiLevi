using Model;
using ViewModel;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            ////טבלאות פשוטות
            ////========== City =========
            //CityDB cdb = new();
            //CityList cList = cdb.SelectAll();
            //foreach (City c in cList)
            //    Console.WriteLine(c.CityName);
            ////-----הדפסת עיר לפי Id-----
            //City city = CityDB.SelectById(1);
            //if (city != null)
            //{
            //    Console.WriteLine(city.CityName);
            //}
            //else
            //{
            //    Console.WriteLine("City not found");
            //}

            ////============ CarTypeDB ===============
            //CarTypeDB ctdb = new();
            //CarTypeList cList = ctdb.SelectAll();
            //foreach (CarType c in cList)
            //    Console.WriteLine(c.CarTypeName);
            ////------הדפסת סוג רכב לפי Id-----
            //CarType carType = CarTypeDB.SelectById(1);
            //if (carType != null)
            //{
            //    Console.WriteLine(carType.CarTypeName);
            //}
            //else
            //{
            //    Console.WriteLine("Car type not found");
            //}

            ////======== LessonStatusDB ========
            //LessonStatusDB lsdb = new();
            //LessonStatusList lsList = lsdb.SelectAll();
            //foreach (LessonStatus ls in lsList)
            //    Console.WriteLine(ls.LessonStatusName);
            ////-----הדפסת סטטוס שיעור לפי Id-----
            //LessonStatus lessonStatus = LessonStatusDB.SelectById(1);
            //if (lessonStatus != null)
            //{
            //    Console.WriteLine(lessonStatus.LessonStatusName);
            //}
            //else
            //{
            //    Console.WriteLine("Lesson status not found");
            //}

            ////=========== TopicsDB =========
            //TopicsDB topicsDB = new();
            //TopicsList topicsList = topicsDB.SelectAll();
            //foreach (Topics topic in topicsList)
            //    Console.WriteLine(topic.TopicName);
            ////-----הדפסת נושא לפי Id------
            //Topics topicById = TopicsDB.SelectById(1);
            //if (topicById != null)
            //{
            //    Console.WriteLine(topicById.TopicName);
            //}
            //else
            //{
            //    Console.WriteLine("Topic not found");
            //}

            ////============ ChecklistDB ============
            //ChecklistDB checklistDB = new();
            //ChecklistList checklistList = checklistDB.SelectAll();
            //foreach (Checklist checklist in checklistList)
            //    Console.WriteLine(checklist.IsDone);
            ////-----הדפסת Checklist לפי Id-----
            //Checklist checklistById = ChecklistDB.SelectById(1);
            //if (checklistById != null)
            //{
            //    Console.WriteLine(checklistById.IsDone);
            //}
            //else
            //{
            //    Console.WriteLine("Checklist not found");
            //}

            ////======== PaymentMethodsDB =========
            //PaymentMethodsDB paymentMethodsDB = new();
            //PaymentMethodsList paymentMethodsList = paymentMethodsDB.SelectAll();
            //foreach (PaymentMethods paymentMethod in paymentMethodsList)
            //    Console.WriteLine(paymentMethod.MethodName);
            ////----הדפסת אמצעי תשלום לפי Id-----
            //PaymentMethods paymentMethodById = PaymentMethodsDB.SelectById(1);
            //if (paymentMethodById != null)
            //{
            //    Console.WriteLine(paymentMethodById.MethodName);
            //}
            //else
            //{
            //    Console.WriteLine("Payment method not found");
            //}

            ////======== StatusDB =========
            //StatusDB statusDB = new();
            //StatusList statusList = statusDB.SelectAll();
            //foreach (Status status in statusList)
            //    Console.WriteLine(status.StatusName);
            ////-----הדפסת סטטוס לפי Id-----
            //Status statusById = StatusDB.SelectById(1);
            //if (statusById != null)
            //{
            //    Console.WriteLine(statusById.StatusName);
            //}
            //else
            //{
            //    Console.WriteLine("Status not found");
            //}

            //City myCity = new City() { CityName = "ירושלים" };
            //cdb.Insert(myCity);
            //int x = cdb.SaveChanges();
            //Console.WriteLine($"{x} rows  inserted");


            ////טבלאות הכלה
            //#region
            ////========= Person ==========
            //PersonDB pdb = new();
            //PersonList pList = pdb.SelectAll();
            //foreach (Person c in pList)
            //    Console.WriteLine(c.FirstName);
            //#endregion
            ////======== PaymentsDB ========
            //#region
            //PaymentsDB pdb = new();
            //PaymentsList pList = pdb.SelectAll();
            //foreach (Payments p in pList)
            //    Console.WriteLine(p.IdStudent.Id);
            //#endregion
            //========= LessonsDB ==========
            //#region
            //LessonsDB ldb = new();
            //LessonsList lList = ldb.SelectAll();
            //foreach (Lessons l in lList)
            //{
            //    Console.WriteLine(l.Id);
            //    Console.WriteLine(l.IdStudent.Id);
            //    Console.WriteLine(l.IdTeacher.Id);
            //    Console.WriteLine(l.LessonDate);
            //    Console.WriteLine(l.LessonTime);
            //    Console.WriteLine(l.Topics.Id);
            //    Console.WriteLine(l.Notes);
            //    Console.WriteLine(l.LessonStatus.Id);
            //}
            //#endregion

            //ירושה
            ////========== TeacherDB ========
            //TeacherDB tdb = new();
            //TeacherList tList = tdb.SelectAll();
            //foreach (Teacher t in tList)
            //{
            //    Console.WriteLine(t.Id);
            //    Console.WriteLine(t.FirstName);
            //    Console.WriteLine(t.LastName);
            //    Console.WriteLine(t.Email);
            //    Console.WriteLine(t.PhoneNumber);
            //    Console.WriteLine(t.Pass);
            //    Console.WriteLine(t.City.Id);
            //    Console.WriteLine(t.CarType.Id);
            //    Console.WriteLine(t.PricePerLesson);
            //    Console.WriteLine(t.IdManager.Id);
            //}
            ////========== StudentDB ========
            //StudentDB sdb = new();
            //StudentList sList = sdb.SelectAll();
            //foreach (Student s in sList)
            //{
            //    Console.WriteLine(s.Id);
            //    Console.WriteLine(s.FirstName);
            //    Console.WriteLine(s.LastName);
            //    Console.WriteLine(s.Email);
            //    Console.WriteLine(s.PhoneNumber);
            //    Console.WriteLine(s.Pass);
            //    Console.WriteLine(s.StartDate);
            //    Console.WriteLine(s.BirthDate);
            //    Console.WriteLine(s.Status.StatusName);
            //    Console.WriteLine(s.IdTeacher.Id);
            //}
            ////======= ManagerDB ========
            //ManagerDB mdb = new();
            //ManagerList mList = mdb.SelectAll();
            //foreach (Manager m in mList)
            //{
            //    Console.WriteLine(m.Id);
            //    Console.WriteLine(m.FirstName);
            //    Console.WriteLine(m.LastName);
            //    Console.WriteLine(m.Email);
            //    Console.WriteLine(m.PhoneNumber);
            //    Console.WriteLine(m.Pass);
            //}




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
