using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmogInfo.Entities
{
    public class StationPoint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string StreetName { get; set; }

        public ICollection<SmogLevel> SmogLevels { get; set; } = new List<SmogLevel>();

        [ForeignKey("CityId")]
        public City City { get; set; }

        public int CityId { get; set; }

    }
}
