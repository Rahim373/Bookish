using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.ViewModel
{
    public class BookDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Edition { get; set; }
        public string Department { get; set; }
        public string Category { get; set; }
        public string Condition { get; set; }
        public string AdditionalInfo { get; set; }
        public string UploadDateTime { get; set; }
        public string Photo { get; set; }
        public float Price { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
    }
}
