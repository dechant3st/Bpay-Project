using Bpay_Project.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bpay_Project.DB.Entities
{
    public class MFC
    {
        public int Id { get; set; }
        public AppUser User { get; set; }
        public ClassificationEligible Classification { get; set; }
        public FamilyType? FamilyType { get; set; }
        public string Other { get; set; }

        public string IDNumber { get; set; }

        public LookupSubcategory MyProperty { get; set; }
        public string EmployerBusinessName { get; set; }
        public string CompanyBusinessAddress { get; set; }
        public string PositionOccupation { get; set; }
        public ApprovalStatus Status { get; set; }
    }
}
