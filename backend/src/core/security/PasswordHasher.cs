using BCryptNet = BCrypt.Net.BCrypt;

namespace DotnetNative.Core.Security;

public static class PasswordHasher
{
    public static string Hash(string password) =>
        BCryptNet.HashPassword(password, BCryptNet.GenerateSalt(12, 'b'));

    public static bool Verify(string password, string hash)
    {
        try
        {
            return BCryptNet.Verify(password, hash);
        }
        catch (Exception)
        {
            return false;
        }
    }
}
