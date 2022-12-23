using System.Threading.Tasks;

namespace Nofity.Core.Services
{
    public interface IAccountService
    {
        Task CreateAccount(string email, string password);
    }
}
