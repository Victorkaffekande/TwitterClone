using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationService.Services;

public class JwtTokenService
{
    private readonly IConfiguration _configuration;  
  
    public JwtTokenService(IConfiguration configuration)  
    {  
        _configuration = configuration;  
    }

    public AuthenticationToken CreateToken()
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Secrets:jwtSecret"]));
        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim("scope", "timeline.read"),
            new Claim("scope", "timeline.write"),
            new Claim("scope", "tweet.read"),
            new Claim("scope", "tweet.write")
            //could add claims for user information if we had users (for example id)
        };
        var tokenOptions = new JwtSecurityToken(signingCredentials: signingCredentials, claims: claims);

        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        var authToken = new AuthenticationToken
        {
            Value = tokenString
        };

        return authToken;
    }
}