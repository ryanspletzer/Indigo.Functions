﻿using Microsoft.Azure.WebJobs.Host.Config;
using StackExchange.Redis;
using System.Threading.Tasks;

namespace Indigo.Functions.Redis
{
    public class RedisExtension : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            var rule = context.AddBindingRule<RedisAttribute>();

            rule.WhenIsNotNull(nameof(RedisAttribute.Configuration))
                .BindToInput(BuildConnectionFromAttribute);

            rule.WhenIsNotNull(nameof(RedisAttribute.Configuration))
                .BindToInput(BuildConnectionFromAttributeAsync);
        }

        private IConnectionMultiplexer BuildConnectionFromAttribute(RedisAttribute attribute)
        {
            var connectionMultiplexer = ConnectionMultiplexer.Connect(attribute.Configuration);

            return connectionMultiplexer;
        }

        private async Task<IConnectionMultiplexer> BuildConnectionFromAttributeAsync(RedisAttribute attribute)
        {
            var connectionMultiplexer = await ConnectionMultiplexer.ConnectAsync(attribute.Configuration);

            return connectionMultiplexer;
        }
    }
}
