using Bpay_Project.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bpay_Project.DB.Interfaces
{
    public interface ICountryRepo
    {
        IEnumerable<Country> All { get; }
        Country Find(int id);
        Country Add(Country model);
        Country Update(Country model);
        Country Remove(int id);
    }
}
