using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtKeyMusic.Entities.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public decimal Price { get; set; }
        public ICollection<User> Users { get; set; }
    }

}