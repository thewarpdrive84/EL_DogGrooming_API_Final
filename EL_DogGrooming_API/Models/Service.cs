using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace EL_DogGrooming_API.Models
{
    public class Service
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}