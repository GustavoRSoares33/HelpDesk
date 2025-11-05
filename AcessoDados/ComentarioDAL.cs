using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoDados.Models;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using AcessoDados; // Para depuração

// A classe deve ser pública para ser acessível pelo HomeController.
public class ComentarioDAL
{
    /// <summary>
    /// Adiciona um novo comentário ao banco de dados.
    /// </summary>
    public bool Adicionar(Comentario comentario)
    {
        try
        {
            using (SqlConnection conexao = Conexao.GetConexao())
            {
                string sql = "INSERT INTO Comentario (id_Chamado, Autor, Texto, DataHora) VALUES (@idChamado, @autor, @texto, @dataHora)";
                using (SqlCommand cmd = new SqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@idChamado", comentario.Id_Chamado);
                    cmd.Parameters.AddWithValue("@autor", comentario.Autor);
                    cmd.Parameters.AddWithValue("@texto", comentario.Texto);
                    cmd.Parameters.AddWithValue("@dataHora", DateTime.Now);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Erro ao adicionar comentário: " + ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Lista todos os comentários de um chamado específico, do mais antigo para o mais novo.
    /// </summary>
    public List<Comentario> ListarPorChamado(int idChamado)
    {
        var comentarios = new List<Comentario>();
        try
        {
            using (SqlConnection conexao = Conexao.GetConexao())
            {
                string sql = "SELECT * FROM Comentario WHERE id_Chamado = @idChamado ORDER BY DataHora ASC";
                using (SqlCommand cmd = new SqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@idChamado", idChamado);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comentarios.Add(new Comentario
                        {
                            IdComentario = Convert.ToInt32(reader["idComentario"]),
                            Id_Chamado = Convert.ToInt32(reader["id_Chamado"]),
                            Autor = reader["Autor"].ToString(),
                            Texto = reader["Texto"].ToString(),
                            DataHora = Convert.ToDateTime(reader["DataHora"])
                        });
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Erro ao listar comentários: " + ex.Message);
        }
        return comentarios;
    }
}
