using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Db;

namespace Entidade.Exercicios
{
    [Serializable]
    public class ExercicioGrid : Exercicio
    {
        [Coluna("DS_CATEGORIA")]
        public string Categoria { get; set; }
    }
}
