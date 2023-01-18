using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Components.API.Models
{
    [Table("Beers")]
    public class Beer : TableModel
    {

        [Required]
        [StringLength(28)]
        public string Name { get; set; }

        [StringLength(28)]
        public string Brewery { get; set; }

        [Precision(10,2)]
        public double PercentageAlcoholByVolume { get; set; }
    }
}
