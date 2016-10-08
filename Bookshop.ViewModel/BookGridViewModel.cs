using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.ViewModel
{
    public class BookGridViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public String UploadDateTime { get; set; }
        public float Price { get; set; }
        public string Photo { get; set; }
    }
}
