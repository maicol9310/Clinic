using AutoMapper;
using Clinic.Application.Enum;
using Clinic.Application.Interfaces;
using Clinic.Application.Models;
using Clinic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            var People = await (from e in _context.Peoples
                                join a in _context.Patients on e.nmid equals a.nmid_persona
                                where e.nmid == request.NMid
                                select new PeopleDTO()
                                {
                                                                   
                                }).FirstOrDefaultAsync(cancellationToken);

            var Peopl = await _context.Peoples
                //.Include(x => x.)
                .FirstOrDefaultAsync(x => x.nmid == request.NMid, cancellationToken);

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

            if (request.CDtipo == TipoPersona.Paciente)
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

            return true;
        }
    }
}
