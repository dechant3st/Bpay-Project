using Bpay_Project.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bpay_Project.DB.Interfaces
{
    public interface IProvinceRepo
    {
        IEnumerable<Province> All { get; }
        Province Find(int id);
        Province Add(Province model);
        Province Update(Province model);
        Province Remove(int id);
    }
}
