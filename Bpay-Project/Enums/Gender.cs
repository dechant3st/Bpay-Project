using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bpay_Project.Enums
{
    public enum Gender
    {
        Male,
        Female,
        [Display(Name = "Not Specified")]
        NotSpecified
    }
}
