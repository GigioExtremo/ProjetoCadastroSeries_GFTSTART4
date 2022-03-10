using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoCadastroSeries.Enums;

namespace ProjetoCadastroSeries.Classes
{
    public class Serie
    {
        public uint Id { get; private set; }
        public string Titulo { get; private set; }
        public List<Genero> Generos { get; private set; }
        public string Descricao { get; private set; }
        public ushort AnoTransmissaoOriginal { get; private set; }
        public bool Excluido { get; private set; }

        public Serie()
        {

        }

        public Serie(string titulo, List<Genero> generos, string descricao, ushort anoTransmissaoOriginal)
        {
            this.Titulo = titulo;
            this.Generos = generos;
            this.Descricao = descricao;
            this.AnoTransmissaoOriginal = anoTransmissaoOriginal;
        }

        public override string ToString()
        {
            var excluido = this.Excluido ? "Sim" : "Não";
            var strRetorno = "Série:\n" +
            "{\n" +
            $"  'Id': {this.Id},\n" +
            $"  'Título': {this.Titulo},\n" +
            "  'Gêneros': [\n" +
            $"\t{string.Join(",\n\t", this.Generos)}\n" +
            "  ]\n," +
            $"  'Descrição': {this.Descricao},\n" +
            $"  'Ano Transmissão Original': {this.AnoTransmissaoOriginal},\n" +
            $"  'Excluído?': {excluido}\n" +
            "}";

            return strRetorno;
        }

        public void SetId(uint id)
        {
            this.Id = id;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }

        internal void Atualiza(Serie novaEntidade)
        {
            this.Titulo = novaEntidade.Titulo;
            this.Generos = novaEntidade.Generos;
            this.Descricao = novaEntidade.Descricao;
            this.AnoTransmissaoOriginal = novaEntidade.AnoTransmissaoOriginal;
        }
    }
}
