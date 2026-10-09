using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Status:BaseEntity
    {
        private string statusName;

        public string StatusName { get => statusName; set => statusName = value; }
    }
}
