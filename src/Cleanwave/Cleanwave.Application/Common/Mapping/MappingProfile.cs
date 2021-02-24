using AutoMapper;
using Cleanwave.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Cleanwave.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            ApplyMappingFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingFromAssembly(Assembly assembly)
        {
            List<Type> types = assembly.GetExportedTypes().Where(t =>
                t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)
                )
            ).ToList();

            types.ForEach(type =>
            {
                object instance = Activator.CreateInstance(type);
                MethodInfo methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            });

            throw new NotImplementedException();
        }
    }
}
