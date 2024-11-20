using Uttambsolutionsvehiclesdbl.Entities;
using Uttambsolutionsvehiclesdbl.Models;
using Uttambsolutionsvehiclesdbl.UOW;

namespace Uttambsolutionsvehiclesdbl
{
    public class BL
    {
        public const string JWT_SECURITY_KEY = "Yh2k7QSu4l8CZg5p6X3Pna9L0Miy4D3Bvt0JVr87UcOj69Kwq5R2Nmf4FWs03Hdx";
        private const int JWT_TOKEN_VALIDITY_MINS = 30;

        private UnitOfWork db;
        private string _connString;
        public string LogFile { get; set; }
        public BL(string connString)
        {
            this._connString = connString;
            db = new UnitOfWork(connString);
        }
        #region Vehicle Makes
        public Task<IEnumerable<Uttambsolutionsvehiclemake>> Getuttambsolutionsvehiclemakedata()
        {
            return Task.Run(() =>
            {
                var Resp = db.VehiclemakeRepository.Getuttambsolutionsvehiclemakedata();
                return Resp;
            });
        }
        public Task<Genericmodel> Registeruttambsolutionsvehiclemakedata(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.VehiclemakeRepository.Registeruttambsolutionsvehiclemakedata(obj);
                return Resp;
            });
        }
        public Task<Uttambsolutionsvehiclemake> Getuttambsolutionsvehiclemakedatabyid(long Vehiclemakeid)
        {
            return Task.Run(() =>
            {
                var Resp = db.VehiclemakeRepository.Getuttambsolutionsvehiclemakedatabyid(Vehiclemakeid);
                return Resp;
            });
        }
        #endregion

        #region Vehicle Models
        public Task<IEnumerable<Uttambsolutionsvehiclemodel>> Getuttambsolutionsvehiclemodeldata()
        {
            return Task.Run(() =>
            {
                var Resp = db.VehiclemodelRepository.Getuttambsolutionsvehiclemodeldata();
                return Resp;
            });
        }
        public Task<Genericmodel> Registeruttambsolutionsvehiclemodeldata(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.VehiclemodelRepository.Registeruttambsolutionsvehiclemodeldata(obj);
                return Resp;
            });
        }
        public Task<Uttambsolutionsvehiclemodel> Getuttambsolutionsvehiclemodeldatabyid(long Vehiclemodelid)
        {
            return Task.Run(() =>
            {
                var Resp = db.VehiclemodelRepository.Getuttambsolutionsvehiclemodeldatabyid(Vehiclemodelid);
                return Resp;
            });
        }
        #endregion

    }
}
