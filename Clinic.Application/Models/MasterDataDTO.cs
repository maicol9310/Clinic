using Clinic.Application.Mappings;
using Clinic.Domain.Entities;

namespace Clinic.Application.Models
{
    public class MasterDataDTO: IMapFrom<DataMaestra>
    {
        public string nmdato { get; set; }
        public string cddato { get; set; }
    }
}
