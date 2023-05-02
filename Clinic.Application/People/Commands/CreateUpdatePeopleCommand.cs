using Clinic.Application.Enum;
using Clinic.Application.Interfaces;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Clinic.Application.People.Commands
{
    public class CreateUpdatePeopleCommand : IRequest<bool>
    {
        public int nmid { get; set; }
        public string cddocumento { get; set; }
        public string dsnombres { get; set; }
        public string dsapellidos { get; set; }
        public DateTime fenacimiento { get; set; }
        public string cdtipo { get; set; }
        public string cdgenero { get; set; }
        public DateTime feregistro { get; set; }
        public DateTime febaja { get; set; }
        public string cdusuario { get; set; }
        public string dsdireccion { get; set; }
        public string dsphoto { get; set; }
        public string cdtelefono_fijo { get; set; }
        public string cdtelefono_movil { get; set; }
        public string dsemail { get; set; }
        public int dmid_medicotra { get; set; }
        public string dseps { get; set; }
        public string dsarl { get; set; }
        public string dscondicion { get; set; }
    }

    public class CreateUpdatePeopleCommandHandler : IRequestHandler<CreateUpdatePeopleCommand, bool>
    {
        private readonly IClinicDbContext _context;

        public CreateUpdatePeopleCommandHandler(IClinicDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateUpdatePeopleCommand request, CancellationToken cancellationToken)
        {
            bool accion = false;

            try
            {
                var People = await (from e in _context.Peoples
                                    where e.nmid == request.nmid
                                    select new Personas()
                                    {
                                        nmid = e.nmid,
                                        cddocumento = e.cddocumento,
                                        dsnombres = e.dsnombres,
                                        dsapellidos = e.dsapellidos,
                                        fenacimiento = e.fenacimiento,
                                        cdtipo = e.cdtipo,
                                        cdgenero = e.cdgenero,
                                        feregistro = e.feregistro,
                                        febaja = e.febaja,
                                        cdusuario = e.cdusuario,
                                        dsdireccion = e.dsdireccion,
                                        dsphoto = e.dsphoto,
                                        cdtelefono_fijo = e.cdtelefono_fijo,
                                        cdtelefono_movil = e.cdtelefono_movil,
                                        dsemail = e.dsemail,
                                   
                                    }).FirstOrDefaultAsync(cancellationToken);

                var Patient = await (from a in _context.Patients 
                                    where a.nmid_persona == request.nmid
                                    select new Pacientes()
                                    {
                                        nmid = a.nmid,
                                        nmid_persona = a.nmid_persona,
                                        nmid_medicotra = a.nmid_medicotra,
                                        dseps = a.dseps,
                                        dsarl = a.dsarl,
                                        feregistro = a.feregistro,
                                        febaja = a.febaja,
                                        cdusuario = a.cdusuario,
                                        dscondicion = a.dscondicion

                                    }).FirstOrDefaultAsync(cancellationToken);

                if (People == null)
                {
                    Personas entity = new Personas
                    {
                        nmid = request.nmid,
                        cddocumento = request.cddocumento,
                        dsnombres = request.dsnombres,
                        dsapellidos = request.dsapellidos,
                        fenacimiento = request.fenacimiento,
                        cdtipo = request.cdtipo,
                        cdgenero = request.cdgenero,
                        feregistro = request.feregistro,
                        febaja = request.febaja,
                        cdusuario = request.cdusuario,
                        dsdireccion = request.dsdireccion,
                        dsphoto = request.dsphoto,
                        cdtelefono_fijo = request.cdtelefono_fijo,
                        cdtelefono_movil = request.cdtelefono_movil,
                        dsemail = request.dsemail,
                    };

                    _context.Peoples.Add(entity);

                    await _context.SaveChangesAsync(cancellationToken);

                    if (request.cdtipo == TipoPersona.Paciente && Patient == null)
                    {
                        Pacientes entityPacientes = new Pacientes
                        {
                            nmid_persona = request.nmid,
                            nmid_medicotra = request.dmid_medicotra,
                            dseps = request.dseps,
                            dsarl = request.dsarl,
                            feregistro = request.feregistro,
                            febaja = request.febaja,
                            cdusuario = request.cdusuario,
                            dscondicion = request.dscondicion
                        };

                        _context.Patients.Add(entityPacientes);

                        await _context.SaveChangesAsync(cancellationToken);
                    }

                    accion = true;

                }
                else
                {
                    People.cddocumento = request.cddocumento;
                    People.dsnombres = request.dsnombres;
                    People.dsapellidos = request.dsapellidos;
                    People.fenacimiento = request.fenacimiento;
                    People.cdgenero = request.cdgenero;
                    People.febaja = request.febaja;
                    People.cdusuario = request.cdusuario;
                    People.dsdireccion = request.dsdireccion;
                    People.dsphoto = request.dsphoto;
                    People.cdtelefono_fijo = request.cdtelefono_fijo;
                    People.cdtelefono_movil = request.cdtelefono_movil;
                    People.dsemail = request.dsemail;

                    if (People.cdtipo == TipoPersona.Paciente)
                    {
                        Patient.nmid_medicotra = request.dmid_medicotra;
                        Patient.dseps = request.dseps;
                        Patient.dsarl = request.dsarl;
                        Patient.feregistro = request.feregistro;
                        Patient.febaja = request.febaja;
                        Patient.cdusuario = request.cdusuario;
                        Patient.dscondicion = request.dscondicion;

                        _context.Patients.Update(Patient);

                        await _context.SaveChangesAsync(cancellationToken);
                    }

                    _context.Peoples.Update(People);

                    await _context.SaveChangesAsync(cancellationToken);

                    accion = true;
                }

                return accion;
            }
            catch (Exception ex)
            {
                throw new ValidationException("No se pudo insertar o actualizar el registro, Error:" + ex.Message);
            }
        }
    }
}
