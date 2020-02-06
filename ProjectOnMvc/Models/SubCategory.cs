

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectOnMvc.Models
{
    public class SubCategory:Category
    {
        
        public int Subid { get; set; }
        public string Subname { get; set; }
        public SubCategory()
        {

        }
     
        public SubCategory(int subid,string subname,int cid,string cname)
        {
            this.Subid = subid;
            this.Subname = subname;
            this.Cid = cid;
            this.Cname = cname;
        }
    }
}
