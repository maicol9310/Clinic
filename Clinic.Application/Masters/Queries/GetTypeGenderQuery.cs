using Clinic.Application.Enum;
using Clinic.Application.Interfaces;
using Clinic.Application.Models;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Application.Masters.Queries
{
    public class GetTypeGenderQuery : IRequest<List<MasterDataDTO>>
    {
    }

    public class GetTypeGenderQueryHadler : IRequestHandler<GetTypeGenderQuery, List<MasterDataDTO>>
    {
        private readonly IClinicDbContext _context;

        public GetTypeGenderQueryHadler(IClinicDbContext context)
        {
            _context = context;
        }

        public async Task<List<MasterDataDTO>> Handle(GetTypeGenderQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<MasterDataDTO> Sex = new List<MasterDataDTO>();

                Sex = await (from a in _context.MasterData
                             join e in _context.Masters on a.nmmaestro equals e.nmmaestro
                             where a.nmmaestro == NameMaster.Sex
                             select new MasterDataDTO()
                             {
                                  nmdato = a.nmdato,
                                  cddato = a.cddato,

                             }).ToListAsync(cancellationToken);

                return Sex;

            }
            catch (Exception ex)
            {
                throw new ValidationException("No se pudo listar a los tipos de sexo, Error:" + ex.Message);
            }
        }
    }
}
