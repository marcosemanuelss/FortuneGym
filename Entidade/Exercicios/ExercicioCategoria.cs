using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Db;

namespace Entidade.Exercicios
{
    [Serializable]
    public class ExercicioCategoria
    {
        [Coluna("ID_ACADEMIA")]
        public int CodigoAcademia { get; set; }

        [Coluna("ID_EXERCICIO_CAT")]
        public int Codigo { get; set; }

        [Coluna("DS_CATEGORIA")]
        public string Descricao { get; set; }

        [Coluna("IN_ATIVO")]
        public bool Ativo { get; set; }
    }
}
