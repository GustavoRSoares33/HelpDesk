using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using AcessoDados.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace AcessoDados
{
    public class ChamadoDAL
    {
        /// <summary>
        /// Registra um novo chamado no banco de dados.
        /// </summary>
        public bool Registrar(Chamado chamado)
        {
            try
            {
                using (SqlConnection conexao = Conexao.GetConexao())
                {
                    string sql = "INSERT INTO Chamado (id_Usuario, Descricao, statusc, DataAbertura) VALUES (@idUsuario, @descricao, @status, @dataAbertura)";
                    using (SqlCommand cmd = new SqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", chamado.IdUsuario);
                        cmd.Parameters.AddWithValue("@descricao", chamado.Descricao);
                        cmd.Parameters.AddWithValue("@status", "Aberto");
                        cmd.Parameters.AddWithValue("@dataAbertura", DateTime.Now);

                        int linhasAfetadas = cmd.ExecuteNonQuery();
                        return linhasAfetadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao registrar chamado: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Lista todos os chamados de um usuário específico.
        /// </summary>
        public List<Chamado> ListarPorUsuario(int idUsuario)
        {
            List<Chamado> listaChamados = new List<Chamado>();
            try
            {
                using (SqlConnection conexao = Conexao.GetConexao())
                {
                    string sql = @"SELECT C.idChamado, C.Descricao, C.statusc, C.DataAbertura, Cat.Categoria as NomeCategoria
                                   FROM Chamado C
                                   LEFT JOIN Categoria Cat ON C.id_Categoria = Cat.idCategoria
                                   WHERE C.id_Usuario = @idUsuario ORDER BY C.DataAbertura DESC";
                    using (SqlCommand cmd = new SqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Chamado chamado = new Chamado
                            {
                                IdChamado = Convert.ToInt32(reader["idChamado"]),
                                Descricao = reader["Descricao"].ToString(),
                                Status = reader["statusc"].ToString(),
                                DataAbertura = Convert.ToDateTime(reader["DataAbertura"]),
                                NomeCategoria = reader["NomeCategoria"] != DBNull.Value ? reader["NomeCategoria"].ToString() : "Não definida"
                            };
                            listaChamados.Add(chamado);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao listar chamados: " + ex.Message);
            }
            return listaChamados;
        }

        /// <summary>
        /// Lista todos os chamados que estão com status "Aberto".
        /// </summary>
        /// <returns>Uma lista de chamados abertos.</returns>
        public List<Chamado> ListarChamadosAbertos()
        {
            List<Chamado> listaChamados = new List<Chamado>();
            try
            {
                using (SqlConnection conexao = Conexao.GetConexao())
                {
                    // Modificamos o SQL para buscar também o nome do usuário que abriu o chamado
                    // e para filtrar apenas os chamados com status 'Aberto'.
                    string sql = @"SELECT 
                       C.idChamado, C.Descricao, C.statusc, C.DataAbertura,
                       U.Nome as NomeUsuario,
                       Cat.Categoria as NomeCategoria
                       FROM Chamado C
                       INNER JOIN Usuario U ON C.id_Usuario = U.idUsuario
                       LEFT JOIN Categoria Cat ON C.id_Categoria = Cat.idCategoria
                       WHERE C.statusc = 'Aberto'
                       ORDER BY C.DataAbertura ASC";

                    using (SqlCommand cmd = new SqlCommand(sql, conexao))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Chamado chamado = new Chamado
                            {
                                IdChamado = Convert.ToInt32(reader["idChamado"]),
                                Descricao = reader["Descricao"].ToString(),
                                Status = reader["statusc"].ToString(),
                                DataAbertura = Convert.ToDateTime(reader["DataAbertura"]),
                                NomeUsuario = reader["NomeUsuario"].ToString(),
                                NomeCategoria = reader["NomeCategoria"] != DBNull.Value ? reader["NomeCategoria"].ToString() : "Não definida"
                            };
                            listaChamados.Add(chamado);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao listar chamados abertos: " + ex.Message);
            }
            return listaChamados;
        }

        /// <summary>
        /// Atribui um chamado a um técnico e muda seu status para "Em atendimento".
        /// </summary>
        /// <param name="idChamado">O ID do chamado a ser atendido.</param>
        /// <param name="idTecnico">O ID do técnico que está atendendo.</param>
        /// <returns>Retorna true se a atualização for bem-sucedida.</returns>
        public bool AtenderChamado(int idChamado, int idTecnico)
        {
            try
            {
                using (SqlConnection conexao = Conexao.GetConexao())
                {
                    string sql = "UPDATE Chamado SET id_Tecnico = @idTecnico, statusc = 'Em atendimento' WHERE idChamado = @idChamado";
                    using (SqlCommand cmd = new SqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@idTecnico", idTecnico);
                        cmd.Parameters.AddWithValue("@idChamado", idChamado);

                        int linhasAfetadas = cmd.ExecuteNonQuery();
                        return linhasAfetadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao atender chamado: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Lista os chamados que estão sendo atendidos por um técnico específico.
        /// </summary>
        /// <param name="idTecnico">O ID do técnico.</param>
        /// <returns>Uma lista de chamados em atendimento.</returns>
        public List<Chamado> ListarPorTecnico(int idTecnico)
        {
            List<Chamado> listaChamados = new List<Chamado>();
            try
            {
                using (SqlConnection conexao = Conexao.GetConexao())
                {
                    string sql = @"SELECT 
                       C.idChamado, C.Descricao, C.statusc, C.DataAbertura,
                       U.Nome as NomeUsuario,
                       Cat.Categoria as NomeCategoria
                       FROM Chamado C
                       INNER JOIN Usuario U ON C.id_Usuario = U.idUsuario
                       LEFT JOIN Categoria Cat ON C.id_Categoria = Cat.idCategoria
                       WHERE C.id_Tecnico = @idTecnico AND C.statusc = 'Em atendimento'
                       ORDER BY C.DataAbertura ASC";

                    using (SqlCommand cmd = new SqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@idTecnico", idTecnico);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Chamado chamado = new Chamado
                            {
                                IdChamado = Convert.ToInt32(reader["idChamado"]),
                                Descricao = reader["Descricao"].ToString(),
                                Status = reader["statusc"].ToString(),
                                DataAbertura = Convert.ToDateTime(reader["DataAbertura"]),
                                NomeUsuario = reader["NomeUsuario"].ToString(),
                                NomeCategoria = reader["NomeCategoria"] != DBNull.Value ? reader["NomeCategoria"].ToString() : "Não definida"
                            };
                            listaChamados.Add(chamado);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao listar chamados do técnico: " + ex.Message);
            }
            return listaChamados;
        }

        /// <summary>
        /// Altera o status de um chamado para "Encerrado" e registra a data de fechamento.
        /// </summary>
        /// <param name="idChamado">O ID do chamado a ser finalizado.</param>
        /// <returns>Retorna true se a atualização for bem-sucedida.</returns>
        public bool FinalizarChamado(int idChamado)
        {
            try
            {
                using (SqlConnection conexao = Conexao.GetConexao())
                {
                    string sql = "UPDATE Chamado SET statusc = 'Encerrado', DataFechamento = @dataFechamento WHERE idChamado = @idChamado";
                    using (SqlCommand cmd = new SqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@dataFechamento", DateTime.Now);
                        cmd.Parameters.AddWithValue("@idChamado", idChamado);

                        int linhasAfetadas = cmd.ExecuteNonQuery();
                        return linhasAfetadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao finalizar chamado: " + ex.Message);
                return false;
            }
        }

        public List<Chamado> ListarTodosParaRelatorio(DateTime dataInicio, DateTime dataFim)
        {
            List<Chamado> listaCompleta = new List<Chamado>();
            try
            {
                using (SqlConnection conexao = Conexao.GetConexao())
                {
                    string sql = @"SELECT 
                               C.idChamado, C.Descricao, C.statusc, C.DataAbertura, C.DataFechamento,
                               U.Nome as NomeUsuario,
                               T.Nome as NomeTecnico,
                               Cat.Categoria as NomeCategoria
                           FROM Chamado C
                           INNER JOIN Usuario U ON C.id_Usuario = U.idUsuario
                           LEFT JOIN Tecnico T ON C.id_Tecnico = T.idTecnico
                           LEFT JOIN Categoria Cat ON C.id_Categoria = Cat.idCategoria
                           WHERE C.DataAbertura BETWEEN @dataInicio AND @dataFim
                           ORDER BY C.idChamado DESC";

                    using (SqlCommand cmd = new SqlCommand(sql, conexao))
                    {
                        // Passa as datas recebidas como parâmetros para a consulta
                        cmd.Parameters.AddWithValue("@dataInicio", dataInicio);
                        cmd.Parameters.AddWithValue("@dataFim", dataFim);

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Chamado chamado = new Chamado
                            {
                                IdChamado = Convert.ToInt32(reader["idChamado"]),
                                Descricao = reader["Descricao"].ToString(),
                                Status = reader["statusc"].ToString(),
                                DataAbertura = Convert.ToDateTime(reader["DataAbertura"]),
                                // Verifica se DataFechamento não é nulo antes de converter
                                DataFechamento = reader["DataFechamento"] != DBNull.Value ? Convert.ToDateTime(reader["DataFechamento"]) : null,
                                NomeUsuario = reader["NomeUsuario"].ToString(),
                                // Verifica se NomeTecnico não é nulo
                                NomeTecnico = reader["NomeTecnico"] != DBNull.Value ? reader["NomeTecnico"].ToString() : "N/A"
                            };
                            listaCompleta.Add(chamado);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao listar todos os chamados: " + ex.Message);
            }
            return listaCompleta;
        }

        /// <summary>
        /// Procura por uma solução automática no banco de dados com base na descrição do problema.
        /// </summary>
        /// <param name="descricaoProblema">O texto digitado pelo usuário.</param>
        /// <returns>Uma string com a solução encontrada ou null se nada for encontrado.</returns>
        public DiagnosticoIA? AnalisarProblemaPorIA(string descricaoProblema, int idCategoria)
        {
            Debug.WriteLine($"--- INICIANDO ANÁLISE POR IA (Categoria: {idCategoria}) ---");
            Debug.WriteLine($"Descrição recebida: '{descricaoProblema}'");

            try
            {
                using (SqlConnection conexao = Conexao.GetConexao())
                {
                    var palavrasDoUsuario = descricaoProblema.ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // Constrói uma consulta SQL dinâmica para procurar por qualquer uma das palavras
                    var sqlConditions = new List<string>();
                    foreach (var palavra in palavrasDoUsuario)
                    {
                        // Adiciona uma condição LIKE para cada palavra
                        sqlConditions.Add("P.PalavrasChave LIKE @p" + palavrasDoUsuario.ToList().IndexOf(palavra));
                    }

                    if (sqlConditions.Count == 0) return null;

                    string sql = $@"SELECT TOP 1 P.idProblema, P.id_Categoria, S.idSolucao, S.Solucao 
                            FROM Problema P
                            JOIN Solucao S ON P.id_Solucao = S.idSolucao
                            WHERE P.id_Categoria = @idCategoria AND ({string.Join(" OR ", sqlConditions)})";

                    Debug.WriteLine($"SQL da IA: {sql}");

                    using (SqlCommand cmd = new SqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
                        foreach (var palavra in palavrasDoUsuario)
                        {
                            cmd.Parameters.AddWithValue("@p" + palavrasDoUsuario.ToList().IndexOf(palavra), "%" + palavra + "%");
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Debug.WriteLine("!!!! SUCESSO: Encontrada correspondência !!!!");
                                return new DiagnosticoIA
                                {
                                    IdProblema = Convert.ToInt32(reader["idProblema"]),
                                    IdCategoria = Convert.ToInt32(reader["id_Categoria"]),
                                    IdSolucao = Convert.ToInt32(reader["idSolucao"]),
                                    TextoSolucao = reader["Solucao"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"!!!!!! ERRO CRÍTICO NA ANÁLISE: {ex.Message} !!!!!!");
            }

            Debug.WriteLine("--- FINALIZANDO ANÁLISE (SEM SUCESSO) ---");
            return null;
        }

        // Adicione este novo método para registrar o chamado com todos os dados
        public bool RegistrarChamadoCompleto(Chamado chamado)
        {
            try
            {
                using (SqlConnection conexao = Conexao.GetConexao())
                {
                    string sql = @"INSERT INTO Chamado 
                               (id_Usuario, Descricao, statusc, DataAbertura, id_Categoria, id_Problema, id_Solucao, DataFechamento, feedback) 
                               VALUES 
                               (@idUsuario, @descricao, @status, @dataAbertura, @idCategoria, @idProblema, @idSolucao, @dataFechamento, @feedback)";
                    using (SqlCommand cmd = new SqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", chamado.IdUsuario);
                        cmd.Parameters.AddWithValue("@descricao", chamado.Descricao);
                        cmd.Parameters.AddWithValue("@status", chamado.Status);
                        cmd.Parameters.AddWithValue("@dataAbertura", chamado.DataAbertura);
                        cmd.Parameters.AddWithValue("@idCategoria", (object)chamado.IdCategoria ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@idProblema", (object)chamado.IdProblema ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@idSolucao", (object)chamado.IdSolucao ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@dataFechamento", (object)chamado.DataFechamento ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@feedback", (object)chamado.Feedback ?? DBNull.Value);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao registrar chamado completo: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Salva a nota de feedback de um usuário para um chamado específico.
        /// </summary>
        /// <param name="idChamado">O ID do chamado que está sendo avaliado.</param>
        /// <param name="nota">A nota de feedback (de 1 a 5).</param>
        /// <returns>Retorna true se a atualização for bem-sucedida, false caso contrário.</returns>
        public bool SalvarFeedback(int idChamado, int nota)
        {
            // O 'using' garante que a conexão será fechada automaticamente, mesmo se ocorrer um erro.
            try
            {
                using (SqlConnection conexao = Conexao.GetConexao())
                {
                    // Comando SQL para atualizar apenas a coluna 'feedback' de um chamado específico.
                    string sql = "UPDATE Chamado SET feedback = @nota WHERE idChamado = @idChamado";

                    using (SqlCommand cmd = new SqlCommand(sql, conexao))
                    {
                        // Adiciona os parâmetros ao comando para evitar SQL Injection.
                        cmd.Parameters.AddWithValue("@nota", nota);
                        cmd.Parameters.AddWithValue("@idChamado", idChamado);

                        // ExecuteNonQuery() é usado para comandos UPDATE, INSERT, DELETE e
                        // retorna o número de linhas que foram afetadas.
                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        // Se uma linha foi afetada (linhasAfetadas > 0), a atualização foi bem-sucedida.
                        return linhasAfetadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Em caso de qualquer erro com o banco de dados, imprime a mensagem no console de debug
                // e retorna false para indicar que a operação falhou.
                Console.WriteLine("Ocorreu um erro ao salvar o feedback: " + ex.Message);
                return false;
            }
        }

        public List<Categoria> ListarCategorias()
        {
            var lista = new List<Categoria>();
            try
            {
                using (SqlConnection conexao = Conexao.GetConexao())
                {
                    string sql = "SELECT idCategoria, Categoria FROM Categoria ORDER BY Categoria";
                    using (SqlCommand cmd = new SqlCommand(sql, conexao))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            lista.Add(new Categoria
                            {
                                IdCategoria = Convert.ToInt32(reader["idCategoria"]),
                                NomeCategoria = reader["Categoria"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao listar categorias: " + ex.Message);
            }
            return lista;
        }

        /// <summary>
        /// Busca um chamado específico no banco de dados pelo seu ID.
        /// </summary>
        /// <param name="idChamado">O ID do chamado a ser encontrado.</param>
        /// <returns>Retorna um objeto Chamado com todos os detalhes, ou null se não for encontrado.</returns>
        public Chamado? ObterPorId(int idChamado)
        {
            // O 'using' garante que a conexão será fechada automaticamente.
            try
            {
                using (SqlConnection conexao = Conexao.GetConexao())
                {
                    // A consulta SQL une as tabelas para obter os nomes do usuário e do técnico.
                    // Usamos LEFT JOIN para o técnico, pois um chamado pode ainda não ter um técnico atribuído.
                    string sql = @"SELECT 
                       C.*, 
                       U.Nome as NomeUsuario, 
                       T.Nome as NomeTecnico,
                       Cat.Categoria as NomeCategoria
                       FROM Chamado C
                       INNER JOIN Usuario U ON C.id_Usuario = U.idUsuario
                       LEFT JOIN Tecnico T ON C.id_Tecnico = T.idTecnico
                       LEFT JOIN Categoria Cat ON C.id_Categoria = Cat.idCategoria
                       WHERE C.idChamado = @idChamado";

                    using (SqlCommand cmd = new SqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@idChamado", idChamado);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Se o leitor encontrar uma linha, significa que o chamado existe.
                            if (reader.Read())
                            {
                                // Cria e preenche o objeto Chamado com os dados do banco.
                                Chamado chamado = new Chamado
                                {
                                    IdChamado = Convert.ToInt32(reader["idChamado"]),
                                    IdUsuario = Convert.ToInt32(reader["id_Usuario"]),
                                    Descricao = reader["Descricao"].ToString(),
                                    Status = reader["statusc"].ToString(),
                                    DataAbertura = Convert.ToDateTime(reader["DataAbertura"]),
                                    NomeUsuario = reader["NomeUsuario"].ToString(),

                                    // Verifica se os campos que podem ser nulos não são DBNull antes de converter.
                                    IdTecnico = reader["id_Tecnico"] != DBNull.Value ? Convert.ToInt32(reader["id_Tecnico"]) : null,
                                    IdCategoria = reader["id_Categoria"] != DBNull.Value ? Convert.ToInt32(reader["id_Categoria"]) : null,
                                    IdProblema = reader["id_Problema"] != DBNull.Value ? Convert.ToInt32(reader["id_Problema"]) : null,
                                    IdSolucao = reader["id_Solucao"] != DBNull.Value ? Convert.ToInt32(reader["id_Solucao"]) : null,
                                    Feedback = reader["feedback"] != DBNull.Value ? Convert.ToInt32(reader["feedback"]) : null,
                                    DataFechamento = reader["DataFechamento"] != DBNull.Value ? Convert.ToDateTime(reader["DataFechamento"]) : null,
                                    NomeTecnico = reader["NomeTecnico"] != DBNull.Value ? reader["NomeTecnico"].ToString() : "Nenhum técnico atribuído",
                                    NomeCategoria = reader["NomeCategoria"] != DBNull.Value ? reader["NomeCategoria"].ToString() : "Não definida"
                                };

                                return chamado;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao obter o chamado por ID: " + ex.Message);
            }

            // Se o chamado não for encontrado ou ocorrer um erro, retorna nulo.
            return null;
        }
    }
}
