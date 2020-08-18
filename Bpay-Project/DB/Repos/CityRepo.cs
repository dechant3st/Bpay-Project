using Bpay_Project.DB.Entities;
using Bpay_Project.DB.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bpay_Project.DB.Repos
{
    public class CityRepo : ICityRepo
    {
        private readonly AppDbContext context;

        public CityRepo(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<City> All => context.Cities
            .Include(x => x.Barangay);

        public City Add(City model)
        {
            if(model != null)
            {
                context.Cities.Add(model);
                context.SaveChanges();
            }

            return model;
        }

        public City Find(int id)
        {
            return context.Cities.Find(id);
        }

        public IEnumerable<City> FindAllByProvince(int provinceId)
        {
            return context.Cities
                .Include(x => x.Barangay)
                .Where(x => x.Province.Id == provinceId);
        }

        public City Remove(int id)
        {
            var model = context.Cities.Find(id);
            context.Cities.Remove(model);
            context.SaveChanges();
            return model;
        }

        public City Update(City model)
        {
            var attach = context.Cities.Attach(model);
            attach.State = EntityState.Modified;
            context.SaveChanges();
            return model;
        }
    }
}
