﻿using System.ComponentModel.DataAnnotations;

namespace Pustok.ViewModels
{
    public class MemberLoginViewModel
    {

        [Required]
        [MaxLength(25)]
        [MinLength(6)]
        public string LoginUserName { get; set; }
        [Required]
        [MaxLength(25)]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string LoginPassword { get; set; }
    }
}
