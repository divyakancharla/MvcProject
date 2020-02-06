using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ProjectOnMvc.Models
{
    public class Buyer
    {
        [Key]
        [Required(ErrorMessage ="Fill The Field")]
        [RegularExpression(@"[0-9]{,5}",ErrorMessage ="Invalid Type Of data")]
        
        public int Bid { get; set; }
        [Required(ErrorMessage ="Fill The Field")]
        [RegularExpression(@"[A-Z][a-z]{3,10}",ErrorMessage ="First Letter Must Be Capital")]
        public string Bname { get; set; }
        [DataType("password")]
        [RegularExpression("^.*(?=.{8,})(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessage = "Name should be valid")]
        public string Pass { get; set; }
        [EmailAddress(ErrorMessage ="Email Required")]
        [Remote(action:"IsExists",controller:"Buyer")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Fill The Field")]
        [RegularExpression(@"[6,9][0-9]{9}", ErrorMessage = "Invalid Type Of data")]
        public string Phone { get; set; }
        [Required(ErrorMessage ="Required")]
        public DateTime Date { get; set; }
        public Buyer()
        {

        }
        public Buyer(int bid, string bname, string pass, string email, string phone, DateTime date)
        {
            this.Bid = bid;
            this.Bname = bname;
            this.Pass = pass;
            this.Email = email;
            this.Phone = phone;
            this.Date = date;
        }
        
    }
}
