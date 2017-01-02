using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remote {
    static class Constants {
        public const string IP = "192.168.1.14";

        public enum MSG_IDS {
            turn_off, //turn the tv off
            register,  //do the hand shake
            volume_down,
            volume_up,
            channel_up,
            channel_down,

        }
    }
}
