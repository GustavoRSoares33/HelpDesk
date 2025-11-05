using AcessoDados;
using AcessoDados.Models;
using MaterialSkin;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Data;
using System.Diagnostics;
using System.Drawing;

namespace HelpDesk.Desktop
{
    public partial class frmAdminDashboard : MaterialSkin.Controls.MaterialForm
    {
        private dynamic? _usuarioSelecionado = null;

        public frmAdminDashboard()
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

            QuestPDF.Settings.License = LicenseType.Community;
        }

        private void frmAdminDashboard_Load(object sender, EventArgs e)
        {
            // --- Configuração da Aba de Cadastro ---
            cmbTipoContaNovo.Items.Add("Usuário");
            cmbTipoContaNovo.Items.Add("Técnico");
            cmbTipoContaNovo.Items.Add("Admin");
            cmbTipoContaNovo.SelectedIndex = 0;

            // --- Configuração da Aba de Gerenciamento (Agora muito mais simples!) ---
            CarregarUsuarios("Todos", "", "");
        }

        private void LimparCamposEdicao()
        {
            txtNomeEditar.Clear();
            txtEmailEditar.Clear();
            txtSenhaEditar.Clear();
            _usuarioSelecionado = null;

            dgvUsuarios.ClearSelection();
            if (dgvUsuarios.CurrentCell != null)
            {
                dgvUsuarios.CurrentCell = null;
            }

            btnSalvarEdicao.Enabled = false;
            btnExcluir.Enabled = false;
        }

