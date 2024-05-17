using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLDB.Interfaces
{
    public interface IApiService
    {
        Task<List<string>> GetAdresses(string searchKeyWord);
    }
}
