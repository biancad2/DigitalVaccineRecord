using DigitalVaccineRecord.Api.Commands.User;
using DigitalVaccineRecord.Api.Notifications;
using DigitalVaccineRecord.Core.Interfaces;
using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Handlers.User
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, UserModel>
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        public AddUserCommandHandler(IMediator mediator, IUserService service)
        {
            this._mediator = mediator;
            this._userService = service;
        }

        public async Task<UserModel> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = request.ConvertRequestToUserModel();
            //try
            //{
            _userService.Add(user);

            await _mediator.Publish(new UserCreatedNotification(user));

            return await Task.FromResult(user);
            //}
            //catch (Exception ex)
            //{
            //await _mediator.Publish(new UserCreatedNotification(user));
            //await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
            //return await Task.FromResult("Error");
        }
    }
}
