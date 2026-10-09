using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Teacher:Person
    {
        private City city;
        private CarType carType;
        private int pricePerLesson;
        private Manager idManager;

        public City City { get => city; set => city = value; }
        public CarType CarType { get => carType; set => carType = value; }
        public int PricePerLesson { get => pricePerLesson; set => pricePerLesson = value; }
        public Manager IdManager { get => idManager; set => idManager = value; }
    }
}
