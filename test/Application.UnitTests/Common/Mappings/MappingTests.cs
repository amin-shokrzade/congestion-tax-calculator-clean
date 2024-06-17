using Application.Entities.Cities.Dtos;
using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using NUnit.Framework;
using System.Reflection;
using System.Runtime.Serialization;

namespace Application.UnitTests.Common.Mappings
{
    public class MappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests()
        {
            _configuration = new MapperConfiguration(config =>
                config.AddMaps(Assembly.GetAssembly(typeof(IDatabaseContext))));

            _mapper = _configuration.CreateMapper();
        }

        [Test]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Test]
        [TestCase(typeof(City), typeof(CityDto))]
        [TestCase(typeof(City), typeof(CityDto))]
        [TestCase(typeof(City), typeof(LookupDto))]
        [TestCase(typeof(City), typeof(LookupDto))]
        [TestCase(typeof(City), typeof(CityDto))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = GetInstanceOf(source);

            _mapper.Map(instance, source, destination);
        }

        private object GetInstanceOf(Type type)
        {
            if (type.GetConstructor(Type.EmptyTypes) != null)
                return Activator.CreateInstance(type)!;

            // Type without parameterless constructor
            // TODO: Figure out an alternative approach to the now obsolete `FormatterServices.GetUninitializedObject` method.
#pragma warning disable SYSLIB0050 // Type or member is obsolete
            return FormatterServices.GetUninitializedObject(type);
#pragma warning restore SYSLIB0050 // Type or member is obsolete
        }
    }
}
