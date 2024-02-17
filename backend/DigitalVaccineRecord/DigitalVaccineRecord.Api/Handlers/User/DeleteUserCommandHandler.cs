using DigitalVaccineRecord.Api.Commands.User;
using DigitalVaccineRecord.Api.Notifications;
using DigitalVaccineRecord.Core.Interfaces;
using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Handlers.User
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        public DeleteUserCommandHandler(IMediator mediator, IUserService service)
        {
            this._mediator = mediator;
            this._userService = service;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            //var user = request.ConvertRequestToUserModel();
            //try
            //{
            _userService.Delete(request.Id);

            //await _mediator.Publish(new UserDeletedNotification(user));

            return await Task.FromResult(true);
            //}
            //catch (Exception ex)
            //{
            //await _mediator.Publish(new UserCreatedNotification(user));
            //await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
            //return await Task.FromResult("Error");
        }
    }
}
