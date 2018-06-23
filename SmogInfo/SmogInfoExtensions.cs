using SmogInfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmogInfo
{
    public static class SmogInfoExtensions
    {

        public static void EnsureDataForContext(this SmogInfoContext context)
        {
            if (context.Cities.Any())
                return;

            var Cities = new List<City>()
            {
                new City()
                {

                    CityName = "Warszawa",
                    StationPoints =
                     {
                         new StationPoint
                         {

                             StreetName ="Aleje Jerozolimskie",
                               SmogLevels =
                             {
                                 new SmogLevel
                                 {
                                     DateTime = new DateTime(2018,6,16,17,20,10),
                                     PM10Concentration = 26.5m

                                 },

                             }

                         }
                    }
                }
            };


            context.Cities.AddRange(Cities);
            context.SaveChanges();
        }
    }
}
