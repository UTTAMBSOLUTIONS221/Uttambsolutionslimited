using Newtonsoft.Json;
using Uttambsolutionscustomerdbl.Entities;
using Uttambsolutionscustomerdbl.Helpers;
using Uttambsolutionscustomerdbl.Models;
using Uttambsolutionscustomerdbl.UOW;

namespace Uttambsolutionscustomerdbl
{
    public class BL
    {
        private UnitOfWork db;
        private string _connString;
        static bool mailSent = false;
        Encryptdecrypt sec = new Encryptdecrypt();
        Stringgenerator str = new Stringgenerator();
        public string LogFile { get; set; }
        public BL(string connString)
        {
            this._connString = connString;
            db = new UnitOfWork(connString);
        }
        public Task<IEnumerable<Uttambsolutionscustomers>> Getuttambsolutionscustomerdata()
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.Getuttambsolutionscustomerdata();
                return Resp;
            });
        }
        public Task<Genericmodel> Registeruttambsolutionscustomerdata(Uttambsolutionscustomers obj)
        {
            return Task.Run(() =>
            {
                string Passwordhash = str.RandomString(12);
                if (obj.Customerid == 0)
                {
                    obj.Passwords = sec.Encrypt(obj.Passwords, Passwordhash);
                    obj.Passharsh = Passwordhash;
                }
                var Resp = db.CustomerRepository.Registeruttambsolutionscustomerdata(JsonConvert.SerializeObject(obj));
                return Resp;
            });
        }
        public Task<Uttambsolutionscustomers> Getuttambsolutionscustomerdatabyid(long Customerid)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.Getuttambsolutionscustomerdatabyid(Customerid);
                return Resp;
            });
        }
    }
}
