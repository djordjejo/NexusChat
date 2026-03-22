using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.Queries.LogIn
{
    public class LoginQuery : IRequest<LoginResult>
    {
        public LoginQuery()
        {
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class LoginResult
    {
        public Guid UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
