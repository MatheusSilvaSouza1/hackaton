﻿
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Login
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public TypeAccess TypeAccess { get; set; }
    }
}
