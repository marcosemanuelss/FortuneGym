using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seguranca
{

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class PermissaoAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string siglaTransacao;

        // This is a positional argument
        public PermissaoAttribute(bool necessitaAutenticacao)
            : this(null, necessitaAutenticacao)
        {

        }

        public PermissaoAttribute(string siglaTransacao) : this(siglaTransacao, true)
        {
        }

        public PermissaoAttribute(string siglaTransacao, bool necessitaAutenticacao)
        {
            this.siglaTransacao = siglaTransacao;
            this.NecessitaAutenticacao = necessitaAutenticacao;
        }

        public string SiglaTransacao
        {
            get { return siglaTransacao; }
        }

        public bool NecessitaAutenticacao { get; set; }
    }

}