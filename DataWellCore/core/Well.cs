using System;
using System.Collections.Generic;
using System.Text;
using DataWell;
using DataWellCore.core.Client;
using DataWellCore.core.Data.Collections;
using DataWellCore.core.Protocol;
using DataWellCore.core.Server;

namespace DataWellCore.core
{
    /// <summary>
    /// Data well
    /// </summary>
    public class Well
    {
        private readonly IServerTransport _serverTransport;
        private readonly MemStorage _storage;
        private readonly DataWellSettings _settings;
        private Well(DataWellSettings settings, TransportTypes transportType)
        {
            _settings = DataEnvironment.DataWellSettings = settings;
            _storage =  DataEnvironment.MemStorage = new MemStorage();
            try
            {
                switch (transportType)
                {
                    case TransportTypes.WebSocket:
                        _serverTransport = new WSServerTransport(settings);
                        break;
                    case TransportTypes.Http:
                        throw new NotImplementedException();
                        break;
                    default: break;
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Well GetWell Error: {e.Message}");
            }
        }

        public static Well GetWell(DataWellSettings settings, TransportTypes transportType)
        {
            return new Well(settings, transportType);
        }
    }
}
