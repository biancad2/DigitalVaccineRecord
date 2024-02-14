using DigitalVaccineRecord.Api.Commands.User;
using DigitalVaccineRecord.Api.Notifications;
using DigitalVaccineRecord.Core.Interfaces;
using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Handlers.User
{
    public class GetAllHandle : IRequestHandler<GetAllUserRequest, List<UserModel>>
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        public GetAllHandle(IMediator mediator, IUserService service)
        {
            this._mediator = mediator;
            this._userService = service;
        }

        public async Task<List<UserModel>> Handle(GetAllUserRequest request, CancellationToken cancellationToken)
        {
            //try
            //{
            var users = _userService.GetAll();

            //await _mediator.Publish(new UserUpdatedNotification(user));

            return await Task.FromResult(users);
            //}
            //catch (Exception ex)
            //{
            //await _mediator.Publish(new UserCreatedNotification(user));
            //await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
            //return await Task.FromResult("Error");
        }
    }
}
