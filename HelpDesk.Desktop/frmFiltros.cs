using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelpDesk.Desktop
{
    public partial class frmFiltros : MaterialSkin.Controls.MaterialForm
    {

        public string FiltroTipo { get; private set; } = "Todos";
        public string FiltroNome { get; private set; } = "";
        public string FiltroEmail { get; private set; } = "";

        public frmFiltros()
        {
            InitializeComponent();

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
        }

        private void frmFiltros_Load(object sender, EventArgs e)
        {
            // Preenche o ComboBox com as opções de filtro
            cmbFiltroTipo.Items.Add("Todos");
            cmbFiltroTipo.Items.Add("Usuário");
            cmbFiltroTipo.Items.Add("Técnico");
            cmbFiltroTipo.Items.Add("Admin");
            cmbFiltroTipo.SelectedItem = "Todos"; // Deixa pré-selecionado
        }

        private void btnAplicarFiltros_Click(object sender, EventArgs e)
        {
            FiltroTipo = cmbFiltroTipo.SelectedItem?.ToString() ?? "Todos";
            FiltroNome = txtFiltroNome.Text.Trim();
            FiltroEmail = txtFiltroEmail.Text.Trim();

            // Sinaliza para o formulário principal que o utilizador confirmou a ação
            this.DialogResult = DialogResult.OK;
            // Fecha o popup
            this.Close();
        }

        private void btnCancelarFiltros_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
