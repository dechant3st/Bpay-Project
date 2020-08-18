using Bpay_Project.DB.Entities;
using Bpay_Project.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bpay_Project.ViewModels
{
    public class RegistrationViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Suffix { get; set; }
        [Required]
        public Province Province { get; set; }
        [Required]
        public City City { get; set; }
        [Required]
        public Barangay Barangay { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public CivilStatus CivilStatus { get; set; }
        [Required]
        public Country Country { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public string PlaceOfBirth { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password must match with password.")]
        public string ConfirmPassword { get; set; }

        public List<Country> Countries { get; set; }
        public List<Province> Provinces { get; set; }
        public List<City> Cities { get; set; }
        public List<Barangay> Barangays { get; set; }
    }
}
