using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Persistencia.Db
{
    public class RequeridoRange :ValidationAttribute
    {

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="_ruleSet"></param>
        /// <param name="_Resource"></param>
        /// <param name="_idResource"></param>
        public RequeridoRange(String _ruleSet,Int32 _inicial,Int32 _fim, String _Resource, String _idResource)
        {

        }

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
