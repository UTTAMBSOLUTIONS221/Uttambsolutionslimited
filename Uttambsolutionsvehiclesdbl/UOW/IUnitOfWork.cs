using Uttambsolutionsvehiclesdbl.Repositories;

namespace Uttambsolutionsvehiclesdbl.UOW
{
    public interface IUnitOfWork
    {
        IVehiclemakeRepository VehiclemakeRepository { get; }
        IVehiclemodelRepository VehiclemodelRepository { get; }
    }
}
