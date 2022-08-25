using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopQuanAo.Models
{
    public class UserDTO
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public Nullable<int> SDT { get; set; }
        public string PASSWORD { get; set; }
        public int TYPE { get; set; }
    }
}