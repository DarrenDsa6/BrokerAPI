﻿using System.ComponentModel.DataAnnotations;

namespace BrokerAPI.Models.Views
{
    public class LoginDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
