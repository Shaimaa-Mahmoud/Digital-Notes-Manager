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
    public partial class MDIForm : Form
    {
        private User currentUser;
        private HashSet<int> shownReminders = new HashSet<int>();
        public MDIForm()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        public void SetCurrentUser(User user)
        {
            currentUser = user;
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            NoteEditorForm editor = new NoteEditorForm();
            editor.SetCurrentUser(currentUser);
            
            editor.MdiParent = this;
            editor.WindowState = FormWindowState.Maximized;
            editor.Show();
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog
            {
                Filter = "Rich Text File (*.rtf)|*.rtf|Text Files (*.txt)|*.txt",
                Title = "Open Note File"
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                NoteEditorForm editor = new NoteEditorForm();

                editor.SetCurrentUser(currentUser);

                editor.LoadFromFile(openDialog.FileName);

                editor.MdiParent = this;
                editor.WindowState = FormWindowState.Maximized;
                editor.Show();
            }
           
        }

        private void notesListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm notesForm = new MainForm();
            notesForm.MdiParent = this;      
            notesForm.SetCurrentUser(currentUser); 
            notesForm.Show();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is NoteEditorForm activeNoteForm)
            {
                activeNoteForm.SaveNote();
            }
        }

        private void pastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is NoteEditorForm activeNoteForm)
            {
                activeNoteForm.PasteFromClipboard();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is NoteEditorForm activeNoteForm)
            {
                activeNoteForm.CopyToClipboard();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is NoteEditorForm activeNoteForm)
            {
                activeNoteForm.CutToClipboard();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // Ensure there is a logged-in user
            if (currentUser == null) return;

            using (var db = new DigitalNotesManagerContext())
            {
                var now = DateTime.Now;

                // Fetch notes that have a reminder due
                var dueNotes = db.Notes
                    .Where(n => n.UserID == currentUser.UserID
                                && n.ReminderDate != null
                                && n.ReminderDate > now)
                    .ToList();

                foreach (var note in dueNotes)
                {
                    // Check if this note reminder has already been shown
                    if (!shownReminders.Contains(note.NoteID))
                    {
                        // Show the reminder message
                        DialogResult result = MessageBox.Show(
                            $"Reminder:\n{note.Title}\nTime: {note.ReminderDate}",
                            "Reminder Alert",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        // Add note ID to the set of shown reminders
                        shownReminders.Add(note.NoteID);
                    }
                }
            }

           
        }

        private void MDIForm_Load(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.MdiParent = this;
            mainForm.SetCurrentUser(currentUser);
            mainForm.WindowState = FormWindowState.Maximized;
            mainForm.Show();

            timer.Interval = 60000; // 1 m
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is NoteEditorForm activeNoteEditor)
            {
                FontDialog fontDlg = new FontDialog();

                if (fontDlg.ShowDialog() == DialogResult.OK)
                {
                    activeNoteEditor.ApplySelectedFont(fontDlg.Font);
                }
            }
            else
            {
                MessageBox.Show(
                    "There is no active NoteEditorForm window to apply formatting.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Digital Notes Manager\nVersion 1.0\nDeveloped by Shaimaa Mahmoud - ITI", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
