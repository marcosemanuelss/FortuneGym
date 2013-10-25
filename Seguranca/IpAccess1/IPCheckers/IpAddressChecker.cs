using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using SIC.Entidade;

namespace SIC.Seguranca.IpAccess.IPCheckers
{
    public class IpAddressChecker : IIpChecker
    {
        private List<IP> ips = new List<IP>();

        public IpAddressChecker(int cdUsuario)
        {
            //ips = new Persistencia.PerUsuario().ObterIPs(cdUsuario);
        }

        #region IIpChecker Members

        public bool CanBlockIp(string ipAddress)
        {
            bool isBlock = true;
            foreach (var ip in ips)
            {
                string minValue = ip.Valor.Replace("*", "0");
                string maxValue = ip.Valor.Replace("*", "255");

                if (IpUtil.ValidarIp(minValue, maxValue))
                {
                    string newValue = string.Format("{0};{1}", minValue, maxValue);
                    var ipChecker = new IpRangeChecker(newValue, ip.AcessoIp);

                    if (!ipChecker.CanBlockIp(ipAddress))
                    {
                        isBlock = false;
                        break;
                    }
                }
                
            }

            return isBlock;
        }


        
        #endregion
    }
}
