using CRUD.Domain.Infra.Exceptions;
using CRUD.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Application.Features.Users.Users.Commands.RemoveUsers
{
    /// <summary>
    /// 
    /// </summary>
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand>
    {
        private readonly Context _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public RemoveUserCommandHandler(Context context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Unit> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users.Include(u=> u.Addresses).FirstAsync(u => u.Id == request.Id, cancellationToken: cancellationToken);
                _context.Users.Remove(user);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex) { throw new CrudException("Falha ao remover usuários.", ex); }
        }
    }
}
