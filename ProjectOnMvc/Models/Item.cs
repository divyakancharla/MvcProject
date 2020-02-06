using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOnMvc.Models
{
    public class Item:SubCategory
    {
        
        public int itemid { get; set; }
        public string itemname { get; set; }
        public double itemprice { get; set; }
        public Item()
        {

        }
        
        public Item(int iid,string iname,double iprice,int subid,string subname,int cid,string cname)
        {
            this.itemid = iid;
            this.itemname = iname;
            this.itemprice = iprice;
            this.Subid = subid;
            this.Subname = subname;
            this.Cid = cid;
            this.Cname = cname;
        }
    }
}
