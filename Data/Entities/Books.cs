using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Books : BaseEntity
    {
        public string Name { get; set; }
          public decimal Cost { get; set; }

        //Navigation

        public List<AuthorsBooks> AuthorsBooks { get; set; }
    }
}
