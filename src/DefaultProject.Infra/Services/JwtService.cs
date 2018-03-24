using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using DefaultProject.Domain.Services;

namespace DefaultProject.Infra.Services
{
	public class JwtService : IJwtService
	{
		private readonly IConfiguration _config;
		public JwtService(IConfiguration configuration)
		{
			_config = configuration;
		}
		
		public string GenerateToken(IEnumerable<Claim> claims)
		{
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: _config["Token:Issuer"],
				audience: _config["Token:Issuer"],
				claims: claims,
				expires: DateTime.Now.AddMonths(1),
				signingCredentials: creds);
			
			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}