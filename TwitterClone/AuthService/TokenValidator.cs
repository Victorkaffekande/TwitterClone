using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AuthService;

public class TokenValidator : ITokenValidator
{
    private readonly IConfiguration _configuration;

    public TokenValidator(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public bool ValidateToken(string token)
    {
        var tokenHander = new JwtSecurityTokenHandler();
        var validtionParameters = GetTokenValidationParameters();

        SecurityToken validToken;
        tokenHander.ValidateToken(token, validtionParameters, out validToken);
        return true;
    }

    private TokenValidationParameters GetTokenValidationParameters()
    {
        var key = _configuration.GetSection("JwtKey").Value;
        return new TokenValidationParameters()
        {
            ValidateLifetime = false, // Because there is no expiration in the generated token
            ValidateAudience = false, // Because there is no audiance in the generated token
            ValidateIssuer = false, // Because there is no issuer in the generated token
            IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)) // The same key as the one that generate the token
        };
    }
    
}