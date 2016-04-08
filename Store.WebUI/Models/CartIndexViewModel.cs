using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Domain.Entities;

namespace Store.WebUI.Models
{
        public class CartIndexViewModel
        {
            public Cart Cart { get; set; }
            public string ReturnUrl { get; set; }
        }
    
}