        // ====================================================================
        // LÓGICA DA ABA "CADASTRAR NOVO USUÁRIO"
        // ====================================================================
        private void btnCadastrarNovo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomeNovo.Text) ||
                string.IsNullOrWhiteSpace(txtEmailNovo.Text) ||
                string.IsNullOrWhiteSpace(txtSenhaNovo.Text) ||
                cmbTipoContaNovo.SelectedItem == null)
            {
                MessageBox.Show("Para cadastrar, preencha todos os campos e selecione um tipo de conta.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool sucesso = false;
            string tipoSelecionado = cmbTipoContaNovo.SelectedItem.ToString() ?? "";

            switch (tipoSelecionado)
            {
                case "Usuário":
                    sucesso = new UsuarioDAL().Cadastrar(new Usuario { Nome = txtNomeNovo.Text, Email = txtEmailNovo.Text, Senha = txtSenhaNovo.Text });
                    break;
                case "Técnico":
                    sucesso = new TecnicoDAL().Cadastrar(new Tecnico { Nome = txtNomeNovo.Text, Email = txtEmailNovo.Text, Senha = txtSenhaNovo.Text });
                    break;
                case "Admin":
                    sucesso = new AdminDAL().Cadastrar(new Admin { Nome = txtNomeNovo.Text, Email = txtEmailNovo.Text, Senha = txtSenhaNovo.Text });
                    break;
            }

            if (sucesso)
            {
                MessageBox.Show($"'{tipoSelecionado}' criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNomeNovo.Clear();
                txtEmailNovo.Clear();
                txtSenhaNovo.Clear();
                CarregarUsuarios("Todos", "", ""); // Recarrega a lista na outra aba
            }
            else
            {
                MessageBox.Show("Falha ao criar o utilizador. Verifique se o e-mail já está em uso.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====================================================================
        // LÓGICA DA ABA "GERENCIAR USUÁRIOS"
        // ====================================================================

        private void CarregarUsuarios(string filtroTipo, string filtroNome, string filtroEmail)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Nome", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Tipo", typeof(string));

            // Carrega os dados do banco
            if (filtroTipo == "Usuário" || filtroTipo == "Todos")
            {
                foreach (var u in new UsuarioDAL().ListarTodos()) { dt.Rows.Add(u.IdUsuario, u.Nome, u.Email, "Usuário"); }
            }
            if (filtroTipo == "Técnico" || filtroTipo == "Todos")
            {
                foreach (var t in new TecnicoDAL().ListarTodos()) { dt.Rows.Add(t.IdTecnico, t.Nome, t.Email, "Técnico"); }
            }
            if (filtroTipo == "Admin" || filtroTipo == "Todos")
            {
                foreach (var a in new AdminDAL().ListarTodos()) { dt.Rows.Add(a.IdAdmin, a.Nome, a.Email, "Admin"); }
            }

            // Constrói e aplica o filtro de texto
            string rowFilter = $"Nome LIKE '%{filtroNome}%' AND Email LIKE '%{filtroEmail}%'";
            dt.DefaultView.RowFilter = $"Nome LIKE '%{filtroNome}%' AND Email LIKE '%{filtroEmail}%'";
            dgvUsuarios.DataSource = dt.DefaultView;

            ConfigurarDataGridView();
            EstilizarDataGridView();

            LimparCamposEdicao();
        }

        private void ConfigurarDataGridView()
        {
            // Configurações existentes
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.RowHeadersVisible = false;

            // Ajusta a largura de cada coluna
            dgvUsuarios.Columns["ID"].Width = 60;
            dgvUsuarios.Columns["Tipo"].Width = 100;
            dgvUsuarios.Columns["Email"].Width = 250;
            dgvUsuarios.Columns["Nome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void EstilizarDataGridView()
        {
            // Limpa quaisquer estilos antigos para garantir um começo limpo
            dgvUsuarios.DefaultCellStyle.Font = null;
            dgvUsuarios.DefaultCellStyle.BackColor = System.Drawing.Color.Empty;
            dgvUsuarios.DefaultCellStyle.ForeColor = System.Drawing.Color.Empty;

            // Configurações gerais
            dgvUsuarios.BorderStyle = BorderStyle.None;
            dgvUsuarios.BackgroundColor = System.Drawing.Color.FromArgb(45, 45, 48);
            dgvUsuarios.GridColor = System.Drawing.Color.FromArgb(70, 70, 73);
            dgvUsuarios.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Estilo do Cabeçalho
            dgvUsuarios.EnableHeadersVisualStyles = false;
            dgvUsuarios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(28, 28, 28);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvUsuarios.ColumnHeadersHeight = 35;

            // Estilo Padrão das Linhas (CORREÇÃO PRINCIPAL)
            dgvUsuarios.RowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(55, 55, 58);
            dgvUsuarios.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.White; // Texto BRANCO
            dgvUsuarios.RowsDefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvUsuarios.RowTemplate.Height = 30;

            // Estilo da Linha Selecionada
            var skinManager = MaterialSkin.MaterialSkinManager.Instance;
            dgvUsuarios.DefaultCellStyle.SelectionBackColor = skinManager.ColorScheme.PrimaryColor;
            dgvUsuarios.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                DataGridViewRow linha = dgvUsuarios.SelectedRows[0];
                txtNomeEditar.Text = linha.Cells["Nome"].Value.ToString();
                txtEmailEditar.Text = linha.Cells["Email"].Value.ToString();
                txtSenhaEditar.Text = "";

                _usuarioSelecionado = new { ID = Convert.ToInt32(linha.Cells["ID"].Value), Tipo = linha.Cells["Tipo"].Value.ToString() };

                btnSalvarEdicao.Enabled = true;
                btnExcluir.Enabled = true;
            }
        }

        private void btnFiltrar_Click_1(object sender, EventArgs e)
        {
            // Abre o novo formulário de popup para os filtros
            frmFiltros formFiltros = new frmFiltros();

            // Se o utilizador clicar em "Aplicar Filtros" no popup
            if (formFiltros.ShowDialog() == DialogResult.OK)
            {
                // Lê os filtros do popup e chama o método para carregar os dados
                CarregarUsuarios(formFiltros.FiltroTipo, formFiltros.FiltroNome, formFiltros.FiltroEmail);
            }
        }

        private void btnSalvarEdicao_Click_1(object sender, EventArgs e)
        {
            if (_usuarioSelecionado == null)
            {
                MessageBox.Show("Por favor, selecione um utilizador na lista para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNomeEditar.Text) || string.IsNullOrWhiteSpace(txtEmailEditar.Text))
            {
                MessageBox.Show("Os campos Nome e Email não podem estar vazios.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool sucesso = false;
            switch (_usuarioSelecionado.Tipo)
            {
                case "Usuário":
                    var usuario = new Usuario { IdUsuario = _usuarioSelecionado.ID, Nome = txtNomeEditar.Text, Email = txtEmailEditar.Text, Senha = txtSenhaEditar.Text };
                    sucesso = new UsuarioDAL().Atualizar(usuario);
                    break;
                case "Técnico":
                    var tecnico = new Tecnico { IdTecnico = _usuarioSelecionado.ID, Nome = txtNomeEditar.Text, Email = txtEmailEditar.Text, Senha = txtSenhaEditar.Text };
                    sucesso = new TecnicoDAL().Atualizar(tecnico);
                    break;
                case "Admin":
                    var admin = new Admin { IdAdmin = _usuarioSelecionado.ID, Nome = txtNomeEditar.Text, Email = txtEmailEditar.Text, Senha = txtSenhaEditar.Text };
                    sucesso = new AdminDAL().Atualizar(admin);
                    break;
            }

            if (sucesso)
            {
                MessageBox.Show("Utilizador atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregarUsuarios("Todos", "", "");
            }
            else
            {
                MessageBox.Show("Falha ao atualizar o utilizador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            if (_usuarioSelecionado == null)
            {
                MessageBox.Show("Por favor, selecione um utilizador na lista para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show($"Tem a certeza de que deseja excluir o {_usuarioSelecionado.Tipo} '{txtNomeEditar.Text}'?", "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                bool sucesso = false;
                switch (_usuarioSelecionado.Tipo)
                {
                    case "Usuário":
                        sucesso = new UsuarioDAL().Excluir(_usuarioSelecionado.ID);
                        break;
                    case "Técnico":
                        sucesso = new TecnicoDAL().Excluir(_usuarioSelecionado.ID);
                        break;
                    case "Admin":
                        sucesso = new AdminDAL().Excluir(_usuarioSelecionado.ID);
                        break;
                }

                if (sucesso)
                {
                    MessageBox.Show("Utilizador excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarUsuarios("Todos", "", "");
                }
                else
                {
                    MessageBox.Show("Falha ao excluir o utilizador. Verifique se ele não está vinculado a chamados existentes.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCamposEdicao();
        }

        

        // ====================================================================
        // LÓGICA DA ABA "RELATÓRIOS"
        // ====================================================================
        private void btnGerarRelatorio_Click(object sender, EventArgs e)

        {

            try

            {
                DateTime dataInicio = dtpDataInicio.Value.Date; // .Date pega apenas a data, sem a hora
                DateTime dataFim = dtpDataFim.Value.Date.AddDays(1).AddTicks(-1); // Pega até o final do dia selecionado

                // 1. Buscar os dados (código existente)

                ChamadoDAL chamadoDal = new ChamadoDAL();
                List<Chamado> listaDeChamados = chamadoDal.ListarTodosParaRelatorio(dataInicio, dataFim);

                string caminhoArquivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RelatorioDeChamados.pdf");



                // 2. Gerar o documento PDF com layout aprimorado

                Document.Create(container =>

                {

                    container.Page(page =>

                    {

                        // Configurações da página

                        page.Margin(30);

                        page.PageColor(Colors.White);

                        page.DefaultTextStyle(x => x.FontSize(10));



                        // Cabeçalho do Relatório

                        page.Header()

                            .BorderBottom(1)

                            .Padding(10)

                            .Row(row =>

                            {

                                row.RelativeItem().Text("Relatório de Chamados - Help Desk System")

                                    .Bold().FontSize(16).FontColor(Colors.Grey.Darken4);



                                row.ConstantItem(100).AlignRight().Text(DateTime.Now.ToString("dd/MM/yyyy"))

                                    .FontSize(10);

                            });



                        // Conteúdo Principal (Tabela)

                        page.Content()

                            .PaddingVertical(20)

                            .Table(table =>

                            {

                                // Definição das colunas

                                table.ColumnsDefinition(columns =>

                                {

                                    columns.ConstantColumn(40);  // ID

                                    columns.RelativeColumn(3);   // Solicitante

                                    columns.RelativeColumn(3);   // Técnico

                                    columns.RelativeColumn(2);   // Abertura

                                    columns.RelativeColumn(2);   // Fechamento

                                    columns.RelativeColumn(2);   // Status

                                });



                                // Cabeçalho da Tabela

                                table.Header(header =>

                                {

                                    header.Cell().Background(Colors.Grey.Lighten1).Padding(5).Text("ID").Bold();

                                    header.Cell().Background(Colors.Grey.Lighten1).Padding(5).Text("Solicitante").Bold();

                                    header.Cell().Background(Colors.Grey.Lighten1).Padding(5).Text("Técnico").Bold();

                                    header.Cell().Background(Colors.Grey.Lighten1).Padding(5).Text("Abertura").Bold();

                                    header.Cell().Background(Colors.Grey.Lighten1).Padding(5).Text("Fechamento").Bold();

                                    header.Cell().Background(Colors.Grey.Lighten1).Padding(5).Text("Status").Bold();

                                });



                                // Linhas da Tabela

                                foreach (var chamado in listaDeChamados)

                                {

                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(chamado.IdChamado);

                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(chamado.NomeUsuario);

                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(chamado.NomeTecnico);

                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(chamado.DataAbertura.ToString("dd/MM/yy"));

                                    // Exibe a data de fechamento ou um traço se for nula

                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(chamado.DataFechamento?.ToString("dd/MM/yy") ?? "-");

                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(chamado.Status);

                                }

                            });



                        // Rodapé

                        page.Footer()

                            .AlignCenter()

                            .Text(x =>

                            {

                                x.Span("Página ");

                                x.CurrentPageNumber();

                                x.Span(" de ");

                                x.TotalPages();

                            });

                    });

                }).GeneratePdf(caminhoArquivo);



                // 3. Avisar o usuário e abrir o arquivo

                MessageBox.Show($"Relatório salvo com sucesso em:\n{caminhoArquivo}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Process.Start(new ProcessStartInfo(caminhoArquivo) { UseShellExecute = true });

            }

            catch (Exception ex)

            {

                MessageBox.Show("Ocorreu um erro ao gerar o relatório: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}