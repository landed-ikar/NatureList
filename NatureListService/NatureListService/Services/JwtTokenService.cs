using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NatureListService.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NatureListService.Services {
    public interface ITokenService {
        public abstract string CreateToken(IEnumerable<Claim> claims);
    }
    public static class JwtTokenExtensions {
        public static void AddJwtTokenServicee(this IServiceCollection services) {
            services.AddTransient<ITokenService, JwtTokenService>();
        }
    }
    public class JwtTokenService: ITokenService {
        readonly JwtConfiguration configuration;
        public JwtTokenService(IOptions<JwtConfiguration> configOption) {
            this.configuration = configOption.Value;
        }
        public string CreateToken(IEnumerable<Claim> claims) {
            var authSigningKey = configuration.SymmetricSecurityKey;
            var jwt = new JwtSecurityToken(
                    issuer: configuration.Issuer,
                    audience: configuration.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(
                        TimeSpan.FromMinutes(configuration.TokenValidityInMinutes!.Value)),
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

    }
}
