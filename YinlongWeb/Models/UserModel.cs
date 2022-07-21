using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YinlongWeb.Models
{
    public class UserModel
    {

        public int Id { get; set; }

        [DisplayName("Create your username")]
        public string UserName { get; set; }

        [DisplayName("Set your password")]
        [DataType(DataType.Password)]
        public string MyPassword { get; set; }

    }
}
