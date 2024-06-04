using FontAwesome.Sharp;
using Gemilang.Data;
using Gemilang.Models;
using Gemilang.Utils;
using Microsoft.EntityFrameworkCore;

namespace Gemilang.Views.Forms
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            using (GemilangDbContext context = new())
            {
                var user = context.User.FirstOrDefault(u => u.Email == textBoxEmail.Text && u.Password == Enkripsi.BuatSHA256Hash(textBoxPassword.Text));

                if (user != null)
                {
                    MessageBox.Show($"Berhasil login! Selamat datang, {user.Username}!", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hide();
                    if (user.Role == Role.guru)
                    {
                        var guru = context.Guru.FirstOrDefault(g => g.Id == user.Id);

                        if (guru != null)
                        {
                            new FormHome(guru).Show();
                            return;
                        }
                    }
                    else if (user.Role == Role.siswa)
                    {
                        var siswa = context.Siswa.FirstOrDefault(s => s.Id == user.Id);

                        if (siswa != null)
                        {
                            new FormHome(siswa).Show();
                            return;
                        }
                    }
                    else if (user.Role == Role.admin)
                    {
                        new FormHome(user).Show();
                        return;
                    }
                }
                else MessageBox.Show("Email atau password salah", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void iconButtonVisibilityPassword_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !textBoxPassword.UseSystemPasswordChar;
            iconButtonVisibilityPassword.IconChar = textBoxPassword.UseSystemPasswordChar ? IconChar.Eye : IconChar.EyeSlash;
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
