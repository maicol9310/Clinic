using Clinic.Application.Enum;
using Clinic.Application.Interfaces;
using Clinic.Application.Masters.Queries;
using Clinic.Application.Models;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.People.Commands
{
    public class GetDoctorsQuery: IRequest<List<PeopleDTO>>
    {
    }

    public class GetDoctorsQueryHadler : IRequestHandler<GetDoctorsQuery, List<PeopleDTO>>
    {
        private readonly IClinicDbContext _context;

        public GetDoctorsQueryHadler(IClinicDbContext context)
        {
            _context = context;
        }

        public async Task<List<PeopleDTO>> Handle(GetDoctorsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<PeopleDTO> Doctors = new List<PeopleDTO>();

                Doctors = await (from a in _context.Peoples
                                    where a.cdtipo == TipoPersona.Doctor
                                    select new PeopleDTO()
                                    {
                                        nmid = a.nmid,
                                        dsnombres = a.dsnombres,
                                        dsapellidos = a.dsapellidos,

                                    }).ToListAsync(cancellationToken);

                return Doctors;

            }
            catch (Exception ex)
            {
                throw new ValidationException("No se pudo listar los doctores, Error:" + ex.Message);
            }
        }
    }
}

