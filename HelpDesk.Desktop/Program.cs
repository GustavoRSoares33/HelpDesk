namespace HelpDesk.Desktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Cria uma instância do nosso "porteiro" (a tela de login)
            frmLogin loginForm = new frmLogin();

            // Mostra o formulário de login e espera que ele seja fechado.
            // O código fica "pausado" aqui até o login ser feito ou cancelado.
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Se o login foi bem-sucedido (DialogResult foi OK),
                // então, e só então, inicia a aplicação principal com o Dashboard.
                Application.Run(new frmAdminDashboard());
            }
            // Se o login falhou ou foi cancelado (o utilizador fechou a janela),
            // o programa simplesmente termina, sem abrir mais nada.
        }
    }
}