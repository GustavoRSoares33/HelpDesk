namespace HelpDesk.Desktop
{
    partial class frmAdminDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            btnCadastrarNovo = new MaterialSkin.Controls.MaterialButton();
            tableLayoutPanel1 = new TableLayoutPanel();
            txtNomeNovo = new MaterialSkin.Controls.MaterialTextBox2();
            txtSenhaNovo = new MaterialSkin.Controls.MaterialTextBox2();
            cmbTipoContaNovo = new MaterialSkin.Controls.MaterialComboBox();
            txtEmailNovo = new MaterialSkin.Controls.MaterialTextBox2();
            tabPage2 = new TabPage();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel1 = new Panel();
            btnFiltrar = new MaterialSkin.Controls.MaterialButton();
            dgvUsuarios = new DataGridView();
            tableLayoutPanel3 = new TableLayoutPanel();
            txtNomeEditar = new MaterialSkin.Controls.MaterialTextBox2();
            txtEmailEditar = new MaterialSkin.Controls.MaterialTextBox2();
            txtSenhaEditar = new MaterialSkin.Controls.MaterialTextBox2();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnSalvarEdicao = new MaterialSkin.Controls.MaterialButton();
            btnExcluir = new MaterialSkin.Controls.MaterialButton();
            btnLimpar = new MaterialSkin.Controls.MaterialButton();
            tabPage3 = new TabPage();
            btnGerarRelatorio = new MaterialSkin.Controls.MaterialButton();
            tableLayoutPanel4 = new TableLayoutPanel();
            dtpDataFim = new DateTimePicker();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            dtpDataInicio = new DateTimePicker();
            materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            materialTabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tabPage2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tabPage3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(tabPage1);
            materialTabControl1.Controls.Add(tabPage2);
            materialTabControl1.Controls.Add(tabPage3);
            materialTabControl1.Depth = 0;
            materialTabControl1.Location = new Point(3, 105);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(908, 471);
            materialTabControl1.TabIndex = 18;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.Transparent;
            tabPage1.Controls.Add(btnCadastrarNovo);
            tabPage1.Controls.Add(tableLayoutPanel1);
            tabPage1.ForeColor = SystemColors.ControlText;
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(900, 443);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Cadastrar Usuários";
            // 
            // btnCadastrarNovo
            // 
            btnCadastrarNovo.Anchor = AnchorStyles.Right;
            btnCadastrarNovo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCadastrarNovo.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCadastrarNovo.Depth = 0;
            btnCadastrarNovo.HighEmphasis = true;
            btnCadastrarNovo.Icon = null;
            btnCadastrarNovo.Location = new Point(394, 362);
            btnCadastrarNovo.Margin = new Padding(4, 6, 4, 6);
            btnCadastrarNovo.MouseState = MaterialSkin.MouseState.HOVER;
            btnCadastrarNovo.Name = "btnCadastrarNovo";
            btnCadastrarNovo.NoAccentTextColor = Color.Empty;
            btnCadastrarNovo.Size = new Size(106, 36);
            btnCadastrarNovo.TabIndex = 17;
            btnCadastrarNovo.Text = "Cadastrar";
            btnCadastrarNovo.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCadastrarNovo.UseAccentColor = false;
            btnCadastrarNovo.UseVisualStyleBackColor = true;
            btnCadastrarNovo.Click += btnCadastrarNovo_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(txtNomeNovo, 0, 0);
            tableLayoutPanel1.Controls.Add(txtSenhaNovo, 1, 0);
            tableLayoutPanel1.Controls.Add(cmbTipoContaNovo, 1, 2);
            tableLayoutPanel1.Controls.Add(txtEmailNovo, 0, 2);
            tableLayoutPanel1.Location = new Point(3, 6);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(901, 138);
            tableLayoutPanel1.TabIndex = 22;
            // 
            // txtNomeNovo
            // 
            txtNomeNovo.AnimateReadOnly = false;
            txtNomeNovo.BackgroundImageLayout = ImageLayout.None;
            txtNomeNovo.CharacterCasing = CharacterCasing.Normal;
            txtNomeNovo.Depth = 0;
            txtNomeNovo.Dock = DockStyle.Fill;
            txtNomeNovo.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtNomeNovo.HideSelection = true;
            txtNomeNovo.Hint = "Nome Completo";
            txtNomeNovo.LeadingIcon = null;
            txtNomeNovo.Location = new Point(10, 10);
            txtNomeNovo.Margin = new Padding(10);
            txtNomeNovo.MaxLength = 32767;
            txtNomeNovo.MouseState = MaterialSkin.MouseState.OUT;
            txtNomeNovo.Name = "txtNomeNovo";
            txtNomeNovo.PasswordChar = '\0';
            txtNomeNovo.PrefixSuffixText = null;
            txtNomeNovo.ReadOnly = false;
            txtNomeNovo.RightToLeft = RightToLeft.No;
            txtNomeNovo.SelectedText = "";
            txtNomeNovo.SelectionLength = 0;
            txtNomeNovo.SelectionStart = 0;
            txtNomeNovo.ShortcutsEnabled = true;
            txtNomeNovo.Size = new Size(430, 48);
            txtNomeNovo.TabIndex = 18;
            txtNomeNovo.TabStop = false;
            txtNomeNovo.Tag = "";
            txtNomeNovo.TextAlign = HorizontalAlignment.Left;
            txtNomeNovo.TrailingIcon = null;
            txtNomeNovo.UseSystemPasswordChar = false;
            // 
            // txtSenhaNovo
            // 
            txtSenhaNovo.AnimateReadOnly = false;
            txtSenhaNovo.BackgroundImageLayout = ImageLayout.None;
            txtSenhaNovo.CharacterCasing = CharacterCasing.Normal;
            txtSenhaNovo.Depth = 0;
            txtSenhaNovo.Dock = DockStyle.Fill;
            txtSenhaNovo.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSenhaNovo.HideSelection = true;
            txtSenhaNovo.Hint = "Senha";
            txtSenhaNovo.LeadingIcon = null;
            txtSenhaNovo.Location = new Point(460, 10);
            txtSenhaNovo.Margin = new Padding(10);
            txtSenhaNovo.MaxLength = 32767;
            txtSenhaNovo.MouseState = MaterialSkin.MouseState.OUT;
            txtSenhaNovo.Name = "txtSenhaNovo";
            txtSenhaNovo.PasswordChar = '\0';
            txtSenhaNovo.PrefixSuffixText = null;
            txtSenhaNovo.ReadOnly = false;
            txtSenhaNovo.RightToLeft = RightToLeft.No;
            txtSenhaNovo.SelectedText = "";
            txtSenhaNovo.SelectionLength = 0;
            txtSenhaNovo.SelectionStart = 0;
            txtSenhaNovo.ShortcutsEnabled = true;
            txtSenhaNovo.Size = new Size(431, 48);
            txtSenhaNovo.TabIndex = 20;
            txtSenhaNovo.TabStop = false;
            txtSenhaNovo.TextAlign = HorizontalAlignment.Left;
            txtSenhaNovo.TrailingIcon = null;
            txtSenhaNovo.UseSystemPasswordChar = false;
            // 
            // cmbTipoContaNovo
            // 
            cmbTipoContaNovo.AutoResize = false;
            cmbTipoContaNovo.BackColor = Color.FromArgb(255, 255, 255);
            cmbTipoContaNovo.Depth = 0;
            cmbTipoContaNovo.Dock = DockStyle.Fill;
            cmbTipoContaNovo.DrawMode = DrawMode.OwnerDrawVariable;
            cmbTipoContaNovo.DropDownHeight = 174;
            cmbTipoContaNovo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoContaNovo.DropDownWidth = 121;
            cmbTipoContaNovo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbTipoContaNovo.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbTipoContaNovo.FormattingEnabled = true;
            cmbTipoContaNovo.Hint = "Tipo do Usuário";
            cmbTipoContaNovo.IntegralHeight = false;
            cmbTipoContaNovo.ItemHeight = 43;
            cmbTipoContaNovo.Items.AddRange(new object[] { "Usuário", "Técnico", "Admin" });
            cmbTipoContaNovo.Location = new Point(460, 78);
            cmbTipoContaNovo.Margin = new Padding(10);
            cmbTipoContaNovo.MaxDropDownItems = 4;
            cmbTipoContaNovo.MouseState = MaterialSkin.MouseState.OUT;
            cmbTipoContaNovo.Name = "cmbTipoContaNovo";
            cmbTipoContaNovo.Size = new Size(431, 49);
            cmbTipoContaNovo.StartIndex = 0;
            cmbTipoContaNovo.TabIndex = 21;
            // 
            // txtEmailNovo
            // 
            txtEmailNovo.AnimateReadOnly = false;
            txtEmailNovo.BackgroundImageLayout = ImageLayout.None;
            txtEmailNovo.CharacterCasing = CharacterCasing.Normal;
            txtEmailNovo.Depth = 0;
            txtEmailNovo.Dock = DockStyle.Fill;
            txtEmailNovo.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtEmailNovo.HideSelection = true;
            txtEmailNovo.Hint = "Email";
            txtEmailNovo.LeadingIcon = null;
            txtEmailNovo.Location = new Point(10, 78);
            txtEmailNovo.Margin = new Padding(10);
            txtEmailNovo.MaxLength = 32767;
            txtEmailNovo.MouseState = MaterialSkin.MouseState.OUT;
            txtEmailNovo.Name = "txtEmailNovo";
            txtEmailNovo.PasswordChar = '\0';
            txtEmailNovo.PrefixSuffixText = null;
            txtEmailNovo.ReadOnly = false;
            txtEmailNovo.RightToLeft = RightToLeft.No;
            txtEmailNovo.SelectedText = "";
            txtEmailNovo.SelectionLength = 0;
            txtEmailNovo.SelectionStart = 0;
            txtEmailNovo.ShortcutsEnabled = true;
            txtEmailNovo.Size = new Size(430, 48);
            txtEmailNovo.TabIndex = 19;
            txtEmailNovo.TabStop = false;
            txtEmailNovo.TextAlign = HorizontalAlignment.Left;
            txtEmailNovo.TrailingIcon = null;
            txtEmailNovo.UseSystemPasswordChar = false;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(tableLayoutPanel2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(900, 443);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Gerenciar Usuários";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.Controls.Add(panel1, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(894, 437);
            tableLayoutPanel2.TabIndex = 31;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnFiltrar);
            panel1.Controls.Add(dgvUsuarios);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(530, 431);
            panel1.TabIndex = 0;
            // 
            // btnFiltrar
            // 
            btnFiltrar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnFiltrar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnFiltrar.Depth = 0;
            btnFiltrar.HighEmphasis = true;
            btnFiltrar.Icon = null;
            btnFiltrar.Location = new Point(4, 3);
            btnFiltrar.Margin = new Padding(4, 6, 4, 6);
            btnFiltrar.MouseState = MaterialSkin.MouseState.HOVER;
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.NoAccentTextColor = Color.Empty;
            btnFiltrar.Size = new Size(79, 36);
            btnFiltrar.TabIndex = 29;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnFiltrar.UseAccentColor = false;
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click_1;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(4, 48);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.Size = new Size(523, 371);
            dgvUsuarios.TabIndex = 0;
            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.None;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(txtNomeEditar, 0, 0);
            tableLayoutPanel3.Controls.Add(txtEmailEditar, 0, 1);
            tableLayoutPanel3.Controls.Add(txtSenhaEditar, 0, 2);
            tableLayoutPanel3.Controls.Add(flowLayoutPanel1, 0, 3);
            tableLayoutPanel3.Location = new Point(539, 56);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 4;
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.Size = new Size(352, 325);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // txtNomeEditar
            // 
            txtNomeEditar.AnimateReadOnly = false;
            txtNomeEditar.BackgroundImageLayout = ImageLayout.None;
            txtNomeEditar.CharacterCasing = CharacterCasing.Normal;
            txtNomeEditar.Depth = 0;
            txtNomeEditar.Dock = DockStyle.Fill;
            txtNomeEditar.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtNomeEditar.HideSelection = true;
            txtNomeEditar.Hint = "Nome";
            txtNomeEditar.LeadingIcon = null;
            txtNomeEditar.Location = new Point(10, 10);
            txtNomeEditar.Margin = new Padding(10);
            txtNomeEditar.MaxLength = 32767;
            txtNomeEditar.MouseState = MaterialSkin.MouseState.OUT;
            txtNomeEditar.Name = "txtNomeEditar";
            txtNomeEditar.PasswordChar = '\0';
            txtNomeEditar.PrefixSuffixText = null;
            txtNomeEditar.ReadOnly = false;
            txtNomeEditar.RightToLeft = RightToLeft.No;
            txtNomeEditar.SelectedText = "";
            txtNomeEditar.SelectionLength = 0;
            txtNomeEditar.SelectionStart = 0;
            txtNomeEditar.ShortcutsEnabled = true;
            txtNomeEditar.Size = new Size(332, 48);
            txtNomeEditar.TabIndex = 24;
            txtNomeEditar.TabStop = false;
            txtNomeEditar.TextAlign = HorizontalAlignment.Left;
            txtNomeEditar.TrailingIcon = null;
            txtNomeEditar.UseSystemPasswordChar = false;
            // 
            // txtEmailEditar
            // 
            txtEmailEditar.AnimateReadOnly = false;
            txtEmailEditar.BackgroundImageLayout = ImageLayout.None;
            txtEmailEditar.CharacterCasing = CharacterCasing.Normal;
            txtEmailEditar.Depth = 0;
            txtEmailEditar.Dock = DockStyle.Fill;
            txtEmailEditar.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtEmailEditar.HideSelection = true;
            txtEmailEditar.Hint = "Email";
            txtEmailEditar.LeadingIcon = null;
            txtEmailEditar.Location = new Point(10, 78);
            txtEmailEditar.Margin = new Padding(10);
            txtEmailEditar.MaxLength = 32767;
            txtEmailEditar.MouseState = MaterialSkin.MouseState.OUT;
            txtEmailEditar.Name = "txtEmailEditar";
            txtEmailEditar.PasswordChar = '\0';
            txtEmailEditar.PrefixSuffixText = null;
            txtEmailEditar.ReadOnly = false;
            txtEmailEditar.RightToLeft = RightToLeft.No;
            txtEmailEditar.SelectedText = "";
            txtEmailEditar.SelectionLength = 0;
            txtEmailEditar.SelectionStart = 0;
            txtEmailEditar.ShortcutsEnabled = true;
            txtEmailEditar.Size = new Size(332, 48);
            txtEmailEditar.TabIndex = 25;
            txtEmailEditar.TabStop = false;
            txtEmailEditar.TextAlign = HorizontalAlignment.Left;
            txtEmailEditar.TrailingIcon = null;
            txtEmailEditar.UseSystemPasswordChar = false;
            // 
            // txtSenhaEditar
            // 
            txtSenhaEditar.AnimateReadOnly = false;
            txtSenhaEditar.BackgroundImageLayout = ImageLayout.None;
            txtSenhaEditar.CharacterCasing = CharacterCasing.Normal;
            txtSenhaEditar.Depth = 0;
            txtSenhaEditar.Dock = DockStyle.Fill;
            txtSenhaEditar.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSenhaEditar.HideSelection = true;
            txtSenhaEditar.Hint = "Senha";
            txtSenhaEditar.LeadingIcon = null;
            txtSenhaEditar.Location = new Point(10, 146);
            txtSenhaEditar.Margin = new Padding(10);
            txtSenhaEditar.MaxLength = 32767;
            txtSenhaEditar.MouseState = MaterialSkin.MouseState.OUT;
            txtSenhaEditar.Name = "txtSenhaEditar";
            txtSenhaEditar.PasswordChar = '\0';
            txtSenhaEditar.PrefixSuffixText = null;
            txtSenhaEditar.ReadOnly = false;
            txtSenhaEditar.RightToLeft = RightToLeft.No;
            txtSenhaEditar.SelectedText = "";
            txtSenhaEditar.SelectionLength = 0;
            txtSenhaEditar.SelectionStart = 0;
            txtSenhaEditar.ShortcutsEnabled = true;
            txtSenhaEditar.Size = new Size(332, 48);
            txtSenhaEditar.TabIndex = 26;
            txtSenhaEditar.TabStop = false;
            txtSenhaEditar.TextAlign = HorizontalAlignment.Left;
            txtSenhaEditar.TrailingIcon = null;
            txtSenhaEditar.UseSystemPasswordChar = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.None;
            flowLayoutPanel1.Controls.Add(btnSalvarEdicao);
            flowLayoutPanel1.Controls.Add(btnExcluir);
            flowLayoutPanel1.Controls.Add(btnLimpar);
            flowLayoutPanel1.Location = new Point(48, 239);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(255, 51);
            flowLayoutPanel1.TabIndex = 27;
            // 
            // btnSalvarEdicao
            // 
            btnSalvarEdicao.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSalvarEdicao.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSalvarEdicao.Depth = 0;
            btnSalvarEdicao.HighEmphasis = true;
            btnSalvarEdicao.Icon = null;
            btnSalvarEdicao.Location = new Point(4, 6);
            btnSalvarEdicao.Margin = new Padding(4, 6, 4, 6);
            btnSalvarEdicao.MouseState = MaterialSkin.MouseState.HOVER;
            btnSalvarEdicao.Name = "btnSalvarEdicao";
            btnSalvarEdicao.NoAccentTextColor = Color.Empty;
            btnSalvarEdicao.Size = new Size(76, 36);
            btnSalvarEdicao.TabIndex = 27;
            btnSalvarEdicao.Text = "Salvar";
            btnSalvarEdicao.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSalvarEdicao.UseAccentColor = false;
            btnSalvarEdicao.UseVisualStyleBackColor = true;
            btnSalvarEdicao.Click += btnSalvarEdicao_Click_1;
            // 
            // btnExcluir
            // 
            btnExcluir.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnExcluir.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnExcluir.Depth = 0;
            btnExcluir.HighEmphasis = true;
            btnExcluir.Icon = null;
            btnExcluir.Location = new Point(88, 6);
            btnExcluir.Margin = new Padding(4, 6, 4, 6);
            btnExcluir.MouseState = MaterialSkin.MouseState.HOVER;
            btnExcluir.Name = "btnExcluir";
            btnExcluir.NoAccentTextColor = Color.Empty;
            btnExcluir.Size = new Size(80, 36);
            btnExcluir.TabIndex = 28;
            btnExcluir.Text = "Excluir";
            btnExcluir.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnExcluir.UseAccentColor = false;
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click_1;
            // 
            // btnLimpar
            // 
            btnLimpar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLimpar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnLimpar.Depth = 0;
            btnLimpar.HighEmphasis = true;
            btnLimpar.Icon = null;
            btnLimpar.Location = new Point(176, 6);
            btnLimpar.Margin = new Padding(4, 6, 4, 6);
            btnLimpar.MouseState = MaterialSkin.MouseState.HOVER;
            btnLimpar.Name = "btnLimpar";
            btnLimpar.NoAccentTextColor = Color.Empty;
            btnLimpar.Size = new Size(75, 36);
            btnLimpar.TabIndex = 30;
            btnLimpar.Text = "Limpar";
            btnLimpar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnLimpar.UseAccentColor = false;
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btnGerarRelatorio);
            tabPage3.Controls.Add(tableLayoutPanel4);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(900, 443);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Relatório";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnGerarRelatorio
            // 
            btnGerarRelatorio.Anchor = AnchorStyles.Top;
            btnGerarRelatorio.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGerarRelatorio.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnGerarRelatorio.Depth = 0;
            btnGerarRelatorio.HighEmphasis = true;
            btnGerarRelatorio.Icon = null;
            btnGerarRelatorio.Location = new Point(410, 27);
            btnGerarRelatorio.Margin = new Padding(4, 6, 4, 6);
            btnGerarRelatorio.MouseState = MaterialSkin.MouseState.HOVER;
            btnGerarRelatorio.Name = "btnGerarRelatorio";
            btnGerarRelatorio.NoAccentTextColor = Color.Empty;
            btnGerarRelatorio.Size = new Size(149, 36);
            btnGerarRelatorio.TabIndex = 28;
            btnGerarRelatorio.Text = "Gerar Relatório";
            btnGerarRelatorio.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnGerarRelatorio.UseAccentColor = false;
            btnGerarRelatorio.UseVisualStyleBackColor = true;
            btnGerarRelatorio.Click += btnGerarRelatorio_Click;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.Anchor = AnchorStyles.None;
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.6666641F));
            tableLayoutPanel4.Controls.Add(dtpDataFim, 1, 1);
            tableLayoutPanel4.Controls.Add(materialLabel1, 0, 0);
            tableLayoutPanel4.Controls.Add(materialLabel2, 0, 1);
            tableLayoutPanel4.Controls.Add(dtpDataInicio, 1, 0);
            tableLayoutPanel4.Location = new Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(400, 100);
            tableLayoutPanel4.TabIndex = 33;
            // 
            // dtpDataFim
            // 
            dtpDataFim.Anchor = AnchorStyles.Left;
            dtpDataFim.Location = new Point(136, 63);
            dtpDataFim.Name = "dtpDataFim";
            dtpDataFim.Size = new Size(200, 23);
            dtpDataFim.TabIndex = 32;
            // 
            // materialLabel1
            // 
            materialLabel1.Anchor = AnchorStyles.Right;
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(28, 15);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(102, 19);
            materialLabel1.TabIndex = 29;
            materialLabel1.Text = "Data de início:";
            // 
            // materialLabel2
            // 
            materialLabel2.Anchor = AnchorStyles.Right;
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(42, 65);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(88, 19);
            materialLabel2.TabIndex = 31;
            materialLabel2.Text = "Data de fim:";
            // 
            // dtpDataInicio
            // 
            dtpDataInicio.Anchor = AnchorStyles.Left;
            dtpDataInicio.Location = new Point(136, 13);
            dtpDataInicio.Name = "dtpDataInicio";
            dtpDataInicio.Size = new Size(200, 23);
            dtpDataInicio.TabIndex = 30;
            // 
            // materialTabSelector1
            // 
            materialTabSelector1.BaseTabControl = materialTabControl1;
            materialTabSelector1.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Normal;
            materialTabSelector1.Depth = 0;
            materialTabSelector1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTabSelector1.Location = new Point(-6, 55);
            materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabSelector1.Name = "materialTabSelector1";
            materialTabSelector1.Size = new Size(929, 49);
            materialTabSelector1.TabIndex = 21;
            materialTabSelector1.Text = "materialTabSelector1";
            // 
            // frmAdminDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(917, 579);
            Controls.Add(materialTabSelector1);
            Controls.Add(materialTabControl1);
            MaximizeBox = false;
            Name = "frmAdminDashboard";
            Sizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administrador";
            materialTabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage tabPage1;
        private MaterialSkin.Controls.MaterialButton btnCadastrarNovo;
        private TabPage tabPage2;
        private TabPage tabPage3;
        //private ComboBox cmbTipoContaNovo;
        //private TextBox txtSenhaNovo;
        //private TextBox txtEmailNovo;
        private TextBox txt;
        private MaterialSkin.Controls.MaterialComboBox cmbTipoContaNovo;
        private MaterialSkin.Controls.MaterialTextBox2 txtSenhaNovo1;
        private MaterialSkin.Controls.MaterialTextBox2 txtSenhaNovo;
        private MaterialSkin.Controls.MaterialTextBox2 txtEmailNovo;
        private MaterialSkin.Controls.MaterialButton btnFiltrar;
        private MaterialSkin.Controls.MaterialButton btnGerarRelatorio;
        private TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialTextBox2 txtNomeNovo;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel3;
        private MaterialSkin.Controls.MaterialTextBox2 txtNomeEditar;
        private MaterialSkin.Controls.MaterialTextBox2 txtEmailEditar;
        private MaterialSkin.Controls.MaterialTextBox2 txtSenhaEditar;
        private DataGridView dgvUsuarios;
        private FlowLayoutPanel flowLayoutPanel1;
        private MaterialSkin.Controls.MaterialButton btnSalvarEdicao;
        private MaterialSkin.Controls.MaterialButton btnExcluir;
        private MaterialSkin.Controls.MaterialButton btnLimpar;
        private DateTimePicker dtpDataFim;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private DateTimePicker dtpDataInicio;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private TableLayoutPanel tableLayoutPanel4;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
    }
}