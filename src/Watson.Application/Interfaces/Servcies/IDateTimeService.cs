using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watson.Application.Interfaces.Servcies
{
    public interface IDateTimeService
    {
        public DateTime NowUtc();
    }
}
