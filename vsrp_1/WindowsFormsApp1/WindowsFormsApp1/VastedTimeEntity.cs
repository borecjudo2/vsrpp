using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class VastedTimeEntity
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public int vastedTime { get; set; }
        public DateTime createdTime { get; set; }

        public VastedTimeEntity(Guid id, string name, int vastedTime, DateTime createdTime)
        {
            this.id = id;
            this.name = name;
            this.vastedTime = vastedTime;
            this.createdTime = createdTime;
        }
    }
}
