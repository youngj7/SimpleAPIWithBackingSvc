using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SimpleAPIWithBackingSvc.Models
{
    [Serializable]
    public partial class User
    {
        public int ID { get; set; }
        public string Username { get; set; }

        public User() {}
    }
}