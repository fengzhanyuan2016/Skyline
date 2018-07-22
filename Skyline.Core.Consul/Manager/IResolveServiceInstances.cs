﻿using Skyline.Core.Consul.Registry;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Skyline.Core.Consul.Manager
{
    public interface IResolveServiceInstances
    {
        Task<IList<RegistryInformation>> FindServiceInstancesAsync();
        Task<IList<RegistryInformation>> FindServiceInstancesAsync(string name);
        Task<IList<RegistryInformation>> FindServiceInstancesWithVersionAsync(string name, string version);
        Task<IList<RegistryInformation>> FindServiceInstancesAsync(Predicate<KeyValuePair<string, string[]>> nameTagsPredicate, Predicate<RegistryInformation> registryInformationPredicate);
        Task<IList<RegistryInformation>> FindServiceInstancesAsync(Predicate<KeyValuePair<string, string[]>> predicate);
        Task<IList<RegistryInformation>> FindServiceInstancesAsync(Predicate<RegistryInformation> predicate);
        Task<IList<RegistryInformation>> FindAllServicesAsync();
    }
}
