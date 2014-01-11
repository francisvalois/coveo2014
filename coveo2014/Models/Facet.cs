namespace coveo2014.Models
{
    using System.Collections.Generic;

    public class Facet
    {
        public bool IsList { get; set; }

        public string Name { get; set; }

        public IList<string> Values { get; set; }
    }
}
