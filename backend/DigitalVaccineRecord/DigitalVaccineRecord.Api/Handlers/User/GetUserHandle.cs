using DigitalVaccineRecord.Api.Commands.User;
using DigitalVaccineRecord.Api.Notifications;
using DigitalVaccineRecord.Core.Interfaces;
using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Handlers.User
{
    public class GetUserHandle : IRequestHandler<GetUserRequest, UserModel>
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        public GetUserHandle(IMediator mediator, IUserService service)
        {
            this._mediator = mediator;
            this._userService = service;
        }

        public async Task<UserModel> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            //try
            //{
            var user = _userService.Get(request.Id);

            //await _mediator.Publish(new UserCreatedNotification(user));

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
