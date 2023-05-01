using Clinic.Application.Mappings;
using Clinic.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Clinic.Application.Models
{
    public class PeopleDTO : IMapFrom<Personas>
    {
        public int nmid { get; set; }
        public string dsnombres { get; set; }
        public string dsapellidos { get; set; }
    }
}
