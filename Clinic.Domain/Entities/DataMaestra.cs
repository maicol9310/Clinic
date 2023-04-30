using System.ComponentModel.DataAnnotations;

namespace Clinic.Domain.Entities
{
    public class DataMaestra
    {
        [Key]
        public string nmdato { get; set; }
        public string nmmaestro { get; set; }
        public string cddato { get; set; }
        public string dsdato { get; set; }
        public string cddato1 { get; set; }
        public string cddato2 { get; set; }
        public string cddato3 { get; set; }
        public DateTime feregistro { get; set; }
        public DateTime febaja { get; set; }
    }
}
