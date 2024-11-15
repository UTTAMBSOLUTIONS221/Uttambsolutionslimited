using Uttambsolutionsstaffdbl.Models;

namespace Uttambsolutionsstaffdbl.Repositories
{
    public interface IAuthRepository
    {
        Usermodeldataresponce Validateuttambsolutionsstaffdata(string Username);
    }
}
