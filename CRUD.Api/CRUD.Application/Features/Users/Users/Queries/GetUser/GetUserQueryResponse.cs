using CRUD.Application.Features.Users.Users.Commands.InsertUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.Features.Users.Users.Queries.GetUser
{
    public class GetUserQueryResponse : InsertUserCommand
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public bool Activated { get; set; }
    }
}
