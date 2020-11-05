using System;
using System.Collections.Generic;
using System.Text;
using EasyNetworkServer.Models.Common;
using DynamicData;


namespace EasyNetworkServer.Service
{
    public interface IDebugChannelService
    {

        public IObservableList<CommunicationMessageBase> DebugSourceList { get; }


        void Add(CommunicationMessageBase message);

        void RemoveFirstNum(int count);

        void ClearAllData();
    }
}
