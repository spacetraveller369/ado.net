using System.Text;
using static EFCore.Program;

namespace EFCore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void Form1_Load(object sender, EventArgs e) { }

        private int? currentUserId = null;

        // Password Hash
        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hash);
            }
        }

        // Sign UP button
        private void signUpBttn_Click(object sender, EventArgs e)
        {
            using (var context = new AppDbContext())
            {
                string username = textBoxLogin.Text;
                string password = textBoxPassword.Text;

                // Check user
                var user = context.Users.SingleOrDefault(u => u.UserName == username);

                if (user != null)
                {
                    MessageBox.Show("User already exists.");
                    return;
                }

                string hashedPassword = HashPassword(password);

                // Create new user
                var newUser = new User
                {
                    UserName = username,
                    PasswordHash = hashedPassword
                };

                context.Users.Add(newUser);
                context.SaveChanges();

                currentUserId = newUser.ID;

                MessageBox.Show("Registration successful.");
            }
        }

        // Sign IN button
        private void signInBttn_Click(object sender, EventArgs e)
        {
            using (var context = new AppDbContext())
            {
                string username = textBoxLogin.Text;
                string password = textBoxPassword.Text;

                var user = context.Users.SingleOrDefault(u => u.UserName == username);

                if (user == null || user.PasswordHash != HashPassword(password))
                {
                    MessageBox.Show("Incorrect username or password.");
                }
                else
                {
                    // Save the ID of the logged in user
                    currentUserId = user.ID;

                    MessageBox.Show("Login successful!");

                    var imgForm = new ImgForm(currentUserId.Value);
                    imgForm.Show();
                }
            }
        }
    }
}
