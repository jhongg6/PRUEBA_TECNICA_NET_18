using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Operator
    {
        public int IdClient { get; set; }
        public int IdentityCard { get; set; }
        public string NameClient { get; set; }
        public string SurnameClient { get; set; }
        public DateTime DateBirth { get; set; }
        public int Phone1 { get; set; }
        public int Phone2 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public DateTime RegistrationDate { get; set; }

    }
}