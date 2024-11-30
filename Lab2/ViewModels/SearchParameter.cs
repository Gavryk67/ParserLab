using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.ViewModels
{
    public class SearchParameter
    {
        public string Attribute { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{Attribute}: {Value}";
        }
    }
}