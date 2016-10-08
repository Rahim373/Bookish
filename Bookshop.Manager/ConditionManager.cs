using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookshop.Model;

namespace Bookshop.Manager
{
    public class ConditionManager
    {
        BookshopDbContext db;

        public ConditionManager()
        {
            db = new BookshopDbContext();
        }

        public List<Condition> GetConditions()
        {
            return db.Conditions.ToList();
        }
    }
}
