using AcessoDados.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace AcessoDados
{
    public class TecnicoDAL
    {
        public Tecnico? Autenticar(string email, string senha)
        {
            try
            {
                using (var conexao = Conexao.GetConexao())
                {
                    string sql = "SELECT * FROM Tecnico WHERE Email = @email AND Senha = @senha";
                    using (var cmd = new SqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@senha", senha);
                        var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            return new Tecnico
                            {
                                IdTecnico = Convert.ToInt32(reader["idTecnico"]),
                                Nome = reader["Nome"].ToString(),
                                Email = reader["Email"].ToString(),
                                Senha = reader["Senha"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao autenticar técnico: " + ex.Message);
            }
            return null;
        }

        public List<Tecnico> ListarTodos()
        {
            var lista = new List<Tecnico>();
            try
            {
                using (var conexao = Conexao.GetConexao())
                {
                    string sql = "SELECT * FROM Tecnico ORDER BY Nome";
                    using (var cmd = new SqlCommand(sql, conexao))
                    {
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            lista.Add(new Tecnico
                            {
                                IdTecnico = Convert.ToInt32(reader["idTecnico"]),
                                Nome = reader["Nome"].ToString(),
                                Email = reader["Email"].ToString(),
                                Senha = reader["Senha"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao listar técnicos: " + ex.Message);
            }
            return lista;
        }

        public bool Cadastrar(Tecnico tecnico)
        {
            try
            {
                using (var conexao = Conexao.GetConexao())
                {
                    string sql = "INSERT INTO Tecnico (Nome, Email, Senha) VALUES (@nome, @email, @senha)";
                    using (var cmd = new SqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@nome", tecnico.Nome);
                        cmd.Parameters.AddWithValue("@email", tecnico.Email);
                        cmd.Parameters.AddWithValue("@senha", tecnico.Senha);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao cadastrar técnico: " + ex.Message);
                return false;
            }
        }

        public bool Atualizar(Tecnico tecnico)
        {
            try
            {
                using (var conexao = Conexao.GetConexao())
                {
                    string sql = "UPDATE Tecnico SET Nome = @nome, Email = @email, Senha = @senha WHERE idTecnico = @id";
                    using (var cmd = new SqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@nome", tecnico.Nome);
                        cmd.Parameters.AddWithValue("@email", tecnico.Email);
                        cmd.Parameters.AddWithValue("@senha", tecnico.Senha);
                        cmd.Parameters.AddWithValue("@id", tecnico.IdTecnico);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao atualizar técnico: " + ex.Message);
                return false;
            }
        }

        public bool Excluir(int idTecnico)
        {
            try
            {
                using (var conexao = Conexao.GetConexao())
                {
                    string sql = "DELETE FROM Tecnico WHERE idTecnico = @id";
                    using (var cmd = new SqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@id", idTecnico);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao excluir técnico: " + ex.Message);
                return false;
            }
        }
    }
}