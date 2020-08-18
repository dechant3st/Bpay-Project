using Bpay_Project.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bpay_Project.DB.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public Province Province { get; set; }
        public City City { get; set; }
        public Barangay Barangay { get; set; }
        public string Street { get; set; }
        public Gender Gender { get; set; }
        public CivilStatus CivilStatus { get; set; }
        public Country Country { get; set; }
        public string Nationality { get; set; }
        public string PlaceOfBirth { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public UserStatus Status { get; set; }
    }
}
