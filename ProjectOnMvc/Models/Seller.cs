using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace ProjectOnMvc.Models
{
    public class Seller
    {
        [Key]
        [Required(ErrorMessage = "Fill The Field")]
        [RegularExpression(@"[0-9]{,5}", ErrorMessage = "Invalid Type Of data")]
        public int Sid { get; set; }
        [Required(ErrorMessage = "Fill The Field")]
        [RegularExpression(@"[A-Z][a-zA-z]{3,10}", ErrorMessage = "First Letter Must Be Capital")]
        public string Sname { get; set; }
        [Required(ErrorMessage = "Fill The Field")]
        [RegularExpression("^.*(?=.{8,})(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessage = "Name should be valid")]
        public string Pass { get; set; }
        [EmailAddress(ErrorMessage = "Email Required")]
        [Remote(action: "IsExists", controller: "Buyer")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Fill The Field")]
        [RegularExpression(@"[0-9]{6,9}", ErrorMessage = "Invalid Type Of data")]
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public string photopath { get; set; }
        public Seller()
        {

        }
        public Seller(int sid, string sname, string pass, string email, string phone, DateTime date)
        {
            this.Sid = sid;
            this.Sname = sname;
            this.Pass = pass;
            this.Email = email;
            this.Phone = phone;
            this.Date = date;
        }
    }
}
