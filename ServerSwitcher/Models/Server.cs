using System.Collections.Generic;

namespace ServerSwitcher.Models
{
    public class Servers
    {
        public List<Server> ServerList { get; set; }

        public class Server
        {
            public string name { get; set; }
            public string ip { get; set; } 
            public uint ipUint { get; set; }
            public ushort port { get; set; }
            public string password { get; set; }
        }
    }
}
