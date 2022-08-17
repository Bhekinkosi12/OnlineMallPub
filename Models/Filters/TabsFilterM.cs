using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMall.Models.Filters
{
    internal class TabsFilterM
    {
        public string Name { get; set; }
        public List<SugestionM> ClosestSuggests { get; set; }
    }
}
