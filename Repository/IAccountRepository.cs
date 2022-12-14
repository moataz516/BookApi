using Book.Models;
using Microsoft.AspNetCore.Identity;

namespace Book.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel model);
        Task<string> LoginAsync(SignInModel model);
    }
}
