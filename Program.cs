public abstract class Client
{
	protected string Username;
	protected string Email;
	protected string Gender;
	protected string Description = ¡°No Description¡±;

	public virtual string GetDescription();
}

public class User : Client
{
	public User()
    {
		Description = "Base-level User";
	}
}

public abstract class BadgeDecorator : Client
{
	public Client Client { get; set; }
	public abstract override string GetBadges();
}