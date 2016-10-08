using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bookshop.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
        public string UidId { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
