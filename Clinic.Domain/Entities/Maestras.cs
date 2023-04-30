using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Domain.Entities
{
    public class Maestras
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string nmmaestro { get; set; }
        public string cdmaestro { get; set; }
        public string dsmaestro { get; set; }
        public DateTime feregistro { get; set; }
        public DateTime febaja { get; set; }
    }
}
