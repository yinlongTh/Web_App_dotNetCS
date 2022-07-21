using YinlongWeb.Models;

namespace YinlongWeb.Services
{
    public class SecurityService
    {
        Userdao userDAO = new Userdao();

        public SecurityService()
        {

        }

        public bool isValid(UserModel user)
        {
            return userDAO.FindUserByNameAndPassword(user);

        }
    }
}
