using Bpay_Project.DB.Entities;
using Bpay_Project.DB.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bpay_Project.DB.Repos
{
    public class BarangayRepo : IBarangayRepo
    {
        private readonly AppDbContext context;

        public BarangayRepo(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Barangay> All => context.Barangay;

        public Barangay Add(Barangay model)
        {
            if(model != null)
            {
                context.Barangay.Add(model);
                context.SaveChanges();
            }

            return model;
        }

        public Barangay Find(int id)
        {
            return context.Barangay.Find(id);
        }

        public IEnumerable<Barangay> FindAllByCity(int cityId)
        {
            return context.Barangay.Where(x => x.City.Id == cityId);
        }

        public Barangay Remove(int id)
        {
            var model = context.Barangay.Find(id);
            context.Barangay.Remove(model);
            context.SaveChanges();
            return model;
        }

        public Barangay Update(Barangay model)
        {
            var attach = context.Barangay.Attach(model);
            attach.State = EntityState.Modified;
            context.SaveChanges();
            return model;
        }
    }
}
