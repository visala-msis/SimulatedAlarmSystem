namespace SimulatedAlarmSystem.BL.Services
{
	using System;
	using System.IdentityModel.Tokens.Jwt;
	using System.Text;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
	using SimulatedAlarmSystem.BL.Interfaces;

	public class TokenService : ITokenService
	{
		private readonly string _secretKey;
		private readonly string _issuer;
		private readonly string _audience;

		public TokenService(IConfiguration configuration)
		{
			// Retrieve the values from appsettings.json
			_secretKey = configuration["JwtSettings:SecretKey"];
			_issuer = configuration["JwtSettings:Issuer"];
			_audience = configuration["JwtSettings:Audience"];
		}

		public string GenerateToken(string username)  
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var tokenDescriptor = new JwtSecurityToken(
				_issuer,
				_audience,
				expires: DateTime.Now.AddHours(1), // Set expiration to 1 hour
				signingCredentials: credentials
			);

			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.WriteToken(tokenDescriptor);

			return token;
		}

		public bool ValidateToken(string token)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			try
			{
				var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
				var validationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidIssuer = _issuer,
					ValidAudience = _audience,
					IssuerSigningKey = securityKey,
					ClockSkew = TimeSpan.Zero // No tolerance for token expiration
				};

				tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);

				return true;
			}
			catch
			{
				return false;
			}
		}
	}

}
