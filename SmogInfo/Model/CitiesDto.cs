using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmogInfo.Model
{
    public class CitiesDto
    {
        public int ID { get; set; }

        public string CityName { get; set; }

        public ICollection<StationPointDto> StationPoints { get; set; } = new List<StationPointDto>();


    }
}
