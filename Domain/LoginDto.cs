﻿
namespace Domain
{
    public class LoginDto
    {
        public string Username {  get; set; }
        public string Password { get; set; }
        public TypeAccess TypeAccess { get; set; }
    }
}
