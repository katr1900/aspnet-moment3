using System;
using System.Collections.Generic;

namespace Moment3.Models
{
    public class CD
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public List<Artist> Artists { get; set; }
    }

}

