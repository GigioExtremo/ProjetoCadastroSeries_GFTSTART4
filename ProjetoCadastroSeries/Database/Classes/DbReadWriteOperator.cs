using ProjetoCadastroSeries.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCadastroSeries.Classes
{
    public class DbReadWriteOperator
    {
        public static string GetJsonFromDB(string url)
        {
            try
            {
                if (!File.Exists(url))
                    File.Create(url);

                using var file = File.OpenText(url);
                return file.ReadToEnd();

            } catch
            {
                throw new JsonDBAccessException("Não foi possível acessar o banco de dados em JSON!");
            }

        }
        public static void OverWriteJsonDB(string url, string json)
        {
            try 
            {
                if (File.Exists(url))
                    File.Delete(url);

                using var file = File.CreateText(url);
                file.Write(json);
            }
            catch
            {
                throw new JsonDBAccessException("Não foi possível escrever no banco de dados em JSON!");
            }

        }
    }
}
