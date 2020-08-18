using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bpay_Project.DB.Entities
{
    public class Barangay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
    }
}
