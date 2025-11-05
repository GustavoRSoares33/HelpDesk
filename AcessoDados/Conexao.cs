using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace AcessoDados
{
    public static class Conexao
    {

        public static string GetConnectionString()
        {
            // Esta é uma "diretiva de compilação".
            // Se o código estiver sendo compilado para um projeto Android...
#if ANDROID
            // ...use a string de conexão com o IP especial do emulador.
            // Verifique se a palavra-passe aqui é a que acabou de definir
            return @"Server=10.0.2.2,1433;Database=projeto;User Id=pim_user;Password=Molodoy;TrustServerCertificate=True;";
#else
            // ...senão (para Desktop, Web, etc.), use a conexão padrão.
            return @"Server=GUSTAVO\SQLEXPRESS;Database=projeto;Trusted_Connection=True;TrustServerCertificate=True;";
            #endif
        }

        // Método que retorna uma nova conexão aberta
        public static SqlConnection GetConexao()
        {
            SqlConnection conexao = new SqlConnection(GetConnectionString());
            conexao.Open();
            return conexao;
        }
    }
}
