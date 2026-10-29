using DotnetNative.Core.Config;
using DotnetNative.Core.Errors;
using DotnetNative.Core.Security;
using DotnetNative.Modules.Base.Users;

namespace DotnetNative.Modules.Base.Auth;

public sealed class AuthService(IUserRepository users, JwtTokenService tokens, Settings settings)
{
    public async Task<Token> LoginAsync(string email, string password)
    {
        var user = await users.GetByEmailAsync(email);
        if (user is null || !PasswordHasher.Verify(password, user.HashedPassword))
            throw AppException.BadRequest("Incorrect email or password");
        if (!user.IsActive) throw AppException.BadRequest("Inactive user");

        return new Token(tokens.Create(user.Id, TimeSpan.FromMinutes(settings.AccessTokenExpireMinutes)));
    }

    public async Task<User> AuthenticateAsync(string? authorization)
    {
        const string scheme = "Bearer ";
        if (authorization is null || !authorization.StartsWith(scheme, StringComparison.OrdinalIgnoreCase))
            throw AppException.NotAuthenticated();

        var id = tokens.Validate(authorization[scheme.Length..].Trim()) ?? throw AppException.InvalidCredentials();
        return await users.GetByIdAsync(id) ?? throw AppException.InvalidCredentials();
    }
}
