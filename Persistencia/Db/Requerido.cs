﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Persistencia.Db
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class Requerido : ValidationAttribute
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


        #region "Construtor"
            /// <summary>
            /// Construtor
            /// </summary>
            public Requerido(String _ruleSet, String _Resource, String _idResource)
            {
                this._rule = _ruleSet;
                this._resourc = _Resource;
                this._idresc = _idResource;
            }
        #endregion


     
        /// <summary>
        /// 
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
