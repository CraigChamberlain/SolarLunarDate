using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SolarLunarName.Forms
{
    public interface IFileAccessHelper
    {
        Task<String> GetDBPathAndCreateIfNotExists();
    }
}
