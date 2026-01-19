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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DigitalNotesManager
{

    public partial class MainForm : Form
    {
        private User currentUser;
        private BindingSource notesBinding = new BindingSource();

        public MainForm()
        {
            InitializeComponent();
            this.IsMdiContainer = false;

            dgvNotes.AutoGenerateColumns = true;
            dgvNotes.DataSource = notesBinding;
            dgvNotes.AllowUserToAddRows = false;
        }



        public void SetCurrentUser(User user)
        {
            currentUser = user;
            LoadNotes();
            LoadCategories();
        }


        private void LoadNotes(string search = null, string category = null)
        {
            if (currentUser == null) return;

            using var db = new DigitalNotesManagerContext();

            var notesQuery = db.Notes
                .Where(n => n.UserID == currentUser.UserID);

            if (!string.IsNullOrWhiteSpace(search))
            {
                var s = search;
                notesQuery = notesQuery.Where(n =>
                    (n.Title ?? "").Contains(s) ||
                    (n.Category ?? "").Contains(s));
            }

            if (!string.IsNullOrWhiteSpace(category) && category != "All")
            {
                notesQuery = notesQuery.Where(n => n.Category == category);
            }

            // Use Select with index to create Index column starting at 1
            var list = notesQuery
                .OrderByDescending(n => n.CreationDate)
                .ToList()
                .Select((n, i) => new
                {
                    Index = i + 1,
                    n.NoteID,
                    n.Title,
                    Category = n.Category ?? "General",
                    CreatedDate = n.CreationDate,
                    ReminderDate = n.ReminderDate
                })
                .ToList();

            dgvNotes.DataSource = list;

            // Hide NoteID column (keep it in DataSource for internal use)
            if (dgvNotes.Columns.Contains("NoteID"))
                dgvNotes.Columns["NoteID"].Visible = false;

            // Optionally rename headers
            if (dgvNotes.Columns.Contains("Index"))
                dgvNotes.Columns["Index"].HeaderText = "#";
            if (dgvNotes.Columns.Contains("Title"))
                dgvNotes.Columns["Title"].HeaderText = "Title";
            if (dgvNotes.Columns.Contains("Category"))
                dgvNotes.Columns["Category"].HeaderText = "Category";
            if (dgvNotes.Columns.Contains("CreatedDate"))
                dgvNotes.Columns["CreatedDate"].HeaderText = "Created Date";
            if (dgvNotes.Columns.Contains("ReminderDate"))
                dgvNotes.Columns["ReminderDate"].HeaderText = "Reminder Date";

        }

        private void LoadCategories()
        {
            if (currentUser == null) return;

            using var db = new DigitalNotesManagerContext();

            var categories = db.Notes
                .Where(n => n.UserID == currentUser.UserID && !string.IsNullOrWhiteSpace(n.Category))
                .Select(n => n.Category)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            cmbFilterCategory.Items.Clear();
            cmbFilterCategory.Items.Add("All");
            cmbFilterCategory.Items.AddRange(categories.ToArray());
            cmbFilterCategory.SelectedIndex = 0;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // 1) Reload the notes
            LoadNotes();

            // 2) Reset category filter to "All"
            if (cmbFilterCategory.Items.Contains("All"))
                cmbFilterCategory.SelectedItem = "All";

            // 3) Clear the search box
            txtSearch.Text = string.Empty;
        }


        private void CreateNoteForm_NoteCreated(object sender, EventArgs e)
        {
            LoadNotes(); // Refresh the table when note is created
        }
        private void dgvNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                // Get NoteID from hidden column
                var noteIdObj = dgvNotes.Rows[e.RowIndex].Cells["NoteID"].Value;
                if (noteIdObj == null) return;

                int noteId = Convert.ToInt32(noteIdObj);

                using var db = new DigitalNotesManagerContext();
                var note = db.Notes.FirstOrDefault(n => n.NoteID == noteId && n.UserID == currentUser.UserID);

                if (note == null)
                {
                    MessageBox.Show("Note not found or does not belong to current user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var editorForm = new NoteEditorForm();
                editorForm.SetCurrentUser(currentUser);
                editorForm.SetNoteToEdit(note);

                editorForm.NoteSaved += (s, n2) =>
                {
                    LoadNotes();
                    LoadCategories();
                };

                editorForm.StartPosition = FormStartPosition.CenterScreen;
                editorForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening the note:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void FilterByCategory(string category)
        {
            if (currentUser == null) return;
            if (string.IsNullOrEmpty(category)) return;

            LoadNotes(null, category);
        }
        private void cmbFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sel = cmbFilterCategory.SelectedItem?.ToString() ?? "All";
            FilterByCategory(sel);
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchText = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadNotes();
                return;
            }
            LoadNotes(searchText, cmbFilterCategory.SelectedItem?.ToString());
        }
        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvNotes.CurrentRow == null)
            {
                MessageBox.Show("Please select a note to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var noteIdObj = dgvNotes.CurrentRow.Cells["NoteID"].Value;
            if (noteIdObj == null) return;
            int noteId = Convert.ToInt32(noteIdObj);

            var result = MessageBox.Show("Are you sure you want to delete this note?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            using var db = new DigitalNotesManagerContext();
            var noteToDelete = db.Notes.FirstOrDefault(n => n.NoteID == noteId && n.UserID == currentUser.UserID);
            if (noteToDelete != null)
            {
                db.Notes.Remove(noteToDelete);
                db.SaveChanges();
                MessageBox.Show("Note deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNotes();
            }
            else
            {
                MessageBox.Show("Note not found or does not belong to current user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
