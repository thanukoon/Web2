using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web2.Entities;

namespace Web2.Models
{
    public class classchannel
    {

        public object users { get; set; }
    }

    public class users
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string room { get; set; }

    }

   
}