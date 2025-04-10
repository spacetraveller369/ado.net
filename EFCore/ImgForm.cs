using static EFCore.Program;

namespace EFCore
{
    public partial class ImgForm : Form
    {
        private int userId;

        public ImgForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void bttnUploadPicture_Click(object sender, EventArgs e)
        {
            using (var context = new AppDbContext())
            {
                // Loading image
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                    Title = "Choose photo"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    byte[] imageBytes = File.ReadAllBytes(openFileDialog.FileName);

                    var user = context.Users.SingleOrDefault(u => u.ID == userId);
                    if (user != null)
                    {
                        user.ProfilePicture = imageBytes;
                        context.SaveChanges();
                        MessageBox.Show("Profile picture uploaded.");
                    }
                }
            }
        }

        private void ImgForm_Load(object sender, EventArgs e)
        {
            using (var context = new AppDbContext())
            {
                // Load user photo
                var user = context.Users.SingleOrDefault(u => u.ID == userId);
                if (user != null && user.ProfilePicture != null)
                {
                    using (var ms = new MemoryStream(user.ProfilePicture))
                    {
                        pictureBox.Image = Image.FromStream(ms);
                    }
                }
            }
        }
    }
}
