﻿using Indigo.Functions.Injection.Internal;
using Microsoft.Azure.WebJobs;
using Unity;

namespace Indigo.Functions.Injection
{
    public class InjectConverter<T> : IConverter<Anonymous, T>
    {
        private readonly JobHostConfiguration _configuration;
        private readonly UnityContainer _container;

        public InjectConverter(JobHostConfiguration configuration, UnityContainer container)
        {
            _configuration = configuration;
            _container = container;
        }

        public T Convert(Anonymous input)
        {
            return _container.Resolve<T>();
        }
    }
}
