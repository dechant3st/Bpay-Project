using Bpay_Project.DB.Entities;
using Bpay_Project.DB.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bpay_Project.DB.Repos
{
    public class ProvinceRepo : IProvinceRepo
    {
        private readonly AppDbContext context;

        public ProvinceRepo(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Province> All => context.Provinces
            .Include(x => x.Cities)
                .ThenInclude(x => x.Barangay);

        public Province Add(Province model)
        {
            if(model != null)
            {
                context.Provinces.Add(model);
                context.SaveChanges();
            }
            return model;
        }

        public Province Find(int id)
        {
            return context.Provinces
                .Include(x => x.Cities)
                    .ThenInclude(x => x.Barangay)
                .FirstOrDefault(x => x.Id == id);
        }

        public Province Remove(int id)
        {
            var model = context.Provinces.Find(id);
            context.Provinces.Remove(model);
            context.SaveChanges();
            return model;
        }

        public Province Update(Province model)
        {
            var attach = context.Provinces.Attach(model);
            attach.State = EntityState.Modified;
            context.SaveChanges();
            return model;
        }
    }
}
