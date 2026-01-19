using DigitalNotesManager.Models;
using System.Windows.Forms;

namespace DigitalNotesManager
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true; // Mask password characters with '*'
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Check if username or password is empty
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var db = new DigitalNotesManagerContext();

            // Search for the user in the database
            var user = db.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == password);

            if (user != null)
            {
                // Create MDIForm and pass the current user
                var mdiForm = new MDIForm();
                mdiForm.SetCurrentUser(user);

                // Hide the login form
                this.Hide();

                // Show the MDIForm
                mdiForm.Show();

                // Close the login form when the MDIForm is closed
                mdiForm.FormClosed += (s, args) => this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var db = new DigitalNotesManagerContext();

            // Check if username already exists
            if (db.Users.Any(u => u.Username == username))
            {
                MessageBox.Show("Username already exists. Please choose a different username.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Add the new user to the database
            db.Users.Add(new User
            {
                Username = username,
                PasswordHash = password // Store password
            });
            db.SaveChanges();

            MessageBox.Show("Registration successful! You can now log in.", "Registration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
    }
}
