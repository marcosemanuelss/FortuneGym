using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistencia.Db
{
    [AttributeUsage(AttributeTargets.Class , Inherited = false, AllowMultiple = false)]
    public sealed class TabelaAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string nomeTabela;

        // This is a positional argument
        public TabelaAttribute(string nomeTabela)
        {
            this.nomeTabela = nomeTabela;
        }

        public string NomeTabela
        {
            get { return nomeTabela; }
        }

    }
}
