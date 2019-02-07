using Cat.Users.Models;

namespace Cat.Users.Services
{
    public interface IWorkContext
    {
        User CurrentUser { get; set; }
    }
}
