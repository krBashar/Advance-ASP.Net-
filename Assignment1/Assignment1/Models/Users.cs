using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment1.Models
{
    public class Users
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(7, ErrorMessage = "Name must be between 1 and 7 characters.")]
        [RegularExpression(@"^[A-Za-z.\s-]*$", ErrorMessage = "Name can only contain alphabets, '.', space, or '-'.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(10, ErrorMessage = "Username must be at most 10 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Id is required.")]
        [RegularExpression(@"^(\d{2}-\d{5}-[1-3])$", ErrorMessage = "Invalid Id Format")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^.*@student\.aiub\.edu$", ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }

        public bool IsEmailMatchingId()
        {
            if (Email != null && Id != null && Email.Length >= 10 && Id.Length >= 10)
            {
                // Compare the first 10 characters of the email with the first 10 characters of the ID
                return Email.Substring(0, 10) == Id.Substring(0, 10);
            }
            return false;
        }

    }
}