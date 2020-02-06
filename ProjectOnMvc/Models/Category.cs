using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ProjectOnMvc.Models
{
    public class Category
    {
        [Key]
        public int Cid { get; set; }
        public string Cname { get; set; }
        public Category()
        {

        }
        public Category(int cid,string cname)
        {
            this.Cid = cid;
            this.Cname = cname;
        }
    }
}
