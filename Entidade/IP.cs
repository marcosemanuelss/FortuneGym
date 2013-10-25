using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade
{
    //[Serializable]
    //[Tabela("T06_IP")]
    public  class IP
    {
    //    [Coluna("CD_IP", true)]
    //    [UsarNo(UsarNoAttribute.EnumUsarEm.Alteracao)]
        public int Codigo { get; set; }
        
        public string Valor { get; set; }
    
        public bool DNS { get; set; }
    
        public Acesso AcessoIp { get; set; }

        public enum Acesso : int
        {
            Granted = 1,
            Denied = 2
        }
    }

    
}
