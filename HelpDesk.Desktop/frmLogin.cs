using AcessoDados;
using MaterialSkin;

namespace HelpDesk.Desktop
{
    public partial class frmLogin : MaterialSkin.Controls.MaterialForm
    {
        public frmLogin()
        {
            InitializeComponent();

            // --- INÍCIO DO NOVO BLOCO DE TEMA ---

            var materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;

            // Esta é a paleta de cores personalizada que corresponde ao seu design web
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(
                // Cor primária: o seu vermelho escuro para a barra de título e botões
                (System.Drawing.ColorTranslator.FromHtml("#7b0000")),

                // Variação mais escura do vermelho
                (System.Drawing.ColorTranslator.FromHtml("#5a0000")),

                // Variação mais clara do vermelho
                (System.Drawing.ColorTranslator.FromHtml("#a30000")),

                // Cor de destaque: o seu dourado para os indicadores e destaques
                (System.Drawing.ColorTranslator.FromHtml("#d4af37")),

                // Cor do texto
                TextShade.WHITE
            );
            // --- FIM DO BLOCO DE TEMA FINAL ---
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string senha = txtSenha.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Por favor, preencha o e-mail e a senha.", "Campos Vazios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AdminDAL adminDal = new AdminDAL();
            var admin = adminDal.Autenticar(email, senha);

            if (admin != null)
            {
                // SINAL DE SUCESSO:
                // Avisa que o login foi bem-sucedido.
                this.DialogResult = DialogResult.OK;

                // FECHA O FORMULÁRIO DE LOGIN:
                // O porteiro completou o seu trabalho.
                this.Close();
            }
            else
            {
                MessageBox.Show("Credenciais de administrador inválidas.", "Falha no Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Se o login falhar, não fazemos nada, apenas deixamos a tela aberta para nova tentativa.
            }
        }
    }
}
