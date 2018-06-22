using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmogInfo.Model
{
    public class SmogDataStore
    {
        public static SmogDataStore Current { get; } = new SmogDataStore();

        public List<CitiesDto> Cities { get; set; }

        public SmogDataStore()
        {
            Cities = new List<CitiesDto>()
            {
                new CitiesDto()
                {
                    ID =1,
                    CityName = "Warszawa",
                    StationPoints =
                     {
                         new StationPointDto
                         {
                             ID = 1,
                             StreetName ="Aleje Jerozolimskie",
                               SmogLevels =
                             {
                                 new SmogLevelDto
                                 {
                                     DateTime = new DateTime(2018,6,16,17,20,10),
                                     PM10Concentration = 26.5m

                                 },

                                  new SmogLevelDto
                                 {
                                     DateTime = new DateTime(2018,6,16,19,20,10),
                                     PM10Concentration = 15.25m

                                 }
                             }

                         },

                          new StationPointDto
                         {
                             ID = 2,
                             StreetName ="plac Bankowy",
                               SmogLevels =
                             {
                                 new SmogLevelDto
                                 {
                                     DateTime = new DateTime(2018,6,16,17,20,10),
                                     PM10Concentration = 13.5m

                                 }
                             }

                         }
                     }

                },
                 new CitiesDto()
                {
                    ID =2,
                    CityName = "Kraków",
                    StationPoints =
                     {
                         new StationPointDto
                         {
                             ID = 1,
                             StreetName ="Warszawska",
                             SmogLevels =
                             {
                                 new SmogLevelDto
                                 {
                                     DateTime = new DateTime(2018,6,16,17,20,10),
                                     PM10Concentration = 46.5m
                                     
                                 }
                             }
                         }
                     }

                }

            };
        }



    }
}
