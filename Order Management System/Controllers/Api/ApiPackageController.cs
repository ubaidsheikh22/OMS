using BusinessLayer.Models;
using BusinessLayer.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;


namespace Order_Management_System.Controllers.Api
{
    public class ApiPackageController : ApiController
    {
        public IEnumerable<PackageModel> Get([FromBody] PackageModel model)
        {

            PackageBusiness EML = new PackageBusiness();
            List<PackageModel> emp = EML.GetAllPackagesRecords.ToList();
            return emp.ToList();
        }
    }
}
