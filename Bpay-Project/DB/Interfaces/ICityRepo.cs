using Bpay_Project.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bpay_Project.DB.Interfaces
{
    public interface ICityRepo
    {
        IEnumerable<City> All { get; }
        IEnumerable<City> FindAllByProvince(int provinceId);
        City Find(int id);
        City Add(City model);
        City Update(City model);
        City Remove(int id);
    }
}
