using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace SIC.Seguranca.IpAccess.IPCheckers
{
    public class IpUtil
    {
        public static bool ValidarIp(params string[] ips)
        {
            IPAddress ipAddress = null;
            for (int i = 0; i < ips.Length; i++)
            {
                if (!IPAddress.TryParse(ips[i], out ipAddress))
                {
                    return false;
                }
                else if (ips[i] != ipAddress.ToString())
                {
                    return false;
                }
                
            }

            return true;
        }

    }
}
