using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [PrimaryKey("Id")]
    public class UserEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
    }
}
