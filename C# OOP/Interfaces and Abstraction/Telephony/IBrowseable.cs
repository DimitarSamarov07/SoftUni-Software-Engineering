using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface IBrowseable
    {
        string Browse();
        List<string> UrlList { get; set; }
    }
}
