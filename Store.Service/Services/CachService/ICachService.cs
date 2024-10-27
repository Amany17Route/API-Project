using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.CachService
{
    public interface ICachService
    {
        Task SetCacheResponseAsync(string key, object response, TimeSpan timeToLive);


        Task<string> GetCacheResponseAsync(string key);

    }
}
