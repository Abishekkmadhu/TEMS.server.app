using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(string email, string password, string fullName);
        Task<string> LoginAsync(string email, string password);
    }
}
