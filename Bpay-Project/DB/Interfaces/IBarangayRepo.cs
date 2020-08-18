using Bpay_Project.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bpay_Project.DB.Interfaces
{
    public interface IBarangayRepo
    {
        IEnumerable<Barangay> All { get; }
        IEnumerable<Barangay> FindAllByCity(int cityId);
        Barangay Find(int id);
        Barangay Add(Barangay model);
        Barangay Update(Barangay model);
        Barangay Remove(int id);
    }
}
