using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suckMyBawls.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public string Difficulty { get; set; }
        public List<string> Equipment { get; set; }
        public List<Step> Steps { get; set; }
    }
}