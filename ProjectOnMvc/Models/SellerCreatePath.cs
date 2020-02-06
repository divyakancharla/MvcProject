using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace ProjectOnMvc.Models
{
    public class SellerCreatePath
    {
        public int Sid { get; set; }
        public string Sname { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public IFormFile photopath { get; set; }
    }
}
