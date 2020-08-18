using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bpay_Project.DB.Entities
{
    public class LookupSubcategory
    {
        public int Id { get; set; }
        public LookupCategory LookupCategory { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public AppUser CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public AppUser UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
