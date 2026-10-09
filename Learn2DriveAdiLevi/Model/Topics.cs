using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Topics:BaseEntity
    {
        private string topicName;

        public string TopicName { get => topicName; set => topicName = value; }
    }
}
