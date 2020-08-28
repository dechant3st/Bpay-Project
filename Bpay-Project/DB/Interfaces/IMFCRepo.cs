using Bpay_Project.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bpay_Project.DB.Interfaces
{
    public interface IMFCRepo
    {
        IEnumerable<MFC> All { get; }
        MFC Find(int id);
        MFC Add(MFC model);
        MFC Update(MFC model);
    }
}
