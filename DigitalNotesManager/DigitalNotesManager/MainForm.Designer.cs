namespace DigitalNotesManager
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            toolStripMainForm = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            txtSearch = new ToolStripTextBox();
            btnSearch = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            lblSearch = new ToolStripLabel();
            cmbFilterCategory = new ToolStripComboBox();
            toolStripSeparator2 = new ToolStripSeparator();
            btnRefresh = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            btnDelete = new ToolStripButton();
            dgvNotes = new DataGridView();
            toolStripMainForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNotes).BeginInit();
            SuspendLayout();
            // 
            // toolStripMainForm
            // 
            toolStripMainForm.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolStripMainForm.Items.AddRange(new ToolStripItem[] { toolStripLabel1, txtSearch, btnSearch, toolStripSeparator1, lblSearch, cmbFilterCategory, toolStripSeparator2, btnRefresh, toolStripSeparator3, btnDelete });
            toolStripMainForm.Location = new Point(0, 0);
            toolStripMainForm.Name = "toolStripMainForm";
            toolStripMainForm.Size = new Size(800, 25);
            toolStripMainForm.TabIndex = 1;
            toolStripMainForm.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(56, 22);
            toolStripLabel1.Text = "Search:";
            // 
            // txtSearch
            // 
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(100, 25);
            // 
            // btnSearch
            // 
            btnSearch.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSearch.Image = (Image)resources.GetObject("btnSearch.Image");
            btnSearch.ImageTransparentColor = Color.Magenta;
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(23, 22);
            btnSearch.Text = "Search";
            btnSearch.ToolTipText = "Search";
            btnSearch.Click += btnSearch_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // lblSearch
            // 
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(129, 22);
            lblSearch.Text = "Filter by Category:";
            // 
            // cmbFilterCategory
            // 
            cmbFilterCategory.Name = "cmbFilterCategory";
            cmbFilterCategory.Size = new Size(121, 25);
            cmbFilterCategory.SelectedIndexChanged += cmbFilterCategory_SelectedIndexChanged;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // btnRefresh
            // 
            btnRefresh.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnRefresh.Image = (Image)resources.GetObject("btnRefresh.Image");
            btnRefresh.ImageTransparentColor = Color.Magenta;
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(23, 22);
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // btnDelete
            // 
            btnDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            btnDelete.ImageTransparentColor = Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(23, 22);
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvNotes
            // 
            dgvNotes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNotes.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvNotes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvNotes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNotes.Dock = DockStyle.Fill;
            dgvNotes.Location = new Point(0, 25);
            dgvNotes.Name = "dgvNotes";
            dgvNotes.Size = new Size(800, 425);
            dgvNotes.TabIndex = 2;
            dgvNotes.CellDoubleClick += dgvNotes_CellDoubleClick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.ForestGreen;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvNotes);
            Controls.Add(toolStripMainForm);
            IsMdiContainer = true;
            Name = "MainForm";
            Text = "MainForm";
            toolStripMainForm.ResumeLayout(false);
            toolStripMainForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNotes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStrip toolStripMainForm;
        private DataGridView dgvNotes;
        private ToolStripTextBox txtSearch;
        private ToolStripButton btnSearch;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel lblSearch;
        private ToolStripComboBox cmbFilterCategory;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnRefresh;
        private ToolStripLabel toolStripLabel1;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton btnDelete;
    }
}