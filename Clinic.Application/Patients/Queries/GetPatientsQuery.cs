using Clinic.Application.Enum;
using Clinic.Application.Interfaces;
using Clinic.Application.Models;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Application.Patients.Queries
{
    public class GetPatientsQuery : IRequest<List<PatientsDTO>>
    {
    }

    public class GetPatientsQueryHandler : IRequestHandler<GetPatientsQuery, List<PatientsDTO>>
    {
        private readonly IClinicDbContext _context;

        public GetPatientsQueryHandler(IClinicDbContext context)
        {
            _context = context;
        }

        public async Task<List<PatientsDTO>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
        {
            try
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
                                      fenacimiento = a.fenacimiento.ToString("yyyy/MM/dd"),
                                      cdtipo = a.cdtipo,
                                      cdgenero = a.cdgenero,
                                      nmid_medicotra = e.nmid_medicotra,
                                      dsdireccion = a.dsdireccion,
                                      dsphoto = a.dsphoto,
                                      cdtelefono_fijo = a.cdtelefono_fijo,
                                      cdtelefono_movil = a.cdtelefono_movil,
                                      dsemail = a.dsemail,
                                      dseps = e.dseps,
                                      dsarl = e.dsarl,
                                      feregistro = e.feregistro.ToString("yyyy/MM/dd"),
                                      febaja = e.febaja.ToString("yyyy/MM/dd"),
                                      cdusuario = e.cdusuario,
                                      dscondicion = e.dscondicion,

                                  }).ToListAsync(cancellationToken);

                var Doctors = await (from a in _context.Peoples
                                     where a.cdtipo == TipoPersona.Doctor
                                     select new PeopleDTO()
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
            catch (Exception ex)
            {
                throw new ValidationException("No se pudo listar a los pacientes, Error:" + ex.Message);
            }

        }
    }
}
