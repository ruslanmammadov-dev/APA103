using System.ComponentModel.DataAnnotations;

namespace _27_FrontToBackSqlConnection.ViewModels.Account
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Ad sahəsi mütləq doldurulmalıdır!")]
        [StringLength(50, ErrorMessage = "Adın uzunluğu maksimum 50 simvol ola bilər.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Soyad sahəsi mütləq doldurulmalıdır!")]
        [StringLength(50, ErrorMessage = "Soyadın uzunluğu maksimum 50 simvol ola bilər.")]
        public string Surname { get; set; } = null!;

        [Required(ErrorMessage = "İstifadəçi adı mütləq doldurulmalıdır!")]
        [StringLength(30, ErrorMessage = "İstifadəçi adı maksimum 30 simvol ola bilər.")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Email sahəsi mütləq doldurulmalıdır!")]
        [EmailAddress(ErrorMessage = "Düzgün bir email ünvanı daxil edin!")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Şifrə sahəsi mütləq doldurulmalıdır!")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Şifrə ən azı 6 simvoldan ibarət olmalıdır!")]
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
    }
}
