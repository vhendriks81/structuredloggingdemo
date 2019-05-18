using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApi.Models
{
    public class Rockstar : Person
    {
        public Rockstar(string name, string socialSecurityNumber, string title)
            : base(name, socialSecurityNumber)
        {
            Title = title;
        }

        public string Title { get; }
    }
}
