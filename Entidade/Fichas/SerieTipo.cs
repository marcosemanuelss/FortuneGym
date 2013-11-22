using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Db;
using Entidade.Exercicios;

namespace Entidade.Fichas
{
    [Serializable]
    public class SerieTipo
    {
        [Coluna("ID_ACADEMIA")]
        public int CodigoAcademia { get; set; }

        [Coluna("ID_SERIE_TIPO")]
        public int Codigo { get; set; }

        [Coluna("DS_NOME")]
        public string Nome { get; set; }

        [Coluna("IN_ATIVO")]
        public bool Ativo { get; set; }

        public List<ExercicioCategoria> Categorias { get; set; }

        public List<ExercicioFichaGrid> Exercicios { get; set; }
    }
}
