using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumoxCompaniesApp.API.Resources
{
    public class ListOfCompaniesResourceResp
    {
        public IList<CompanyOnGetResourceResp> Results { get; set; } = new List<CompanyOnGetResourceResp>();
    }
}
