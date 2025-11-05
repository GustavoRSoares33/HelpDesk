using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HelpDesk.Web.Models;
using Microsoft.AspNetCore.Mvc;
using AcessoDados; // Usando seu projeto de acesso a dados
using AcessoDados.Models;
using System.Diagnostics;

namespace HelpDesk.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost] // Esta anotação indica que este método recebe dados de um formulário
    public IActionResult Login(string email, string senha)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
        {
            // Se os campos estiverem vazios, retorna para a tela de login com uma mensagem (opcional)
            ViewBag.Erro = "Preencha todos os campos.";
            return View("Index");
        }

        UsuarioDAL usuarioDal = new UsuarioDAL();
        Usuario? usuario = usuarioDal.Autenticar(email, senha);
        if (usuario != null)
        {
            HttpContext.Session.SetInt32("IdUsuario", usuario.IdUsuario);
            HttpContext.Session.SetString("NomeUsuario", usuario.Nome);
            HttpContext.Session.SetString("UserRole", "Usuario"); // Guarda o tipo de usuário
            return RedirectToAction("Dashboard");
        }

        // Se não for usuário, tenta como Técnico
        TecnicoDAL tecnicoDal = new TecnicoDAL();
        Tecnico? tecnico = tecnicoDal.Autenticar(email, senha);
        if (tecnico != null)
        {
            HttpContext.Session.SetInt32("IdUsuario", tecnico.IdTecnico);
            HttpContext.Session.SetString("NomeUsuario", tecnico.Nome);
            HttpContext.Session.SetString("UserRole", "Tecnico"); // Guarda o tipo de usuário
            return RedirectToAction("TecnicoDashboard"); // Redireciona para o novo painel
        }

        ViewBag.Erro = "Usuário ou senha inválidos.";
        return View("Index");
    }

    // Crie este método para ser a página principal do usuário após o login
    public IActionResult Dashboard()
    {
        int? idUsuario = HttpContext.Session.GetInt32("IdUsuario");
        if (idUsuario == null)
        {
            return RedirectToAction("Index");
        }

        ChamadoDAL chamadoDal = new ChamadoDAL();

        // Busca os chamados do usuário (código existente)
        List<Chamado> chamados = chamadoDal.ListarPorUsuario(idUsuario.Value);

        // NOVO: Busca a lista de categorias e envia para a View
        ViewBag.Categorias = chamadoDal.ListarCategorias();

        return View(chamados);
    }

    public IActionResult TecnicoDashboard()
    {
        // Proteção: verifica se quem está acessando é um técnico
        if (HttpContext.Session.GetString("UserRole") != "Tecnico")
        {
            return RedirectToAction("Index"); // Se não for, manda para o login
        }

        ChamadoDAL chamadoDal = new ChamadoDAL();
        List<Chamado> chamadosAbertos = chamadoDal.ListarChamadosAbertos();

        return View(chamadosAbertos);
    }

    [HttpPost]
    public IActionResult CriarChamado(string descricao, int idCategoria)
    {
        Debug.WriteLine("--- CONTROLLER: Ação CriarChamado foi chamada ---");

        if (string.IsNullOrWhiteSpace(descricao))
        {
            Debug.WriteLine("Descrição vazia. Redirecionando para o Dashboard.");
            return RedirectToAction("Dashboard");
        }

        ChamadoDAL chamadoDal = new ChamadoDAL();
        DiagnosticoIA? diagnostico = chamadoDal.AnalisarProblemaPorIA(descricao, idCategoria);

        if (diagnostico != null)
        {
            Debug.WriteLine("Diagnóstico encontrado! Redirecionando para a página de sugestão.");
            TempData["DescricaoProblema"] = descricao;
            // Guarda também a categoria escolhida pelo utilizador, caso ele recuse a sugestão
            TempData["IdCategoriaSelecionada"] = idCategoria;
            TempData["DiagnosticoIA"] = System.Text.Json.JsonSerializer.Serialize(diagnostico);
            return RedirectToAction("SugerirSolucao");
        }
        else
        {
            Debug.WriteLine("Nenhum diagnóstico encontrado. Criando chamado normal.");

            int? idUsuario = HttpContext.Session.GetInt32("IdUsuario");
            if (idUsuario == null) return RedirectToAction("Index");

            // --- INÍCIO DA CORREÇÃO ---

            // 1. Criamos o objeto Chamado incluindo o idCategoria
            Chamado novoChamado = new Chamado
            {
                IdUsuario = idUsuario.Value,
                Descricao = descricao,
                IdCategoria = idCategoria, // Adicionámos a categoria aqui!
                Status = "Aberto",
                DataAbertura = DateTime.Now
            };

            // 2. Chamamos o método de registo completo
            chamadoDal.RegistrarChamadoCompleto(novoChamado);

            // --- FIM DA CORREÇÃO ---

            return RedirectToAction("Dashboard");
        }
    }

    [HttpPost]
    public IActionResult AceitarSolucao()
    {
        string? descricao = TempData["DescricaoProblema"] as string;
        int? idUsuario = HttpContext.Session.GetInt32("IdUsuario");
        var diagnosticoJson = TempData["DiagnosticoIA"] as string;

        if (idUsuario != null && !string.IsNullOrEmpty(descricao) && !string.IsNullOrEmpty(diagnosticoJson))
        {
            var diagnostico = System.Text.Json.JsonSerializer.Deserialize<DiagnosticoIA>(diagnosticoJson);

            Chamado chamadoResolvido = new Chamado
            {
                IdUsuario = idUsuario.Value,
                Descricao = descricao,
                IdCategoria = diagnostico.IdCategoria,
                IdProblema = diagnostico.IdProblema,
                IdSolucao = diagnostico.IdSolucao,
                Status = "Resolvido via IA",
                DataAbertura = DateTime.Now,
                DataFechamento = DateTime.Now
            };

            ChamadoDAL chamadoDal = new ChamadoDAL();
            chamadoDal.RegistrarChamadoCompleto(chamadoResolvido);
        }
        return RedirectToAction("Dashboard");
    }

    public IActionResult SugerirSolucao()
    {
        // Recupera a descrição original do problema
        ViewBag.Descricao = TempData["DescricaoProblema"];

        // Recupera o objeto de diagnóstico que foi salvo como um texto JSON
        var diagnosticoJson = TempData["DiagnosticoIA"] as string;

        // Verifica se o diagnóstico foi encontrado
        if (!string.IsNullOrEmpty(diagnosticoJson))
        {
            // Converte o texto JSON de volta para um objeto DiagnosticoIA
            var diagnostico = System.Text.Json.JsonSerializer.Deserialize<DiagnosticoIA>(diagnosticoJson);

            // Extrai o texto da solução do objeto e o coloca na ViewBag
            ViewBag.Solucao = diagnostico.TextoSolucao;
        }
        else
        {
            // Caso algo dê errado, define uma mensagem padrão
            ViewBag.Solucao = "Nenhuma solução específica encontrada.";
        }

        // Mantém os dados no TempData para o caso de o usuário recusar a solução
        TempData.Keep("DescricaoProblema");
        TempData.Keep("DiagnosticoIA");

        return View();
    }

    [HttpPost]
    public IActionResult RecusarSolucao()
    {
        string? descricao = TempData["DescricaoProblema"] as string;
        int? idUsuario = HttpContext.Session.GetInt32("IdUsuario");

        if (idUsuario != null && !string.IsNullOrEmpty(descricao))
        {
            ChamadoDAL chamadoDal = new ChamadoDAL();
            Chamado novoChamado = new Chamado { IdUsuario = idUsuario.Value, Descricao = descricao };
            chamadoDal.Registrar(novoChamado);
        }

        return RedirectToAction("Dashboard");
    }

    public IActionResult Atender(int id) // O parâmetro 'id' virá da URL e será o ID do chamado
    {
        // Proteção: Apenas técnicos podem atender chamados
        if (HttpContext.Session.GetString("UserRole") != "Tecnico")
        {
            return RedirectToAction("Index");
        }

        // Pega o ID do técnico que está logado na sessão
        int? idTecnico = HttpContext.Session.GetInt32("IdUsuario"); // Usamos IdUsuario para guardar o ID de quem logou

        if (idTecnico == null)
        {
            // Se por algum motivo o ID do técnico não estiver na sessão, manda para o login
            return RedirectToAction("Index");
        }

        ChamadoDAL chamadoDal = new ChamadoDAL();
        chamadoDal.AtenderChamado(id, idTecnico.Value);

        // Após atender, redireciona o técnico de volta para o painel para ver a lista atualizada
        return RedirectToAction("TecnicoDashboard");
    }

    public IActionResult MeusAtendimentos()
    {
        // Proteção: Apenas técnicos podem ver esta página
        if (HttpContext.Session.GetString("UserRole") != "Tecnico")
        {
            return RedirectToAction("Index");
        }

        // Pega o ID do técnico logado da sessão
        int? idTecnico = HttpContext.Session.GetInt32("IdUsuario");
        if (idTecnico == null)
        {
            return RedirectToAction("Index");
        }

        ChamadoDAL chamadoDal = new ChamadoDAL();
        List<Chamado> meusChamados = chamadoDal.ListarPorTecnico(idTecnico.Value);

        return View(meusChamados);
    }

    public IActionResult Finalizar(int id) // 'id' é o ID do chamado vindo da URL
    {
        // Proteção: Apenas técnicos podem finalizar chamados
        if (HttpContext.Session.GetString("UserRole") != "Tecnico")
        {
            return RedirectToAction("Index");
        }

        ChamadoDAL chamadoDal = new ChamadoDAL();
        chamadoDal.FinalizarChamado(id);

        // Após finalizar, redireciona o técnico de volta para a sua lista de atendimentos.
        // O chamado finalizado não aparecerá mais lá.
        return RedirectToAction("MeusAtendimentos");
    }

    public IActionResult Cadastro()
    {
        return View();
    }

    // Método para RECEBER os dados do formulário de cadastro
    [HttpPost]
    public IActionResult Cadastro(Usuario novoUsuario) // O MVC automaticamente cria o objeto Usuario para nós!
    {
        // Validação básica do lado do servidor
        if (string.IsNullOrEmpty(novoUsuario.Nome) ||
            string.IsNullOrEmpty(novoUsuario.Email) ||
            string.IsNullOrEmpty(novoUsuario.Senha))
        {
            ViewBag.Erro = "Todos os campos são obrigatórios.";
            return View(novoUsuario); // Retorna para a tela de cadastro mostrando o erro
        }

        UsuarioDAL usuarioDal = new UsuarioDAL();
        bool sucesso = usuarioDal.Cadastrar(novoUsuario);

        if (sucesso)
        {
            // Se o cadastro deu certo, redireciona para a tela de login
            return RedirectToAction("Index");
        }
        else
        {
            ViewBag.Erro = "Falha ao cadastrar. O e-mail informado já pode estar em uso.";
            return View(novoUsuario);
        }

        [HttpPost]
        IActionResult SalvarFeedback(int idChamado, int nota)
        {
            ChamadoDAL chamadoDal = new ChamadoDAL();
            chamadoDal.SalvarFeedback(idChamado, nota);
            return RedirectToAction("Dashboard");
        }
    }

    public IActionResult DetalhesChamado(int id)
    {
        ChamadoDAL chamadoDal = new ChamadoDAL();
        Chamado? chamado = chamadoDal.ObterPorId(id);

        if (chamado == null)
        {
            return RedirectToAction("Dashboard"); // Ou uma página de erro
        }

        // Crie uma instância do ComentarioDAL
        ComentarioDAL comentarioDal = new ComentarioDAL();
        // Busque a lista de comentários para este chamado e envie para a View
        ViewBag.Comentarios = comentarioDal.ListarPorChamado(id);

        return View(chamado);
    }

    // Adicione este método completo ao seu HomeController.cs

    [HttpPost] // Essencial: indica que este método recebe dados de um formulário.
    public IActionResult AdicionarComentario(int idChamado, string texto)
    {
        // Verifica se o texto do comentário não está vazio.
        if (string.IsNullOrWhiteSpace(texto))
        {
            // Se estiver vazio, apenas redireciona de volta sem fazer nada.
            return RedirectToAction("DetalhesChamado", new { id = idChamado });
        }

        // Pega o nome do utilizador que está logado na sessão.
        string? autor = HttpContext.Session.GetString("NomeUsuario");

        // Se não encontrarmos o autor (por exemplo, a sessão expirou), não fazemos nada.
        if (string.IsNullOrEmpty(autor))
        {
            return RedirectToAction("Index"); // Manda para o login
        }

        // Cria um novo objeto Comentario com os dados recebidos.
        Comentario novoComentario = new Comentario
        {
            Id_Chamado = idChamado,
            Texto = texto,
            Autor = autor
        };

        // Cria uma instância do DAL para interagir com o banco de dados.
        ComentarioDAL comentarioDal = new ComentarioDAL();
        // Chama o método para adicionar o novo comentário ao banco.
        comentarioDal.Adicionar(novoComentario);

        // Redireciona o utilizador de volta para a mesma página de detalhes,
        // que agora irá recarregar e mostrar o novo comentário na lista.
        return RedirectToAction("DetalhesChamado", new { id = idChamado });
    }

    [HttpPost] // Essencial: indica que este método recebe dados de um formulário.
    public IActionResult SalvarFeedback(int idChamado, int nota)
    {
        // Verifica se uma nota válida foi selecionada (o valor não será 0 se o utilizador selecionar uma opção).
        if (nota > 0)
        {
            // Cria uma instância do DAL para interagir com o banco de dados.
            ChamadoDAL chamadoDal = new ChamadoDAL();
            // Chama o método no back-end para guardar a nota no banco.
            chamadoDal.SalvarFeedback(idChamado, nota);
        }

        // Redireciona o utilizador de volta para a mesma página de detalhes do chamado.
        // A página irá recarregar e agora mostrará a mensagem de "Obrigado por avaliar".
        return RedirectToAction("DetalhesChamado", new { id = idChamado });
    }

    // Adicione este método ao seu HomeController.cs
    public IActionResult MobileView()
    {
        // Se precisar de enviar dados para a view, faça-o aqui.
        // Por agora, ela só precisa de ser exibida.
        return View();
    }
}
