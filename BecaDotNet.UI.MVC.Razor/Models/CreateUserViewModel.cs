using BecaDotNet.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace BecaDotNet.UI.MVC.Razor.Models
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage ="* Nome é necessário")]
        [Display(Name="Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "* Email é necessário")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "* Login é necessário")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "* Senha é necessário")]
        [Display(Name = "Senha")]
        public string Password { get; set; }


        public User GetUser()
        {
            return new User
            {
                Email = Email,
                Login = Login,
                Name = Name,
                Password = Password
            };
        }
    }
}