using System;
using System.Collections.Generic;
using System.Text;

namespace Skyline.Core.System
{
    public interface IApiInformation
    {
        string BindAddress { get; set; }
        int BindPort { get; set; }

    }
}
