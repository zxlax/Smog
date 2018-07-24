using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmogInfo.SmogLevelsLogic.Model
{
    public class GIOSList
    {
        public string Key { get; set; }

        public ICollection<GIOSLevel> Values { get; set; } = new List<GIOSLevel>();

    }
}
