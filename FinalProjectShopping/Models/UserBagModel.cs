using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectShopping.Models
{
    public class UserBagModel
    {
        public UserAccount _user { get; set; }
        public List<UserBag> _user_bag { get; set; }
    }
}