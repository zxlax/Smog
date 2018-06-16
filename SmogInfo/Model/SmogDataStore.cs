using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmogInfo.Model
{
    public class SmogDataStore
    {
        public static SmogDataStore Current { get; } = new SmogDataStore();

        public List<SmogDto> Cities { get; set; }

        public SmogDataStore()
        {
            Cities = new List<SmogDto>()
            {
                new SmogDto()
                {
                    ID =1,
                    CityName = "Warszawa",
                    StationPoints =
                     {
                         new StationPointDto
                         {
                             ID = 1,
                             StreetName ="Aleje Jerozolimskie",
                             PM10Concentration = 44.5m
                         }
                     }

                },
                 new SmogDto()
                {
                    ID =2,
                    CityName = "Kraków",
                    StationPoints =
                     {
                         new StationPointDto
                         {
                             ID = 1,
                             StreetName ="Warszawska",
                             PM10Concentration = 74.25m
                         }
                     }

                }

            };
        }



    }
}
