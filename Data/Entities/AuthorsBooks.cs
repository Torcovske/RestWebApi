using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class AuthorsBooks : BaseEntity
    {
        //Navigation
        //Authors
        public Guid AuthorsId { get; set; }
        [ForeignKey("AuthorsId")]
        public Authors Authors { get; set; }
        //Books
        public Guid BooksId { get; set; }
        [ForeignKey("BooksId")]
        public Books Books { get; set; }
    }
}
