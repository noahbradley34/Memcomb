
using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Memcomb.Models
{
    public class ProfilePageModel
    {
        public Following following { get; set; }
        public User user { get; set; }
        public Boolean setProfile(bool post)
        {
            if (post == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean setBackground(bool post)
        {
            if (post == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}