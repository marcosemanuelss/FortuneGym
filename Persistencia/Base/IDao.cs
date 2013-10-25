using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistencia.Base
{
    public interface IDao<T>
    {
        T Obter(int PK);
        List<T> ObterLista(T filtro);
        void Inserir(T registro);
        void Alterar(T registro);
        void Excluir(T registro);
    }
}
