using AutoMapper;
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
        public int NMid { get; set; }
        public string CDdocumento { get; set; }
        public string DSnombres { get; set; }
        public string DSapellidos { get; set; }
        public DateTime FEnacimiento { get; set; }
        public string CDtipo { get; set; }
        public string CDgenero { get; set; }
        public DateTime FEregistro { get; set; }
        public DateTime FEbaja { get; set; }
        public string CDusuario { get; set; }
        public string DSdireccion { get; set; }
        public string DSphoto { get; set; }
        public string CDtelefono_fijo { get; set; }
        public string CDtelefono_movil { get; set; }
        public string DSemail { get; set; }
        public int DMid_medicotra { get; set; }
        public string DSeps { get; set; }
        public string DSarl { get; set; }
        public string DScondicion { get; set; }
    }

    public class CreateUpdatePeopleCommandHandler : IRequestHandler<CreateUpdatePeopleCommand, bool>
    {
        private readonly IClinicDbContext _context;

        public CreateUpdatePeopleCommandHandler(
            IClinicDbContext context,
            IMapper mapper)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateUpdatePeopleCommand request, CancellationToken cancellationToken)
        {
            bool accion = false;

            try
            {
                var People = await (from e in _context.Peoples
                                    where e.nmid == request.NMid
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
                                    where a.nmid_persona == request.NMid
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
                        nmid = request.NMid,
                        cddocumento = request.CDdocumento,
                        dsnombres = request.DSnombres,
                        dsapellidos = request.DSapellidos,
                        fenacimiento = request.FEnacimiento,
                        cdtipo = request.CDtipo,
                        cdgenero = request.CDgenero,
                        feregistro = request.FEregistro,
                        febaja = request.FEbaja,
                        cdusuario = request.CDusuario,
                        dsdireccion = request.DSdireccion,
                        dsphoto = request.DSphoto,
                        cdtelefono_fijo = request.CDtelefono_fijo,
                        cdtelefono_movil = request.CDtelefono_movil,
                        dsemail = request.DSemail,
                    };

                    _context.Peoples.Add(entity);

                    await _context.SaveChangesAsync(cancellationToken);

                    if (request.CDtipo == TipoPersona.Paciente && Patient == null)
                    {
                        Pacientes entityPacientes = new Pacientes
                        {
                            nmid_persona = request.NMid,
                            nmid_medicotra = request.DMid_medicotra,
                            dseps = request.DSeps,
                            dsarl = request.DSarl,
                            feregistro = request.FEregistro,
                            febaja = request.FEbaja,
                            cdusuario = request.CDusuario,
                            dscondicion = request.DScondicion
                        };

                        _context.Patients.Add(entityPacientes);

                        await _context.SaveChangesAsync(cancellationToken);
                    }

                    accion = true;

                }
                else
                {
                    People.cddocumento = request.CDdocumento;
                    People.dsnombres = request.DSnombres;
                    People.dsapellidos = request.DSapellidos;
                    People.fenacimiento = request.FEnacimiento;
                    People.cdgenero = request.CDgenero;
                    People.febaja = request.FEbaja;
                    People.cdusuario = request.CDusuario;
                    People.dsdireccion = request.DSdireccion;
                    People.dsphoto = request.DSphoto;
                    People.cdtelefono_fijo = request.CDtelefono_fijo;
                    People.cdtelefono_movil = request.CDtelefono_movil;
                    People.dsemail = request.DSemail;

                    if (People.cdtipo == TipoPersona.Paciente)
                    {
                        Patient.nmid_medicotra = request.DMid_medicotra;
                        Patient.dseps = request.DSeps;
                        Patient.dsarl = request.DSarl;
                        Patient.feregistro = request.FEregistro;
                        Patient.febaja = request.FEbaja;
                        Patient.cdusuario = request.CDusuario;
                        Patient.dscondicion = request.DScondicion;

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
