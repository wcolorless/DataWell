using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp;

namespace DataWellCore.core.Client
{
    /// <summary>
    /// Web Socket Client Transport
    /// </summary>
    public class WSClientTransport : IClientTransport
    {
        private long _totalBytesReceived;
        private WebSocket _webSocket;
        private Queue<string> _lastAnswer = new Queue<string>();
        public WSClientTransport(string host, string port)
        {
            _webSocket = new WebSocket($"ws://{host}:{port}/DataWell");
            _webSocket.OnOpen += _webSocket_OnConnect;
            _webSocket.OnClose += _webSocket_OnClose;
            _webSocket.OnError += _webSocket_OnError;
            _webSocket.OnMessage += _webSocket_OnMessage;
            Connect();
        }

        private void _webSocket_OnMessage(object sender, MessageEventArgs e)
        {
            _lastAnswer.Enqueue(e.Data);
            _totalBytesReceived += e.Data.Length;
        }

        private void _webSocket_OnError(object sender, ErrorEventArgs e)
        {
            Console.WriteLine($"WSTransport Error: {e.Message}");
        }

        private void _webSocket_OnClose(object sender, CloseEventArgs e)
        {
            Console.WriteLine("Connection Closed");
        }

        private void _webSocket_OnConnect(object handler, EventArgs e)
        {
            Console.WriteLine("Connection Open");
        }

        public void Connect()
        {
            try
            {
                _webSocket.Connect();
            }
            catch (Exception e)
            {
                throw new Exception($"WSClientTransport Connect Error: {e.Message}");
            }
        }

        public void Disconnect()
        {
            try
            {
                _webSocket.Close();
            }
            catch (Exception e)
            {
                throw new Exception($"WSClientTransport Disconnect Error: {e.Message}");
            }
        }

        public void SendMessage(string message)
        {
            if (_webSocket.IsAlive)
            {
                _webSocket.Send(message);
            }
            else
            {
                throw new Exception($"WSTransport Connection IsAlive {_webSocket.IsAlive}");
            }
        }

        public string GetAnswer()
        {
            string message;
            while (!_lastAnswer.TryDequeue(out message))
            {
                Thread.Sleep(2);
            }
            return message;
        }
    }
}
