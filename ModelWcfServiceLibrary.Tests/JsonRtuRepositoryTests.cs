using Autofac.Extras.Moq;
using ModelWcfServiceLibrary.FileAccessing;
using ModelWcfServiceLibrary.Model.RTU;
using ModelWcfServiceLibrary.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ModelWcfServiceLibrary.Tests
{
    public class JsonRtuRepositoryTests
    {
        [Fact]
        public void GetRTUByID_IdThatExists()
        {
            RtuRepository repository = CreateTestJsonRtuRepository();

            RTU rtuByID = repository.GetRTUByID(102);

            Assert.Equal("RTU2", rtuByID.Name);
        }


        [Fact]
        public void GetRTUByID_IdThatDoesNotExist()
        {
            RtuRepository repository = CreateTestJsonRtuRepository();

            RTU rtuByID = repository.GetRTUByID(100);

            Assert.Null(rtuByID);
        }

        private RtuRepository CreateTestJsonRtuRepository()
        {
            var fileAccessMock = new Mock<IFileAccess>();
            fileAccessMock.Setup(x => x.ReadFile(It.IsAny<string>())).Returns(GetTestJsonString());

            return new JsonRtuRepository(fileAccessMock.Object);
        }

        private List<RTU> GetTestRtuList()
        {
            return new List<RTU>
            {
                new RTU(){Name = "RTU1", ID = 101, Address = "127.0.0.1", Port = 502}
            };
        }

        private string GetTestJsonString()
        {
            return @"[
                      {
                        ""Name"": ""RTU1"",
                        ""ID"": 101,
                        ""Address"": ""127.0.0.1"",
                        ""Port"": 502,
                        ""AnalogSignals"": [
                          {
                            ""ID"": 1,
                            ""Address"": 1,
                            ""Name"": ""Analog signal 1""
                          },
                          {
                            ""ID"": 2,
                            ""Address"": 2,
                            ""Name"": ""Analog signal 2""
                          }
                        ],
                        ""DiscreteSignals"": [
                          {
                            ""ID"": 1,
                            ""Address"": 1,
                            ""Name"": ""Discrete signal 1""
                          }
                        ]
                      },
                      {
                        ""Name"": ""RTU2"",
                        ""ID"": 102,
                        ""Address"": ""127.0.0.1"",
                        ""Port"": 503,
                        ""AnalogSignals"": [
                          {
                            ""ID"": 1,
                            ""Address"": 1,
                            ""Name"": ""Analog signal 1""
                          },
                          {
                            ""ID"": 2,
                            ""Address"": 4,
                            ""Name"": ""Analog signal 2""
                          }
                        ],
                        ""DiscreteSignals"": [
                          {
                            ""ID"": 1,
                            ""Address"": 2,
                            ""Name"": ""Discrete signal 1""
                          }
                        ]
                      }
                    ]";
        }
    }
}
