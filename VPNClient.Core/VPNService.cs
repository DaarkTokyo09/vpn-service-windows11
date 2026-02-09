using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace VPNClient.Core
{
    public class VPNService
    {
        public enum VPNState
        {
            Disconnected,
            Connecting,
            Connected,
            Disconnecting,
            Error
        }

        private VPNState _state;
        private readonly object _stateLock = new object();

        public event EventHandler<StateChangedEventArgs> StateChanged;
        public event EventHandler<ErrorEventArgs> ErrorOccurred;

        public VPNService()
        {
            _state = VPNState.Disconnected;
        }

        public void Connect(string serverAddress, int port)
        {
            lock (_stateLock)
            {
                if (_state == VPNState.Disconnected)
                {
                    _state = VPNState.Connecting;
                    OnStateChanged();
                    // Simulate connection logic (replace with real implementation)
                    Thread.Sleep(2000);
                    _state = VPNState.Connected;
                    OnStateChanged();
                }
                else
                {
                    OnErrorOccurred(new Exception("Already connected or connecting."));
                }
            }
        }

        public void Disconnect()
        {
            lock (_stateLock)
            {
                if (_state == VPNState.Connected)
                {
                    _state = VPNState.Disconnecting;
                    OnStateChanged();
                    // Simulate disconnection logic (replace with real implementation)
                    Thread.Sleep(2000);
                    _state = VPNState.Disconnected;
                    OnStateChanged();
                }
                else
                {
                    OnErrorOccurred(new Exception("Not connected."));
                }
            }
        }

        protected virtual void OnStateChanged()
        {
            StateChanged?.Invoke(this, new StateChangedEventArgs(_state));
        }

        protected virtual void OnErrorOccurred(Exception ex)
        {
            ErrorOccurred?.Invoke(this, new ErrorEventArgs(ex));
        }
    }

    public class StateChangedEventArgs : EventArgs
    {
        public VPNService.VPNState NewState { get; }

        public StateChangedEventArgs(VPNService.VPNState newState)
        {
            NewState = newState;
        }
    }

    public class ErrorEventArgs : EventArgs
    {
        public Exception Error { get; }

        public ErrorEventArgs(Exception error)
        {
            Error = error;
        }
    }
}