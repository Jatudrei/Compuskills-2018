using System;

namespace AspNetMvc.Attributes
{
    [Flags]
    public enum RequestAccessType
    {
        Local = 1,
        VPN = 2,
        Web = 4,
        Console = 8
    }
}