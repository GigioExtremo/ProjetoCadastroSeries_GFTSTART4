using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCadastroSeries.Interfaces
{
    internal interface IRepositorio<T>
    {
        public List<T> ListarTodos(bool incluirExcluidos=false);
        public void Cadastrar(T obj);
        public T ListarPorId(uint id);
        public void Exclui(uint id);
        public void Atualiza(uint id, T novaEntidade);
        public uint ProximoId();
    }
}
