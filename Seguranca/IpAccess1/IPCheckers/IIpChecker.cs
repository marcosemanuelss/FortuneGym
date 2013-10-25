using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIC.Seguranca.IpAccess.IPCheckers
{
	public interface IIpChecker
	{
		bool CanBlockIp(string ipAddress);
	}
}
