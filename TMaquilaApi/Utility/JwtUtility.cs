using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace TMaquilaApi.Utility
{
    public class JwtUtility
    {
        public static ClaimsPrincipal? GetClaimsFromJwt(HttpContext httpContext)
        {
            // Extract the Authorization header
            var authHeader = httpContext.Request.Headers["Authorization"].FirstOrDefault();

            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
                return null;

            var token = authHeader.Substring("Bearer ".Length).Trim();

            var tokenHandler = new JwtSecurityTokenHandler();

            // Validate and decode the token
            if (tokenHandler.CanReadToken(token))
            {
                var jwtToken = tokenHandler.ReadJwtToken(token);

                // Extract claims
                var claims = new ClaimsPrincipal(new ClaimsIdentity(jwtToken.Claims));
                
                var stringBuilder = new System.Text.StringBuilder();
                foreach (var claim in claims.Claims)
                {
                    stringBuilder.AppendLine($"{claim.Type}: {claim.Value}");
                }

                var claimsStr =  stringBuilder.ToString().Trim();
                return claims;
            }

            return null;
        }

        public static string? GetUserIdFromToken(HttpContext httpContext)
        {
            var claims = GetClaimsFromJwt(httpContext);
            return claims?.FindFirst("sub")?.Value;
        }

        public static string? GetEmailFromToken(HttpContext httpContext)
        {
            var claims = GetClaimsFromJwt(httpContext);
            return claims?.FindFirst("email")?.Value;
        }
    }
}