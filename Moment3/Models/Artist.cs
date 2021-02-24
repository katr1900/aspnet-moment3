using System;
namespace Moment3.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CD CD { get; set; }
    }
}
