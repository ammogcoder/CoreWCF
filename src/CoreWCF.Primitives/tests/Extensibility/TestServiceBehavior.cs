﻿using CoreWCF;
using CoreWCF.Channels;
using CoreWCF.Description;
using CoreWCF.Dispatcher;
using System.Collections.ObjectModel;

namespace Extensibility
{
    public class TestServiceBehavior : IServiceBehavior
    {
        public IDispatchMessageInspector DispatchMessageInspector { get; set; }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (var cdb in serviceHostBase.ChannelDispatchers)
            {
                var dispatcher = cdb as ChannelDispatcher;
                foreach (var endpointDispatcher in dispatcher.Endpoints)
                {
                    if (DispatchMessageInspector != null)
                    {
                        endpointDispatcher.DispatchRuntime.MessageInspectors.Add(DispatchMessageInspector);
                    }
                }
            }
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
    }
}
