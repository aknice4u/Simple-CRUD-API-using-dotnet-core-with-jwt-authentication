using DotNetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAPI.jwtAut
{
	public interface IJWTusers
	{
		string Authentication(string username, string password);
	}
}
