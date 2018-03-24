using System.Collections.Generic;
using System.Security.Claims;

namespace DefaultProject.Domain.Services
{
	
	public interface IJwtService
	{
		string GenerateToken(IEnumerable<Claim> claims);
	}
	
}