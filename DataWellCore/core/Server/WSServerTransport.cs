using System;
using System.Collections.Generic;
using System.Text;
using DataWell;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace DataWellCore.core.Server
{
    public class WSServerTransport : IServerTransport
    {
        private WebSocketServer _webSocket;

        public WSServerTransport(DataWellSettings settings)
        {
            try
            {
                _webSocket = new WebSocketServer($"ws://{settings.Host}:{settings.Port}");
                _webSocket.AddWebSocketService<DataWellWSService>("/DataWell", () => new DataWellWSService(new DataWellServer()));
                _webSocket.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }

    /// <summary>
    /// Data well transport service
    /// </summary>
    public class DataWellWSService : WebSocketBehavior
    {
        private readonly DataWellServer _dataWellServer;
        public DataWellWSService(DataWellServer dataWellServer)
        {
            _dataWellServer = dataWellServer;
        }
        protected override void OnMessage(MessageEventArgs e)
        {
            try
            {
                var msg = e.Data;
                var answer = _dataWellServer.Handle(msg);
                if(!string.IsNullOrEmpty(answer)) Send(answer);
            }
            catch (Exception exception)
            {
                throw new Exception($"DataWellWSService OnMessage Error: {exception.Message}");
            }
        }
    }
}
