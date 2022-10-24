using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace NatureListService.Configurations {
    public class JwtConfiguration {
        public string? Issuer { get; init; }
        public string? Audience { get; init; }
        public string? Key { get; init; }
        public SymmetricSecurityKey SymmetricSecurityKey {
            get {
                return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key!));
            }
        }
        public double? TokenValidityInMinutes { get; init; }
        public JwtConfiguration() {

        }
    }
}
