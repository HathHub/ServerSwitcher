using System;
using System.Net;

public static class IpConverter
{
    public static uint IpToUint(string ipAddressOrDomain)
    {
        IPAddress ip;
        if (IPAddress.TryParse(ipAddressOrDomain, out ip))
        {
            return IpToUint(ip);
        }
        else
        {
            IPAddress[] addresses = Dns.GetHostAddresses(ipAddressOrDomain);
            if (addresses.Length == 0)
            {
                throw new ArgumentException("Failed to resolve the domain name to an IP address.", nameof(ipAddressOrDomain));
            }
            return IpToUint(addresses[0]);
        }
    }

    private static uint IpToUint(IPAddress ipAddress)
    {
        byte[] bytes = ipAddress.GetAddressBytes();

        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(bytes);
        }

        return BitConverter.ToUInt32(bytes, 0);
    }
}
