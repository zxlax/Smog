using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmogInfo.Entities
{
    public class SmogLevel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public decimal PM10Concentration { get; set; }

        public decimal PM25Concentration { get; set; }

        [ForeignKey("StationPointId")]
        public StationPoint StationPoint { get; set; }

        public int StationPointId { get; set; }


    }
}
