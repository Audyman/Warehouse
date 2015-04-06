using AutoMapper;
using NUnit.Framework;
using Warehouse.Logic.ModelMappers.Base;

namespace Warehouse.UnitTests.InfrastructureTests
{
    [TestFixture]
    public class AutoMapperTests
    {
        [Test]
        public void AutoMapper_Should_Map_All_Profiles()
        {
            //Arrange
            //Act
            AutoMapperInitializer.InitAutoMapper();

            //Assert
            Mapper.AssertConfigurationIsValid();    
        }
    }
}