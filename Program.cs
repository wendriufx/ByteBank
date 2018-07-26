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

        public static bool AppLigado = true;

        static void Main(string[] args)
        {

            while (AppLigado)
            {
                MenuPrincipal();
            }

            //AdicionaAcoes();

            Console.ReadLine();
        }


        #region Funcoes de Menu

        public static void MenuAcoes()
        {

            Console.Clear();

            Console.WriteLine("--------------------------------");
            Console.WriteLine("1) Visualizar todas Ações");
            Console.WriteLine("2) Cadastrar nova Ação");
            Console.WriteLine("3) Voltar");

            var decisao = Console.ReadLine();

            switch (decisao)
            {

                case "1":
                    ExibeAcoes();
                    break;
                case "2":
                    AdicionaAcoes();
                    break;
                case "3":
                    MenuPrincipal();
                    break;

                default:
                    Console.WriteLine("Escolha uma das opções");
                    break;               

            }



        }

        public static void MenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("--------------------------------");
            Console.WriteLine("1) Ações");
            Console.WriteLine("2) Clientes");
            Console.WriteLine("9) Sair");

            var decisao = Console.ReadLine();

            switch (decisao)
            {

                case "1":
                    MenuAcoes();
                    break;
                case "2":
                    MenuCliente();
                    break;
                case "9":
                    AppLigado = false;
                    break;

                default:
                    Console.WriteLine("Escolha uma das opções");
                    Console.ReadLine();
                    break;

            }


        }

        public static void MenuCliente()
        {
            
        }

        #endregion


        #region Funcoes do Banco de Dados

        #region Acoes

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

            MenuAcoes();

        }

        #endregion



        #endregion

    }
}
