using Bpay_Project.DB.Entities;
using Bpay_Project.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bpay_Project.DB.Repos
{
    public class CountryRepo : ICountryRepo
    {
        private readonly AppDbContext context;

        public CountryRepo(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Country> All => throw new NotImplementedException();

        public Country Add(Country model)
        {
            throw new NotImplementedException();
        }

        public Country Find(int id)
        {
            throw new NotImplementedException();
        }

        public Country Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Country Update(Country model)
        {
            throw new NotImplementedException();
        }
    }
}
