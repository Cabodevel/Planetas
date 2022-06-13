using System.ComponentModel.DataAnnotations;

namespace Planetas.Web.Models
{
    public class HazardousAsteroidsFilter
    {
        [Display(Name = "Nombre del planeta")]
        public string PlanetName { get; set; }

        [Display(Name = "Fecha de inicio")]
        public DateTime? FromDate { get; set; }

        [Display(Name = "Fecha de fin")]
        public DateTime? ToDate { get; set; }
    }
}
