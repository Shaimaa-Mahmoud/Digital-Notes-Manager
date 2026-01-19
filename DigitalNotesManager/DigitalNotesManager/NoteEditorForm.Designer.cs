namespace DigitalNotesManager
{
    partial class NoteEditorForm
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
            rtbContent = new RichTextBox();
            lblTitle = new Label();
            lblCategory = new Label();
            txtTitle = new TextBox();
            cmbCategory = new ComboBox();
            dtpReminder = new DateTimePicker();
            lblReminder = new Label();
            btnSave = new Button();
            chkBold = new CheckBox();
            chkItalic = new CheckBox();
            chkUnderline = new CheckBox();
            saveFileDialog1 = new SaveFileDialog();
            SuspendLayout();
            // 
            // rtbContent
            // 
            rtbContent.Location = new Point(12, 126);
            rtbContent.Name = "rtbContent";
            rtbContent.Size = new Size(776, 270);
            rtbContent.TabIndex = 0;
            rtbContent.Text = "";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 14.25F);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(24, 19);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(50, 24);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Title:";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Microsoft Sans Serif", 14.25F);
            lblCategory.ForeColor = Color.White;
            lblCategory.Location = new Point(461, 16);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(90, 24);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Category:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(82, 20);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(203, 23);
            txtTitle.TabIndex = 3;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(561, 19);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(200, 23);
            cmbCategory.TabIndex = 4;
            // 
            // dtpReminder
            // 
            dtpReminder.Location = new Point(561, 80);
            dtpReminder.Name = "dtpReminder";
            dtpReminder.Size = new Size(200, 23);
            dtpReminder.TabIndex = 5;
            // 
            // lblReminder
            // 
            lblReminder.AutoSize = true;
            lblReminder.Font = new Font("Microsoft Sans Serif", 14.25F);
            lblReminder.ForeColor = Color.White;
            lblReminder.Location = new Point(450, 78);
            lblReminder.Name = "lblReminder";
            lblReminder.Size = new Size(98, 24);
            lblReminder.TabIndex = 6;
            lblReminder.Text = "Reminder:";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(357, 416);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 33);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save Note";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // chkBold
            // 
            chkBold.AutoSize = true;
            chkBold.Font = new Font("Microsoft Sans Serif", 14.25F);
            chkBold.ForeColor = Color.White;
            chkBold.Location = new Point(30, 80);
            chkBold.Name = "chkBold";
            chkBold.Size = new Size(67, 28);
            chkBold.TabIndex = 8;
            chkBold.Text = "Bold";
            chkBold.UseVisualStyleBackColor = true;
            chkBold.CheckedChanged += chkBold_CheckedChanged;
            // 
            // chkItalic
            // 
            chkItalic.AutoSize = true;
            chkItalic.Font = new Font("Microsoft Sans Serif", 14.25F);
            chkItalic.ForeColor = Color.White;
            chkItalic.Location = new Point(103, 80);
            chkItalic.Name = "chkItalic";
            chkItalic.Size = new Size(65, 28);
            chkItalic.TabIndex = 9;
            chkItalic.Text = "Italic";
            chkItalic.UseVisualStyleBackColor = true;
            chkItalic.CheckedChanged += chkItalic_CheckedChanged;
            // 
            // chkUnderline
            // 
            chkUnderline.AutoSize = true;
            chkUnderline.Font = new Font("Microsoft Sans Serif", 14.25F);
            chkUnderline.ForeColor = Color.White;
            chkUnderline.Location = new Point(174, 80);
            chkUnderline.Name = "chkUnderline";
            chkUnderline.Size = new Size(111, 28);
            chkUnderline.TabIndex = 10;
            chkUnderline.Text = "Underline";
            chkUnderline.UseVisualStyleBackColor = true;
            chkUnderline.CheckedChanged += chkUnderline_CheckedChanged;
            // 
            // NoteEditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.ForestGreen;
            ClientSize = new Size(800, 470);
            Controls.Add(chkUnderline);
            Controls.Add(chkItalic);
            Controls.Add(chkBold);
            Controls.Add(btnSave);
            Controls.Add(lblReminder);
            Controls.Add(dtpReminder);
            Controls.Add(cmbCategory);
            Controls.Add(txtTitle);
            Controls.Add(lblCategory);
            Controls.Add(lblTitle);
            Controls.Add(rtbContent);
            Name = "NoteEditorForm";
            Text = "NoteEditorForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtbContent;
        private Label lblTitle;
        private Label lblCategory;
        private TextBox txtTitle;
        private ComboBox comboBox1;
        private ComboBox cmbCategory;
        private DateTimePicker dtpReminder;
        private Label lblReminder;
        private Button btnSave;
        private CheckBox chkBold;
        private CheckBox chkItalic;
        private CheckBox chkUnderline;
        private SaveFileDialog saveFileDialog1;
    }
}