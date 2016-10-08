using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    class BookViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Edition { get; set; }
        public int Department { get; set; }
        public int Category { get; set; }
        public string Condition { get; set; }
        public string AdditionalInfo { get; set; }
        public DateTime UploadDateTime { get; set; }
        public float Price { get; set; }
    }
}
