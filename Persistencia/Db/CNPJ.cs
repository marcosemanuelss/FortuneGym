using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Persistencia.Db
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, Inherited = false, AllowMultiple = false)]    
    public class CNPJ:ValidationAttribute
    {
        #region "Privates"
            readonly String _rule;
            readonly String _resourc;
            readonly String _idresc;
        #endregion

        #region "Propriedades"
            public String RuleSet
            {
                get { return _rule; }
            }

            public String Resource
            {
                get { return _resourc; }
            }

            public String IDResource
            {
                get { return _idresc; }
            }
        #endregion


          /// <summary>
         /// Construtor
         /// </summary>
         /// <param name="_CPF"></param>
         public CNPJ(String _CNPJ)
         {

         }

        /// <summary>
        /// Logica de validação 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            bool result = true;
            return result;
        }
    }
}
