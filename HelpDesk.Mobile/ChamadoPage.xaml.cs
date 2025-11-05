using AcessoDados;
using AcessoDados.Models;

namespace HelpDesk.Mobile;

public partial class ChamadoPage : ContentPage
{
    private readonly Usuario _usuarioLogado;

    public ChamadoPage(Usuario usuario)
    {
        InitializeComponent();
        _usuarioLogado = usuario;
        lblBoasVindas.Text = $"Olá, {_usuarioLogado.Nome}!";
    }

    private async void OnAbrirChamadoClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtDescricao.Text))
        {
            await DisplayAlert("Erro", "A descrição não pode estar vazia.", "OK");
            return;
        }

        Chamado novoChamado = new Chamado
        {
            IdUsuario = _usuarioLogado.IdUsuario,
            Descricao = txtDescricao.Text
        };

        ChamadoDAL chamadoDal = new ChamadoDAL();
        bool sucesso = chamadoDal.Registrar(novoChamado);

        if (sucesso)
        {
            await DisplayAlert("Sucesso", "Seu chamado foi aberto com sucesso!", "OK");
            txtDescricao.Text = string.Empty; // Limpa o campo
        }
        else
        {
            await DisplayAlert("Erro", "Não foi possível abrir seu chamado. Tente novamente.", "OK");
        }
    }
}