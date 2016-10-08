using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Model
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Edition { get; set; }
        public string AdditionalInfo { get; set; }
        public DateTime UploadDateTime { get; set; }
        public float Price { get; set; }
        public bool Approved { get; set; }

        /// <summary>
        /// Ralations 
        /// </summary>
        public virtual ICollection<Department> Departments { get; set; }

        public int ConditionId { get; set; }
        public virtual Condition Condition { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public ICollection<Photo> Photos { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser{ get; set; }

    }
}
