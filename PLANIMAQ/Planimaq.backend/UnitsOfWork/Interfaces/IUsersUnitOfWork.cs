using Microsoft.AspNetCore.Identity;
using Planimaq.Shared.DTOs;
using Planimaq.Shared.Entities;

namespace Planimaq.backend.UnitsOfWork.Interfaces
{
    public interface IUsersUnitOfWork
    {
        Task<SignInResult> LoginAsync(LoginDTO model);

        Task LogoutAsync();

        Task<User> GetUserAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);
        Task<User> GetUserAsync(Guid userId);

        Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword);

        Task<IdentityResult> UpdateUserAsync(User user);


    }
}
