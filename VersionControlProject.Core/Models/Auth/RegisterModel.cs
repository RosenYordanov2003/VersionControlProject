﻿namespace VersionControlProject.Core.Models.Auth
{
    using System.ComponentModel.DataAnnotations;
    public class RegisterModel
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string RepeatPassword { get; set; } = null!;
    }
}
