using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bpay_Project.DB.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Province> Provinces { get; set; }
    }
}
