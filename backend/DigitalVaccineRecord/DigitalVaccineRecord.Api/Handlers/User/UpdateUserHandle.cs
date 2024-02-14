using DigitalVaccineRecord.Api.Commands.User;
using DigitalVaccineRecord.Api.Notifications;
using DigitalVaccineRecord.Core.Interfaces;
using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Handlers.User
{
    public class UpdateUserHandle : IRequestHandler<UpdateUserRequest, UserModel>
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        public UpdateUserHandle(IMediator mediator, IUserService service)
        {
            this._mediator = mediator;
            this._userService = service;
        }

        public async Task<UserModel> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var user = request.ConvertRequestToUserModel();
            //try
            //{
            _userService.Edit(user);

            await _mediator.Publish(new UserUpdatedNotification(user));

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
