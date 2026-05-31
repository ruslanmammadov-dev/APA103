using System.ComponentModel.DataAnnotations;

namespace _27_FrontToBackSqlConnection.ViewModels.Account
{
    public class LoginVM
    {
        [Required(ErrorMessage = "İstifadəçi adı və ya email sahəsi mütləq doldurulmalıdır!")]
        [StringLength(100, ErrorMessage = "Giriş məlumatı maksimum 100 simvol ola bilər.")]
        public string UsernameOrEmail { get; set; } = null!;

        [Required(ErrorMessage = "Şifrə sahəsi mütləq doldurulmalıdır!")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Məni yadda saxla")]
        public bool IsPersitent { get; set; }
    }
}
