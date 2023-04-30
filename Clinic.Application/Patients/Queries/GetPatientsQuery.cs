using AutoMapper;
using AutoMapper.QueryableExtensions;
using Clinic.Application.Enum;
using Clinic.Application.Interfaces;
using Clinic.Application.Models;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Application.Patients.Queries
{
    public class GetPatientsQuery: IRequest<List<PatientsDTO>>
    {
    }

    public class GetPatientsQueryHandler : IRequestHandler<GetPatientsQuery, List<PatientsDTO>>
    {
        private readonly IClinicDbContext _context;
        private readonly IMapper _mapper;

        public GetPatientsQueryHandler(IClinicDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PatientsDTO>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
        {
            List<PatientsDTO> Patients = new List<PatientsDTO>();

            Patients = await (from e in _context.Patients
                                  join a in _context.Peoples on e.nmid_persona equals a.nmid
                                  select new PatientsDTO()
                                  {
                                    nmid = e.nmid,
                                    nmid_persona = a.nmid,
                                    cddocumento = a.cddocumento,
                                    dsnombres = a.dsnombres,
                                    dsapellidos = a.dsapellidos,
                                    cdgenero = a.cdgenero,
                                    nmid_medicotra = e.nmid_medicotra,
                                    dseps = e.dseps,
                                    dsarl = e.dsarl,
                                    feregistro = e.feregistro,
                                    febaja = e.febaja,
                                    cdusuario = e.cdusuario,
                                    dscondicion = e.dscondicion,

                                  }).ToListAsync(cancellationToken);

            var Doctors = await (from a in _context.Peoples
                                  where  a.cdtipo == TipoPersona.Doctor
                                  select new PatientsDTO()
                                  {
                                      nmid = a.nmid,
                                      dsnombres = a.dsnombres,
                                      dsapellidos = a.dsapellidos,

                                  }).ToListAsync(cancellationToken);

            foreach (var Doctor in Doctors)
            {
                var DoctorId = Doctor.nmid;

                foreach (var Patient in Patients)
                {
                    if (Patient.nmid_medicotra == DoctorId)
                    {
                        Patient.dsnombresDoctor = Doctor.dsnombres;
                        Patient.dsapellidosDoctor = Doctor.dsapellidos;
                    }
                }
            }

            return Patients;
        }
    }
}
