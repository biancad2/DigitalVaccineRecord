using DigitalVaccineRecord.Api.Commands.User;
using DigitalVaccineRecord.Api.Notifications;
using DigitalVaccineRecord.Core.Interfaces;
using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Handlers.User
{
    public class GetUserCommandHandler : IRequestHandler<GetUserCommand, UserModel>
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        public GetUserCommandHandler(IMediator mediator, IUserService service)
        {
            this._mediator = mediator;
            this._userService = service;
        }

        public async Task<UserModel> Handle(GetUserCommand request, CancellationToken cancellationToken)
        {
            var user = _userService.Get(request.Id);

            return await Task.FromResult(user);
        }
    }
}
