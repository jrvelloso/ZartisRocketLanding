using System;
using FluentAssertions;
using Moq;
using RocketLanding.Library;
using RocketLanding.Library.Constants;
using RocketLanding.Library.Models;
using Xunit;

namespace RocketLanding.Tests
{
    public class PlataformTests
    {
        [Fact]
        public void WhenCreatePlataform_AssignAPlataform()
        {
            int xx = 10;
            int yy = 10;

            var rocketPlataformMock = new Mock<RocketPlataform>();
            var plataform = rocketPlataformMock.Object.CreatePlataformAsync(xx, yy).Result;

            Assert.IsAssignableFrom<Plataform>(plataform);
        }

        [Fact]
        public void WhenCreatePlataformBiggerThan100x100_ThrowExceptionNotSquared()
        {
            int xx = 110;
            int yy = 110;

            var maxSize = 100 - ConstantValues.StartPosition;

            var rocketPlataformMock = new Mock<RocketPlataform>();

            Action act = () => rocketPlataformMock.Object.CreatePlataformAsync(xx, yy).GetAwaiter().GetResult();
            act.Should().Throw<Exception>($"Plataform must be smaller than {100 - ConstantValues.StartPosition}");
        }

        [Fact]
        public void WhenCreatePlataformWithDifferentNumbers_ThrowExceptionNotSquared()
        {
            int xx = 10;
            int yy = 11;

            var rocketPlataformMock = new Mock<RocketPlataform>();

            Action act = () => rocketPlataformMock.Object.CreatePlataformAsync(xx, yy).GetAwaiter().GetResult();
            act.Should().Throw<Exception>("Plataform must have a squared area");
        }

        [Fact]
        public void WhenCheckingPositions_GetsAOkForLAnding()
        {
            int xx = 10;
            int yy = 10;

            var rocketPlataformMock = new Mock<RocketPlataform>();
            var plataform = rocketPlataformMock.Object.CreatePlataformAsync(xx, yy).Result;

            var postition = new Tuple<int, int>(5, 5);
            var result = rocketPlataformMock.Object.CheckPositionAsync(postition, plataform).Result;

            Assert.IsAssignableFrom<Plataform>(plataform);
            Assert.Equal(result, ConstantsPlataformResponses.OkForLanding);
        }

        [Fact]
        public void WhenCheckingPositions_GetsAClashDueToPreviousCheck()
        {
            int xx = 10;
            int yy = 10;

            var rocketPlataformMock = new Mock<RocketPlataform>();
            var plataform = rocketPlataformMock.Object.CreatePlataformAsync(xx, yy).Result;

            var postition = new Tuple<int, int>(5, 5);
            var result = rocketPlataformMock.Object.CheckPositionAsync(postition, plataform).Result;

            var postitionRepeated = new Tuple<int, int>(5, 5);
            var resultRepeated = rocketPlataformMock.Object.CheckPositionAsync(postitionRepeated, plataform).Result;

            Assert.IsAssignableFrom<Plataform>(plataform);
            Assert.Equal(resultRepeated, ConstantsPlataformResponses.Clash);
        }

        [Fact]
        public void WhenCheckingPositions_GetsAOutOfPlataformDueToItsPosition()
        {
            int xx = 10;
            int yy = 10;

            var rocketPlataformMock = new Mock<RocketPlataform>();
            var plataform = rocketPlataformMock.Object.CreatePlataformAsync(xx, yy).Result;

            var postition = new Tuple<int, int>(25, 30);
            var result = rocketPlataformMock.Object.CheckPositionAsync(postition, plataform).Result;

            Assert.IsAssignableFrom<Plataform>(plataform);
            Assert.Equal(result, ConstantsPlataformResponses.OutOfPlataform);
        }

        [Fact]
        public void WhenCheckingPositions_GetsAClashDueToNeighbouring()
        {
            int xx = 10;
            int yy = 10;

            var rocketPlataformMock = new Mock<RocketPlataform>();
            var plataform = rocketPlataformMock.Object.CreatePlataformAsync(xx, yy).Result;

            var postition = new Tuple<int, int>(12, 7);
            var result = rocketPlataformMock.Object.CheckPositionAsync(postition, plataform).Result;

            var postitionRepeated = new Tuple<int, int>(12, 8);
            var resultFromNighbouring = rocketPlataformMock.Object.CheckPositionAsync(postitionRepeated, plataform).Result;

            Assert.IsAssignableFrom<Plataform>(plataform);
            Assert.Equal(resultFromNighbouring, ConstantsPlataformResponses.Clash);
        }

    }

}