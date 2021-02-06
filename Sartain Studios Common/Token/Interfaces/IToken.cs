using SharedModels;

namespace Sartain_Studios_Common.Interfaces.Token
{
    public interface IToken
    {
        string GenerateToken(UserModel userModel = null);
        string GetUserIdFromAuthorizationToken(string authorizationToken);
    }
}