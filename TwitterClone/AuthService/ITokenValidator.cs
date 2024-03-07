namespace AuthService;

public interface ITokenValidator
{
    public bool ValidateToken(string token);
}