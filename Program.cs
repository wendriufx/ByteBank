using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_ByteBank
{
    public class Program
    {
        public static string stringDeConexao = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=app;Integrated Security=True;Pooling=False";

        static void Main(string[] args)
        {

            AdicionaAcoes();

            Console.ReadLine();
        }

        private static void ExibeAcoes()
        {
            using (SqlConnection conexaoComOBanco = new SqlConnection(stringDeConexao))
            {
                conexaoComOBanco.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Acoes", conexaoComOBanco);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.Write("IDAcao: ");
                        Console.Write(reader["IDAcao"]);

                        Console.WriteLine("");

                        Console.Write("TipoAcao: ");
                        Console.Write(reader["TipoAcao"]);

                        Console.WriteLine("");

                    }
                }
                

            }
        }

        private static void AdicionaAcoes()
        {
            using (SqlConnection conexaoComOBanco = new SqlConnection(stringDeConexao))
            {
                conexaoComOBanco.Open();

                var novaAcao = Console.ReadLine();
                
                SqlCommand insertCommand = new SqlCommand("INSERT INTO Acoes (TipoAcao) VALUES (@parametroNovaAcao)", conexaoComOBanco);
                insertCommand.Parameters.Add(new SqlParameter("parametroNovaAcao", novaAcao));

                insertCommand.ExecuteNonQuery();


                Console.WriteLine("Nova acao incluida");
                
            }

            ExibeAcoes();
        }
    }
}
