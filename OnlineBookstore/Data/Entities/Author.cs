using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Data.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
        
        public string ShortDescription { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public bool Popularity { get; set; }
    }
}
