using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RecruitmentPortal.Service.Helpers;

namespace RecruitmentPortal.API.Middlewares;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _secret;

    public JwtMiddleware(RequestDelegate next, IConfiguration config)
    {
        _next = next;
        _secret = config["Jwt:Key"] ?? ""; 

    }

    public async Task InvokeAsync(HttpContext context)
    {
        string? token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ")[1];

        if (!string.IsNullOrEmpty(token))
        {
            AttachUserToContext(context, token);
        }
        await _next(context);
    }
    
    private void AttachUserToContext(HttpContext context, string token)
    {
        try
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_secret);

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            JwtSecurityToken? jwtToken = (JwtSecurityToken)validatedToken;
            string? Email = jwtToken.Claims.First(x => x.Type == "email").Value;

            // user id into context
            context.Items["Email"] = Email;
        }
        catch
        {
            // Do nothing if JWT validation fails
        }
    }
}

