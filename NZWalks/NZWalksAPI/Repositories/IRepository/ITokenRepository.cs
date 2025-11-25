using Microsoft.AspNetCore.Identity;

namespace NZWalksAPI.Repositories.IRepository
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user,List<String> Roles);
    }
}
