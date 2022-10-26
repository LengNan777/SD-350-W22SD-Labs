object API =
{
    "TwoFactorAuthentication": true,
    "IsAdmin": true
}

public abstract class User
{
    private string Password;

    public abstract void PasswordHash(string Password);
}

public class AuthorizedUser : User
{
    public override void PasswordHash(string Password)
    {
        Console.WriteLine($"Password of AuthorizedUser has been hashed.");
    }
}

public class Administrator : User
{
    public override void PasswordHash(string Password)
    {
        Console.WriteLine("Password of Administrator has been hashed.")
    }
}

public abstract class System
{
    protected abstract User CreateUser(string type);
}

public class TwoFactorRequiredSystem : System
{
    protected override User CreateUser(string type)
    {
        User user;
        if(API.TwoFactorAuthentication == true && API.IsAdmin == true)
        {
            user = new Administrator();
        }else if(API.TwoFactorAuthentication == true)
        {
            user = new AuthorizedUser();
        }
        else
        {
            throw new Exception();
        }
        return user;
    }
}

public class TwoFactorNotRequiredSystem : System
{
    protected override User CreateUser(string type)
    {
        User user;
        if (API.TwoFactorAuthentication == true && API.IsAdmin == true)
        {
            user = new Administrator();
        }
        else if (API.TwoFactorAuthentication == true)
        {
            user = new AuthorizedUser();
        }
        return user;
    }