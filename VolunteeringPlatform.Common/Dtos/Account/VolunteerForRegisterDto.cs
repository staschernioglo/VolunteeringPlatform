﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolunteeringPlatform.Common.Dtos.Account
{
    public class VolunteerForRegisterDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        public string? PersonalInformation { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [StringLength(50)]
        public string? Locality { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
