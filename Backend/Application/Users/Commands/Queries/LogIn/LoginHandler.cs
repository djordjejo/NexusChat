using Domain.Interfaces;
using Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.Queries.LogIn
{
    public class LoginHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public LoginHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<LoginResult> HandleLogin(
            LoginQuery query,
            CancellationToken cancellationToken
        )
        {
            var user = await unitOfWork.Users.GetUserByEmail(query.Email);
            if (user == null)
                throw new Exception("Pogrešan email ili lozinka");

            bool isValid = BCrypt.Net.BCrypt.Verify(query.Password, user.PasswordHash);
            if (!isValid)
                throw new Exception("Pogrešan email ili lozinka");

            
            var token = ""; // TODO

            return new LoginResult
            {
                Token = token,
                Username = user.Username,
                UserId = user.Id
            };
        }
    }
}
