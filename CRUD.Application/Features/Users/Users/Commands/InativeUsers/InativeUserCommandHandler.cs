using CRUD.Domain.Entities.Users;
using CRUD.Domain.Infra.Exceptions;
using CRUD.Infrastructure.Persistence;
using CRUD.Infrastructure.Repositories;
using MediatR;

namespace CRUD.Application.Features.Users.Users.Commands.InativeUsers
{
    /// <summary>
    /// 
    /// </summary>
    public class InativeUserCommandHandler : IRequestHandler<InativeUserCommand>
    {
        private readonly Context _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public InativeUserCommandHandler(Context context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Unit> Handle(InativeUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.GetDelete())
                    await _context.UpdateAsync<User, Guid>((user) => user.Id.Equals(request.Id), (u) =>
                    {
                        u.Delete();
                        u.Addresses.ToList().ForEach(a =>
                        {
                            a.Delete();
                        });
                    });

                else
                    await _context.UpdateAsync<User, Guid>((user) => user.Id.Equals(request.Id), (u) =>
                    {
                        u.Inactivate();
                        u.Addresses.ToList().ForEach(a =>
                        {
                            a.Inactivate();
                        });
                    });

                return Unit.Value;
            }
            catch (Exception ex) { throw new CrudException("Falha ao inativar usuários", ex); } 
        }
    }
}
