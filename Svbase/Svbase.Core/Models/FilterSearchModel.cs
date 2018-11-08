﻿using System.Collections.Generic;
using Svbase.Core.Enums;

namespace Svbase.Core.Models
{
    public class FilterSearchModel
    {
        public IEnumerable<int> StreetIds { get; set; }
        public IEnumerable<int> CityIds { get; set; }
        public IEnumerable<int> DistrictIds { get; set; }
        public DistrictType DistrictType { get; set; }
        public IEnumerable<int> FlatIds { get; set; }
        public IEnumerable<int> ApartmentIds { get; set; }
    }

    public class FilterFileImportModel : FilterSearchModel
    {
        public IEnumerable<int> ColumnsIds { get; set; }

        public IEnumerable<string> BeneficariesUnchecked { get; set; }
        public IEnumerable<string> BeneficariesChecked { get; set; }
    }
}
