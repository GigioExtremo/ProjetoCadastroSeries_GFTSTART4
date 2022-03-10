using ProjetoCadastroSeries.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCadastroSeries.Classes
{
    public class SerieGenerator
    {
        public static Serie GeraSerie()
        {
            Random random = new Random();
            return new Serie("Série num_" + random.Next(0, 99999999).ToString(),
                EscolheGeneros(random.Next(1, 4)),
                "Descrição da série ",
                (ushort) random.Next(1920,2022));
        }

        public static List<Genero> EscolheGeneros(int qtdGeneros)
        {
            Array values = Enum.GetValues(typeof(Genero));

            HashSet<Genero> set = new HashSet<Genero>();

            Random random = new Random();
            

            while (set.Count < qtdGeneros)
            {
                var genero = (Genero)values.GetValue(random.Next(values.Length));
                set.Add(genero);
            }

            return new List<Genero>(set);
            
        }
    }
}
