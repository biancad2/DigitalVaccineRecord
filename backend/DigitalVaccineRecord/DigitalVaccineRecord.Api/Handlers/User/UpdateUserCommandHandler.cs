using DigitalVaccineRecord.Api.Commands.User;
using DigitalVaccineRecord.Api.Notifications;
using DigitalVaccineRecord.Core.Interfaces;
using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Handlers.User
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserModel>
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        public UpdateUserCommandHandler(IMediator mediator, IUserService service)
        {
            this._mediator = mediator;
            this._userService = service;
        }

        public async Task<UserModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = request.ConvertRequestToUserModel();
            _userService.Edit(user);

            await _mediator.Publish(new UserUpdatedNotification(user));

            return await Task.FromResult(user);
        }
    }
}
