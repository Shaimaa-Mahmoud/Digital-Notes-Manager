using DigitalNotesManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalNotesManager
{
    public partial class NoteEditorForm : Form
    {
        private Note existingNote; // if editing, this holds the DB note (NOT a separate currentNote)
        private User currentUser;

        public event EventHandler<Note> NoteSaved;


        public NoteEditorForm()
        {
            InitializeComponent();

            dtpReminder.Format = DateTimePickerFormat.Custom;
            dtpReminder.CustomFormat = "dd/MM/yyyy hh:mm tt";
            dtpReminder.ShowCheckBox = true;

            cmbCategory.Items.AddRange(new string[] { "Work", "Personal", "Ideas", "Study" });
            cmbCategory.SelectedIndex = 0;

        }

        public void SetCurrentUser(User user)
        {
            currentUser = user;
        }

        public void SetNoteToEdit(Note note)
        {
            existingNote = note;

            this.Text = "Edit Note";

            txtTitle.Text = note.Title;
            rtbContent.Rtf = note.Content ?? string.Empty;

            if (!string.IsNullOrWhiteSpace(note.Category) && cmbCategory.Items.Contains(note.Category))
                cmbCategory.SelectedItem = note.Category;
            else
                cmbCategory.SelectedIndex = 0;

            if (note.ReminderDate.HasValue)
            {
                dtpReminder.Checked = true;
                dtpReminder.Value = note.ReminderDate.Value;
            }
            else
            {
                dtpReminder.Checked = false;
                dtpReminder.Value = DateTime.Now;
            }
        }

        private void ToggleFontStyle(FontStyle style, bool enable)
        {
            if (rtbContent.SelectionLength > 0)
            {
                // Get current font
                var currentFont = rtbContent.SelectionFont ?? rtbContent.Font;
                var newFontStyle = currentFont.Style;

                if (enable)
                    newFontStyle |= style;  // Add style
                else
                    newFontStyle &= ~style; // Remove style

                rtbContent.SelectionFont = new Font(currentFont, newFontStyle);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentUser == null)
            {
                MessageBox.Show("No user is set. Please re-login.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using var db = new DigitalNotesManagerContext();

            Note noteToSave;

            if (existingNote != null)
            {
                // EDIT mode: load tracked entity from DB and update it
                noteToSave = db.Notes.Find(existingNote.NoteID);
                if (noteToSave == null)
                {
                    MessageBox.Show("Could not find the note in the database to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                // CREATE mode
                noteToSave = new Note
                {
                    CreationDate = DateTime.Now,
                    UserID = currentUser.UserID
                };
                db.Notes.Add(noteToSave);
            }

            // Update fields from UI
            noteToSave.Title = txtTitle.Text.Trim();
            noteToSave.Content = rtbContent.Rtf;
            noteToSave.Category = cmbCategory.SelectedItem?.ToString() ?? "General";
            noteToSave.ReminderDate = dtpReminder.Checked ? dtpReminder.Value : (DateTime?)null;

            // Ensure UserID is set (important if editing)
            if (noteToSave.UserID == 0)
                noteToSave.UserID = currentUser.UserID;

            db.SaveChanges();

            MessageBox.Show("Note saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Notify parent
            NoteSaved?.Invoke(this, noteToSave);

            this.DialogResult = DialogResult.OK;
            this.Close();
        
        }



        private void chkBold_CheckedChanged(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Bold, chkBold.Checked);
        }

        private void chkItalic_CheckedChanged(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Italic, chkItalic.Checked);
        }

        private void chkUnderline_CheckedChanged(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Underline, chkUnderline.Checked);
        }
        public void LoadFromFile(string filePath)
        {
            if (filePath.EndsWith(".rtf"))
            {
                rtbContent.LoadFile(filePath, RichTextBoxStreamType.RichText);
            }
            else if (filePath.EndsWith(".txt"))
            {
                rtbContent.LoadFile(filePath, RichTextBoxStreamType.PlainText);
            }

            txtTitle.Text = Path.GetFileNameWithoutExtension(filePath);
            existingNote = null;

        }

        // Paste
        public void PasteFromClipboard()
        {
            rtbContent.Paste();
        }

        // Copy
        public void CopyToClipboard()
        {
            rtbContent.Copy();
        }

        // Cut
        public void CutToClipboard()
        {
            rtbContent.Cut();
        }

        // Save
        public void SaveNote()
        {
            btnSave_Click(null, null);
        }

        public void ApplySelectedFont(Font font)
        {
            rtbContent.SelectionFont = font;
        }

    }
}
