using AcessoDados.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace AcessoDados
{
    public class AdminDAL
    {
        public Admin? Autenticar(string email, string senha)
        {
            try
            {
                using (var conexao = Conexao.GetConexao())
                {
                    string sql = "SELECT * FROM Admin WHERE Email = @email AND Senha = @senha";
                    using (var cmd = new SqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@senha", senha);
                        var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            return new Admin
                            {
                                IdAdmin = Convert.ToInt32(reader["idAdmin"]),
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
                Console.WriteLine("Erro ao autenticar admin: " + ex.Message);
            }
            return null;
        }

        public List<Admin> ListarTodos()
        {
            var lista = new List<Admin>();
            try
            {
                using (var conexao = Conexao.GetConexao())
                {
                    string sql = "SELECT * FROM Admin ORDER BY Nome";
                    using (var cmd = new SqlCommand(sql, conexao))
                    {
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            lista.Add(new Admin
                            {
                                IdAdmin = Convert.ToInt32(reader["idAdmin"]),
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
                Console.WriteLine("Erro ao listar admins: " + ex.Message);
            }
            return lista;
        }

        public bool Cadastrar(Admin admin)
        {
            try
            {
                using (var conexao = Conexao.GetConexao())
                {
                    string sql = "INSERT INTO Admin (Nome, Email, Senha) VALUES (@nome, @email, @senha)";
                    using (var cmd = new SqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@nome", admin.Nome);
                        cmd.Parameters.AddWithValue("@email", admin.Email);
                        cmd.Parameters.AddWithValue("@senha", admin.Senha);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao cadastrar admin: " + ex.Message);
                return false;
            }
        }

        public bool Atualizar(Admin admin)
        {
            try
            {
                using (var conexao = Conexao.GetConexao())
                {
                    string sql = "UPDATE Admin SET Nome = @nome, Email = @email, Senha = @senha WHERE idAdmin = @id";
                    using (var cmd = new SqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@nome", admin.Nome);
                        cmd.Parameters.AddWithValue("@email", admin.Email);
                        cmd.Parameters.AddWithValue("@senha", admin.Senha);
                        cmd.Parameters.AddWithValue("@id", admin.IdAdmin);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao atualizar admin: " + ex.Message);
                return false;
            }
        }

        public bool Excluir(int idAdmin)
        {
            try
            {
                using (var conexao = Conexao.GetConexao())
                {
                    string sql = "DELETE FROM Admin WHERE idAdmin = @id";
                    using (var cmd = new SqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@id", idAdmin);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao excluir admin: " + ex.Message);
                return false;
            }
        }
    }
}