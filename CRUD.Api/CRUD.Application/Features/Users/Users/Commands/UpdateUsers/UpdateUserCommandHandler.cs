using CRUD.Domain.Entities.Users;
using CRUD.Infrastructure.Persistence;
using CRUD.Infrastructure.Repositories;
using MediatR;

namespace CRUD.Application.Features.Users.Users.Commands.UpdateUsers
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly Context _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateUserCommandHandler(Context context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _context.UpdateAsync<User, Guid>((user) => user.Id.Equals(request.Id), (u) =>
                {
                    u.BirthDate = request.Data.BirthDate;
                    u.Name = request.Data.Name;
                    u.Gender = request.Data.Gender;
                    u.UpdatedAt = DateTime.UtcNow;
                    if (request.Data.Activated != u.Activated)
                        u.Inactivate();
                });

                return Unit.Value;
            }
            catch (Exception ex) { throw new Exception(); } // TODO: Mensagens
        }
    }
}
