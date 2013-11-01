using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade.Db
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class ColunaAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string nomeColuna;

        readonly bool pk;

        public bool ChavePrimaria
        {
            get { return pk; }
        }

        // This is a positional argument
        public ColunaAttribute(string nomeColuna)
        {
            this.nomeColuna = nomeColuna;
        }

        public ColunaAttribute(string nomeColuna, bool pk)
        {
            this.nomeColuna = nomeColuna;
            this.pk = pk;
        }

        public string NomeColuna
        {
            get { return nomeColuna; }
        }

    }
}
