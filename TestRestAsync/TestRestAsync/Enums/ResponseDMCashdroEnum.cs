using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRestAsync.Enums
{
    public enum ResponseDMCashdroEnum
    {
        USERPASSINCORRECT = -1,

        QUEUED = -2,

        NOPERMISSION = -4,

        INCORRECTPARAMS = -99,

        SYSBUSY = -1900,

        OUTOFSERVICE = -998,

        NOTRUNNING = -998,

        OK = 1,

        ERROR = 2,

        FATAL = 3

    }
}
