using System.ComponentModel;

namespace LoanAgreementBusinessLogic.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [DisplayName("Логин пользователя")]
        public string Login { get; set; }

        [DisplayName("Пароль пользователя")]
        public string Password { get; set; }

        [DisplayName("Роль пользователя")]
        public string Role { get; set; }
    }
}
