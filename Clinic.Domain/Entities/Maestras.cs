using System.ComponentModel.DataAnnotations;

namespace Clinic.Domain.Entities
{
    public class Maestras
    {
        [Key]
        public string nmmaestro { get; set; }
        public string cdmaestro { get; set; }
        public string dsmaestro { get; set; }
        public DateTime feregistro { get; set; }
        public DateTime febaja { get; set; }
    }
}
