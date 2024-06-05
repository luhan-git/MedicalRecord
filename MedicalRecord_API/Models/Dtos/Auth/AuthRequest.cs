using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalRecord_API.Models.Dtos.Auth
{
    public class AuthRequest
    {
        [Required]
        public string  Correo { get; set; }=null!;
        [Required]
        public string  Password{ get; set; }=null!;
    }
}