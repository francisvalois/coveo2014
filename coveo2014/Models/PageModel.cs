namespace coveo2014.Models
{
    using System.Collections.Generic;

    public class PageModel<T>
    {
        public PageModel()
        {
            this.AvailableFacets = new List<Facet>();

            this.Items = new List<T>();
        }

        public IList<Facet> AvailableFacets { get; set; }

        public IList<T> Items { get; set; }
    }
}
