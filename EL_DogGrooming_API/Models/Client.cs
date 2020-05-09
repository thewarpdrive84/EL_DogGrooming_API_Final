using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace EL_DogGrooming_API.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string DogName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}