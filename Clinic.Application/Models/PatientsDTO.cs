using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Models
{
    public class PatientsDTO
    {
        [Key]
        public int nmid { get; set; }
        public int nmid_persona { get; set; }
        public int nmid_medicotra { get; set; }
        public string dseps { get; set; }
        public string dsarl { get; set; }
        public DateTime feregistro { get; set; }
        public DateTime febaja { get; set; }
        public string cdusuario { get; set; }
        public string dscondicion { get; set; }
    }
}
