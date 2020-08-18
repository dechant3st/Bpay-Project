using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bpay_Project.DB.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Province Province { get; set; }

        public virtual List<Barangay> Barangay { get; set; }
    }
}
