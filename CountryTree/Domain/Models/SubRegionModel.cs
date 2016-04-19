using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryTree.Domain.Models
{
    public class SubRegionModel
    {
        public int id { get; set; }
        public int CountryId { get; set; }

        public CountryModel Country { get; set; }

        public string Name { get; set; }
        public List<SubRegionModel> SubRegions { get; set; }
    }
}
