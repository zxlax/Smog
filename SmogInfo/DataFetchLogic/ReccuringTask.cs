using SmogInfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmogInfo.DataFetchLogic
{
    public class ReccuringTasks
    {
      

        public void Task(SmogInfoContext smogInfoContext, string url, int city, int station)
        {

            var a = new DataOperator(smogInfoContext);
            a.StartFrequentDataOperating(url, 1, 1);

        }

      

    }
}
