using FluentAssertions;
using FluentAssertions.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using YMB.IdentityServer.Entities;
using YMB.IdentityServer.Mapper;
namespace YMB.IdentityServier.UnitTest.Mappers
{    
    public class ClientMapperTest
    {
        
        [Fact]
        public void Can_MapperClient()
        {
            var client = new Client();
            var IdentyServierClient = client.ToModel();
            Assert.NotNull(IdentyServierClient);
        }
        [Fact]
        public void Properties_Map()
        {
            var client = new Client();
            client.Properties = new List<ClientProperty>
            {
               new ClientProperty{Id=1,Value="bar1"},
               new ClientProperty{Id=2,Value="bar1"}
            };
            var model = client.ToModel();
            model.Properties.Count.Should().Be(2);
            model.Properties.Keys.Contains("1").Should().Be(true);
        
        }
    }
}
