using System;
using System.ComponentModel.DataAnnotations;

namespace ContactsApi.Models
{
    public class Contacts
    {
        [Required, MinLength(2)]
        public string FirstName { get; set; }

        [Required, MinLength(2)]
        public string LastName { get; set; }

        public bool IsFamilyMember { get; set; }

        public string Company { get; set; }

        public string JobTitle { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string MobilePhone { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime AnniversaryDate { get; set; }
    }
}
