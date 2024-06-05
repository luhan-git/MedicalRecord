using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalRecord_API.Models.Dtos.Auth
{
    public class AuthResponse
    {
        public bool IsSuccess { get; set; }=false;
        public string?  Token { get; set; }
        public string? Name{get;set;}
        public string? Msg { get; set; }

    }
}