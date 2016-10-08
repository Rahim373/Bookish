using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;

namespace Bookshop.ViewModel
{
    public class UploadBookViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public int Edition { get; set; }

        [Required]
        public int Department { get; set; }

        [Required]
        public int Category { get; set; }

        [Required]
        public int Condition { get; set; }

        [DisplayName("Additional Info")]
        public string AdditionalInfo { get; set; }

        public DateTime UploadDateTime { get; set; }


        [DataType(DataType.Currency)]
        [Required]
        public float Price { get; set; }
    }
}
