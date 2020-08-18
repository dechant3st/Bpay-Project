using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bpay_Project.DB.Entities
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<City> Cities { get; set; }
    }
}
