// INetworkManager.cs

using System;

namespace VPNClient.Network
{
    public interface INetworkManager
    {
        void Connect(string ipAddress);
        void Disconnect();
        bool IsConnected { get; }
    }
}