using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWebApp.Services
{
    public interface ITimeService
    {
        public DateTime GetCurrentDate();
    }
}
