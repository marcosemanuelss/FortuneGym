using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistencia.Db
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class UsarNoAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly EnumUsarEm usarEm;

        // This is a positional argument
        public UsarNoAttribute(EnumUsarEm usarEm)
        {
            this.usarEm = usarEm;
        }

        public EnumUsarEm UsarEm
        {
            get { return usarEm; }
        }

        public bool UsarNaInsercao { get { return Convert.ToBoolean(usarEm & EnumUsarEm.Insercao); } }
        public bool UsarNaAlteracao { get { return Convert.ToBoolean(usarEm & EnumUsarEm.Alteracao); } }
        public bool UsarNaExclusao { get { return Convert.ToBoolean(usarEm & EnumUsarEm.Exclusao); } }

        [Flags]
        public enum EnumUsarEm
        {
            Nenhum = 0,
            Alteracao = 1,
            Insercao = 2,
            Exclusao = 4
        }
    }

}
