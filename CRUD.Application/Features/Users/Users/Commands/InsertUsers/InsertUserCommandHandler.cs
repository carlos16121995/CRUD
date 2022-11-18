using MediatR;

namespace CRUD.Application.Features.Users.Users.Commands.InsertUsers
{
    using CRUD.Domain.Entities.Users;
    using CRUD.Infrastructure.Persistence;
    using CRUD.Infrastructure.Repositories;

    /// <summary>
    /// 
    /// </summary>
    public class InsertUserCommandHandler : IRequestHandler<InsertUserCommand, InsertUserCommandResponse>
    {
        private readonly Context _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public InsertUserCommandHandler(Context context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<InsertUserCommandResponse> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var id = await _context.InsertAsync<User, Guid>(new User()
                {
                    Name = request.Name,
                    BirthDate = request.BirthDate,
                    Gender = request.Gender,
                    Activated = request.Activated,
                });

                return new()
                {
                    Id = id
                };
            }
            catch (Exception ex) { throw new Exception(); } //TODO: Menasgem de erro
        }
    }
}
