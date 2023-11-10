using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int PubId { get; set; }
        public DateTime HireDate { get; set; }
        public Role? Role { get; set; }
        public Publisher? Publisher { get; set; }

    }
}
