using System.Security.Claims;
using SimulatedAlarmSystem.Models;
using SimulatedAlarmSystem.Models.Models;

namespace SimulatedAlarmSystem.BL.Interfaces
{
    public interface IUserService
    {
        public RegistrationResuslt RegisterUser(User user);
        IEnumerable<User> LoadUsers();
        public bool LoginUser(User user);
        public void SaveUser(User user);
    }
}
