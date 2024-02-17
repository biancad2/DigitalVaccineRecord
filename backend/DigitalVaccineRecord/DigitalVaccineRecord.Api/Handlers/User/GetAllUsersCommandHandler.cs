using DigitalVaccineRecord.Api.Commands.User;
using DigitalVaccineRecord.Api.Notifications;
using DigitalVaccineRecord.Core.Interfaces;
using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Handlers.User
{
    public class GetAllUsersCommandHandler : IRequestHandler<GetAllUsersCommand, List<UserModel>>
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        public GetAllUsersCommandHandler(IMediator mediator, IUserService service)
        {
            this._mediator = mediator;
            this._userService = service;
        }

        public async Task<List<UserModel>> Handle(GetAllUsersCommand request, CancellationToken cancellationToken)
        {
            var users = await _userService.GetAllAsync();
            return users;
        }
    }
}
