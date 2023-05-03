using Clinic.Application.Mappings;
using Clinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Models
{
    public class PatientsDTO : IMapFrom<Pacientes>
    {
        [Key]
        public int nmid { get; set; }
        public int nmid_persona { get; set; }
        public string cddocumento { get; set; }
        public string dsnombres { get; set; }
        public string dsapellidos { get; set; }
        public string fenacimiento { get; set; }
        public string cdtipo { get; set; }
        public string cdgenero { get; set; }
        public int nmid_medicotra { get; set; }
        public string dsnombresDoctor { get; set; }
        public string dsapellidosDoctor { get; set; }
        public string dsdireccion { get; set; }
        public string dsphoto { get; set; }
        public string cdtelefono_fijo { get; set; }
        public string cdtelefono_movil { get; set; }
        public string dsemail { get; set; }
        public string dseps { get; set; }
        public string dsarl { get; set; }
        public string feregistro { get; set; }
        public string febaja { get; set; }
        public string cdusuario { get; set; }
        public string dscondicion { get; set; }
    }
}
