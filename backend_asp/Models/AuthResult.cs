using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace backend_asp.Models
{
    public class AuthResult
    {
        public string? Token { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string>? Errors { get; set; }
        
    }
}