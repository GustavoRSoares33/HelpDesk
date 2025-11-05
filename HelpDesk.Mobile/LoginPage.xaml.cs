using AcessoDados;
using AcessoDados.Models;

namespace HelpDesk.Mobile;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtSenha.Text))
        {
            await DisplayAlert("Erro", "Preencha todos os campos.", "OK");
            return;
        }

        UsuarioDAL usuarioDal = new UsuarioDAL();
        Usuario? usuario = usuarioDal.Autenticar(txtEmail.Text.Trim(), txtSenha.Text.Trim());

        if (usuario != null)
        {
            // Login bem-sucedido! Navega para a próxima página
            // Passamos o objeto 'usuario' para a próxima tela
            await Navigation.PushAsync(new ChamadoPage(usuario));
        }
        else
        {
            await DisplayAlert("Falha", "E-mail ou senha inválidos.", "OK");
        }
    }
}