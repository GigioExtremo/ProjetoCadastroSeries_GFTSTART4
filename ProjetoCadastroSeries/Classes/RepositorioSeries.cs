using ProjetoCadastroSeries.Exceptions;
using ProjetoCadastroSeries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjetoCadastroSeries.Classes
{
    public class RepositorioSeries : IRepositorio<Serie>
    {
        private static List<Serie> _series;
        private RepositorioSeries()
        {
            
        }

        public static RepositorioSeries GetInstance()
        {
            if (_series == null)
            {
                _series = new List<Serie>();
            }
            

            return new RepositorioSeries();
        }

        public void Atualiza(uint id, Serie novaEntidade)
        {
            var idx = GetIndexSerie(id);
            if (idx == -1)
                throw new ArgumentOutOfRangeException("O Id não é válido!");

            novaEntidade.SetId(_series[idx].Id);
            _series[idx] = novaEntidade;

        }

        public void Cadastrar(Serie obj)
        {
            obj.SetId(ProximoId());
            _series.Add(obj);
        }

        public void Exclui(uint id)
        {
            var serie = ListarPorId(id);
            serie.Excluir();
        }

        private int GetIndexSerie(uint id)
        {
            int i = 0;
            foreach (var serie in _series)
            {
                if (serie.Id == id)
                    return i;
                i++;
            }

            return -1;
        }
        public Serie ListarPorId(uint id)
        {
            foreach (var serie in _series)
            {
                if (serie.Id == id)
                    return serie;
            }

            return null;
        }

        public List<Serie> ListarTodos(bool incluirExcluidos=false)
        {
            if (incluirExcluidos)
                return new List<Serie>(_series);
            else
            {
                var novaLista = new List<Serie>();
                foreach (var serie in _series)
                {
                    if (!serie.Excluido)
                        novaLista.Add(serie);
                }

                return novaLista;
            }
        }

        public List<Serie> ListarExluidos()
        {
            var novaLista = new List<Serie>();
            foreach (var serie in _series)
            {
                if (serie.Excluido)
                    novaLista.Add(serie);
            }

            return novaLista;       
        }

        public uint ProximoId()
        {
           return (uint) _series.Count();
        }
    }
}
