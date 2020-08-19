using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Data.Options
{
    public class NumbersAPIOptions
    {
        public const string NumbersAPI = "NumbersAPI";
        public string Address { get; set; }
        public IDictionary<string, string> CommonHeaders { get; set; }
    }
}
