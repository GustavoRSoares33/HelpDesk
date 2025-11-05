using AcessoDados.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace AcessoDados
{
    public class UsuarioDAL
    {
        public Usuario? Autenticar(string email, string senha)
        {
            try
            {
                using (var conexao = Conexao.GetConexao())
                {
                    string sql = "SELECT * FROM Usuario WHERE Email = @email AND Senha = @senha";
                    using (var cmd = new SqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@senha", senha);
                        var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                IdUsuario = Convert.ToInt32(reader["idUsuario"]),
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
                Console.WriteLine("Erro ao autenticar usuário: " + ex.Message);
            }
            return null;
        }

        public List<Usuario> ListarTodos()
        {
            var lista = new List<Usuario>();
            try
            {
                using (var conexao = Conexao.GetConexao())
                {
                    string sql = "SELECT * FROM Usuario ORDER BY Nome";
                    using (var cmd = new SqlCommand(sql, conexao))
                    {
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            lista.Add(new Usuario
                            {
                                IdUsuario = Convert.ToInt32(reader["idUsuario"]),
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
                Console.WriteLine("Erro ao listar usuários: " + ex.Message);
            }
            return lista;
        }

        public bool Cadastrar(Usuario usuario)
        {
            try
            {
                using (var conexao = Conexao.GetConexao())
                {
                    string sql = "INSERT INTO Usuario (Nome, Email, Senha) VALUES (@nome, @email, @senha)";
                    using (var cmd = new SqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@nome", usuario.Nome);
                        cmd.Parameters.AddWithValue("@email", usuario.Email);
                        cmd.Parameters.AddWithValue("@senha", usuario.Senha);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao cadastrar usuário: " + ex.Message);
                return false;
            }
        }

        public bool Atualizar(Usuario usuario)
        {
            try
            {
                using (var conexao = Conexao.GetConexao())
                {
                    string sql = "UPDATE Usuario SET Nome = @nome, Email = @email, Senha = @senha WHERE idUsuario = @id";
                    using (var cmd = new SqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@nome", usuario.Nome);
                        cmd.Parameters.AddWithValue("@email", usuario.Email);
                        cmd.Parameters.AddWithValue("@senha", usuario.Senha);
                        cmd.Parameters.AddWithValue("@id", usuario.IdUsuario);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao atualizar usuário: " + ex.Message);
                return false;
            }
        }

        public bool Excluir(int idUsuario)
        {
            try
            {
                using (var conexao = Conexao.GetConexao())
                {
                    string sql = "DELETE FROM Usuario WHERE idUsuario = @id";
                    using (var cmd = new SqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@id", idUsuario);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao excluir usuário: " + ex.Message);
                return false;
            }
        }
    }
}