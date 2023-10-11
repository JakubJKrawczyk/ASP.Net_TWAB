using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [PrimaryKey("PId")]
    public class ProductEntity
    {
        
        public int PId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
