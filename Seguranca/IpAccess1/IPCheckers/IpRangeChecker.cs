using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIC.Entidade;

namespace SIC.Seguranca.IpAccess.IPCheckers
{
	public class IpRangeChecker : IIpChecker
	{
		public string[] IpRanges { get; set; }
        public IP.Acesso Access { get; set; }

        public IpRangeChecker(string value, IP.Acesso access)
		{
			this.IpRanges = value.Split(',');
			this.Access = access;
		}

		#region IIpChecker Members

		public bool CanBlockIp(string ipAddress)
		{
			bool result = false;
			foreach (string ipRange in IpRanges)
			{
				string[] ipValues = ipRange.Split(';');
                if (this.Access == IP.Acesso.Granted)
				{
					if ((IpCompare.IsGreaterOrEqual(ipAddress, ipValues[0])) &&
							(IpCompare.IsLessOrEqual(ipAddress, ipValues[1])))
					{
						result = false;
						break;
					}
					else
					{
						result = true;
					}
				}
                else if (this.Access == IP.Acesso.Denied)
				{
					if ((IpCompare.IsGreaterOrEqual(ipAddress, ipValues[0])) &&
							(IpCompare.IsLessOrEqual(ipAddress, ipValues[1])))
					{
						result = true;
						break;
					}
					else
					{
						result = false;
					}
				}
			}

			return result;
		}

		#endregion
	}
}
