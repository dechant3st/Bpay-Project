using Bpay_Project.DB.Entities;
using Bpay_Project.DB.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bpay_Project.DB.Repos
{
    public class MFCRepo : IMFCRepo
    {
        private readonly AppDbContext context;

        public MFCRepo(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<MFC> All => context.MFC.Include(x => x.User);

        public MFC Add(MFC model)
        {
            if(model != null)
            {
                context.MFC.Add(model);
                context.SaveChanges();
            }
            return model;
        }

        public MFC Find(int id)
        {
            return context.MFC.Include(x => x.User)
                .FirstOrDefault(x => x.Id == id);
        }

        public MFC Update(MFC model)
        {
            var attach = context.MFC.Attach(model);
            attach.State = EntityState.Modified;
            context.SaveChanges();
            return model;
        }
    }
}
