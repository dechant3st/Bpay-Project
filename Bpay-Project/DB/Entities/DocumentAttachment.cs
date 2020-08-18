using Bpay_Project.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Bpay_Project.DB.Entities
{
    public class DocumentAttachment
    {
        public int Id { get; set; }
        public AccountType AccountType { get; set; }
        public int ReferenceId { get; set; }
        public string DocPath { get; set; }
        public string DocType { get; set; }
        public int Status { get; set; }
    }
}
