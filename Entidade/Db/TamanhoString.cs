using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Entidade.Db
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, Inherited = false, AllowMultiple = true)]    
    public class TamanhoString : ValidationAttribute
    {

        #region "Privates"
            readonly String _rule;
            readonly String _resourc;
            readonly String _idresc;
            readonly Int32 _tam;
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

            public Int32 Tamanho
            {
                get
                {
                    return _tam;
                }

            }
        #endregion


        /// <summary>
        /// Construtor TamanhoString
        /// </summary>
        /// <param name="_ruleSet"></param>
        /// <param name="_tamanho"></param>
        public TamanhoString(String _ruleSet,Int32 _tamanho,String _Resource,String _idResource)
        {
            this._rule = _ruleSet;
            this._resourc = _Resource;
            this._idresc = _idResource;
            this._tam = _tamanho;
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
