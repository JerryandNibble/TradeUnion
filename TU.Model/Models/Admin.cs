using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TU.Model.Models
{
    public class Admin
    {
       public  Admin()
        {
            
        }

        public int ID
        {
            get; set;
        }
        public string UserName
        {
            get; set;
        }
        public string PassWord
        {
            get; set;
        }
    }
}