namespace HelpDesk.Desktop
{
    partial class frmFiltros
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
            tableLayoutPanel1 = new TableLayoutPanel();
            txtFiltroEmail = new MaterialSkin.Controls.MaterialTextBox2();
            cmbFiltroTipo = new MaterialSkin.Controls.MaterialComboBox();
            txtFiltroNome = new MaterialSkin.Controls.MaterialTextBox2();
            btnAplicarFiltros = new MaterialSkin.Controls.MaterialButton();
            btnCancelarFiltros = new MaterialSkin.Controls.MaterialButton();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(txtFiltroEmail, 0, 2);
            tableLayoutPanel1.Controls.Add(cmbFiltroTipo, 0, 0);
            tableLayoutPanel1.Controls.Add(txtFiltroNome, 0, 1);
            tableLayoutPanel1.Location = new Point(62, 73);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(397, 178);
            tableLayoutPanel1.TabIndex = 33;
            // 
            // txtFiltroEmail
            // 
            txtFiltroEmail.AnimateReadOnly = false;
            txtFiltroEmail.BackgroundImageLayout = ImageLayout.None;
            txtFiltroEmail.CharacterCasing = CharacterCasing.Normal;
            txtFiltroEmail.Depth = 0;
            txtFiltroEmail.Dock = DockStyle.Fill;
            txtFiltroEmail.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtFiltroEmail.HideSelection = true;
            txtFiltroEmail.Hint = "Email do Usuário";
            txtFiltroEmail.LeadingIcon = null;
            txtFiltroEmail.Location = new Point(3, 121);
            txtFiltroEmail.MaxLength = 32767;
            txtFiltroEmail.MouseState = MaterialSkin.MouseState.OUT;
            txtFiltroEmail.Name = "txtFiltroEmail";
            txtFiltroEmail.PasswordChar = '\0';
            txtFiltroEmail.PrefixSuffixText = null;
            txtFiltroEmail.ReadOnly = false;
            txtFiltroEmail.RightToLeft = RightToLeft.No;
            txtFiltroEmail.SelectedText = "";
            txtFiltroEmail.SelectionLength = 0;
            txtFiltroEmail.SelectionStart = 0;
            txtFiltroEmail.ShortcutsEnabled = true;
            txtFiltroEmail.Size = new Size(391, 48);
            txtFiltroEmail.TabIndex = 2;
            txtFiltroEmail.TabStop = false;
            txtFiltroEmail.TextAlign = HorizontalAlignment.Left;
            txtFiltroEmail.TrailingIcon = null;
            txtFiltroEmail.UseSystemPasswordChar = false;
            // 
            // cmbFiltroTipo
            // 
            cmbFiltroTipo.AutoResize = false;
            cmbFiltroTipo.BackColor = Color.FromArgb(255, 255, 255);
            cmbFiltroTipo.Depth = 0;
            cmbFiltroTipo.Dock = DockStyle.Fill;
            cmbFiltroTipo.DrawMode = DrawMode.OwnerDrawVariable;
            cmbFiltroTipo.DropDownHeight = 174;
            cmbFiltroTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroTipo.DropDownWidth = 121;
            cmbFiltroTipo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbFiltroTipo.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbFiltroTipo.FormattingEnabled = true;
            cmbFiltroTipo.Hint = "Tipo de Usuário";
            cmbFiltroTipo.IntegralHeight = false;
            cmbFiltroTipo.ItemHeight = 43;
            cmbFiltroTipo.Items.AddRange(new object[] { "Todos", "Usuário", "Técnico", "Admin" });
            cmbFiltroTipo.Location = new Point(3, 3);
            cmbFiltroTipo.MaxDropDownItems = 4;
            cmbFiltroTipo.MouseState = MaterialSkin.MouseState.OUT;
            cmbFiltroTipo.Name = "cmbFiltroTipo";
            cmbFiltroTipo.Size = new Size(391, 49);
            cmbFiltroTipo.StartIndex = 0;
            cmbFiltroTipo.TabIndex = 0;
            // 
            // txtFiltroNome
            // 
            txtFiltroNome.AnimateReadOnly = false;
            txtFiltroNome.BackgroundImageLayout = ImageLayout.None;
            txtFiltroNome.CharacterCasing = CharacterCasing.Normal;
            txtFiltroNome.Depth = 0;
            txtFiltroNome.Dock = DockStyle.Fill;
            txtFiltroNome.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtFiltroNome.HideSelection = true;
            txtFiltroNome.Hint = "Nome do Usuário";
            txtFiltroNome.LeadingIcon = null;
            txtFiltroNome.Location = new Point(3, 62);
            txtFiltroNome.MaxLength = 32767;
            txtFiltroNome.MouseState = MaterialSkin.MouseState.OUT;
            txtFiltroNome.Name = "txtFiltroNome";
            txtFiltroNome.PasswordChar = '\0';
            txtFiltroNome.PrefixSuffixText = null;
            txtFiltroNome.ReadOnly = false;
            txtFiltroNome.RightToLeft = RightToLeft.No;
            txtFiltroNome.SelectedText = "";
            txtFiltroNome.SelectionLength = 0;
            txtFiltroNome.SelectionStart = 0;
            txtFiltroNome.ShortcutsEnabled = true;
            txtFiltroNome.Size = new Size(391, 48);
            txtFiltroNome.TabIndex = 1;
            txtFiltroNome.TabStop = false;
            txtFiltroNome.TextAlign = HorizontalAlignment.Left;
            txtFiltroNome.TrailingIcon = null;
            txtFiltroNome.UseSystemPasswordChar = false;
            // 
            // btnAplicarFiltros
            // 
            btnAplicarFiltros.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAplicarFiltros.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAplicarFiltros.Depth = 0;
            btnAplicarFiltros.HighEmphasis = true;
            btnAplicarFiltros.Icon = null;
            btnAplicarFiltros.Location = new Point(163, 260);
            btnAplicarFiltros.Margin = new Padding(4, 6, 4, 6);
            btnAplicarFiltros.MouseState = MaterialSkin.MouseState.HOVER;
            btnAplicarFiltros.Name = "btnAplicarFiltros";
            btnAplicarFiltros.NoAccentTextColor = Color.Empty;
            btnAplicarFiltros.Size = new Size(81, 36);
            btnAplicarFiltros.TabIndex = 34;
            btnAplicarFiltros.Text = "Aplicar";
            btnAplicarFiltros.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAplicarFiltros.UseAccentColor = false;
            btnAplicarFiltros.UseVisualStyleBackColor = true;
            btnAplicarFiltros.Click += btnAplicarFiltros_Click;
            // 
            // btnCancelarFiltros
            // 
            btnCancelarFiltros.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCancelarFiltros.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCancelarFiltros.Depth = 0;
            btnCancelarFiltros.HighEmphasis = true;
            btnCancelarFiltros.Icon = null;
            btnCancelarFiltros.Location = new Point(252, 260);
            btnCancelarFiltros.Margin = new Padding(4, 6, 4, 6);
            btnCancelarFiltros.MouseState = MaterialSkin.MouseState.HOVER;
            btnCancelarFiltros.Name = "btnCancelarFiltros";
            btnCancelarFiltros.NoAccentTextColor = Color.Empty;
            btnCancelarFiltros.Size = new Size(96, 36);
            btnCancelarFiltros.TabIndex = 35;
            btnCancelarFiltros.Text = "Cancelar";
            btnCancelarFiltros.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCancelarFiltros.UseAccentColor = false;
            btnCancelarFiltros.UseVisualStyleBackColor = true;
            btnCancelarFiltros.Click += btnCancelarFiltros_Click;
            // 
            // frmFiltros
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 313);
            Controls.Add(btnCancelarFiltros);
            Controls.Add(btnAplicarFiltros);
            Controls.Add(tableLayoutPanel1);
            MaximizeBox = false;
            Name = "frmFiltros";
            Sizable = false;
            Text = "Filtros";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialTextBox2 txtFiltroEmail;
        private MaterialSkin.Controls.MaterialComboBox cmbFiltroTipo;
        private MaterialSkin.Controls.MaterialTextBox2 txtFiltroNome;
        private MaterialSkin.Controls.MaterialButton btnAplicarFiltros;
        private MaterialSkin.Controls.MaterialButton btnCancelarFiltros;
    }
}