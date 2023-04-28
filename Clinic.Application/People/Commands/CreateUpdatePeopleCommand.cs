using MediatR;

namespace Clinic.Application.People.Commands
{
    public class CreateUpdatePeopleCommand : IRequest
    {
    }

    public class CreateUpdatePeopleCommandHandler : IRequestHandler<CreateUpdatePeopleCommand>
    {
        public async Task<Unit> Handle(CreateUpdatePeopleCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
