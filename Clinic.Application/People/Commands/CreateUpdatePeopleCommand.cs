﻿using AutoMapper;
using Clinic.Application.Interfaces;
using Clinic.Domain.Entities;
using MediatR;

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
            //var People = await _context.Peoples
            //    .FirstOrDefaultAsync(x => x.nmid == request.NMid, cancellationToken);

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

            return true;
        }
    }
}
