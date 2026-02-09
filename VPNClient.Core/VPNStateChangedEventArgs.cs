using System;

namespace VPNClient.Core
{
    public class VPNStateChangedEventArgs : EventArgs
    {
        public string State { get; set; }
        public DateTime ChangeTime { get; set; }

        public VPNStateChangedEventArgs(string state, DateTime changeTime)
        {
            State = state;
            ChangeTime = changeTime;
        }
    }

    public class VPNErrorEventArgs : EventArgs
    {
        public string ErrorMessage { get; set; }
        public DateTime ErrorTime { get; set; }

        public VPNErrorEventArgs(string errorMessage, DateTime errorTime)
        {
            ErrorMessage = errorMessage;
            ErrorTime = errorTime;
        }
    }
}