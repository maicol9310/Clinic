using Clinic.Application.Enum;
using Clinic.Application.Interfaces;
using Clinic.Application.Models;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Application.Masters.Queries
{
    public class GetTypePeopleQuery : IRequest<List<MasterDataDTO>>
    {
    }

    public class GetTypePeopleQueryHadler : IRequestHandler<GetTypePeopleQuery, List<MasterDataDTO>>
    {
        private readonly IClinicDbContext _context;

        public GetTypePeopleQueryHadler(IClinicDbContext context)
        {
            _context = context;
        }

        public async Task<List<MasterDataDTO>> Handle(GetTypePeopleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<MasterDataDTO> TypePeople = new List<MasterDataDTO>();

                TypePeople = await (from a in _context.MasterData
                             join e in _context.Masters on a.nmmaestro equals e.nmmaestro
                             where a.nmmaestro == NameMaster.TypePeople
                             select new MasterDataDTO()
                             {
                                 nmdato = a.nmdato,
                                 cddato = a.cddato,

                             }).ToListAsync(cancellationToken);

                return TypePeople;

            }
            catch (Exception ex)
            {
                throw new ValidationException("No se pudo listar a los tipos de personas, Error:" + ex.Message);
            }
        }
    }
}
