using SmogInfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmogInfo.DataFetchLogic
{
    public class ReccuringTasks
    {
      

        public void Task(SmogInfoContext smogInfoContext, string url10,string url25, int city, int station)
        {

            var a = new DataOperator(smogInfoContext);
            a.StartFrequentDataOperating(url10,url25, 1, 1);

        }

      

    }
}
