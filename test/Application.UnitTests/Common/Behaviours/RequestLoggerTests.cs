using Application.Behaviours;
using Application.Entities.Cities.Operations;
using Application.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Application.UnitTests.Common.Behaviours
{
    public class RequestLoggerTests
    {
        private Mock<ILogger<InsertCityOperation>> _logger = null!;
        private Mock<IUser> _user = null!;
        private Mock<IIdentificationService> _identityService = null!;

        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<InsertCityOperation>>();
            _user = new Mock<IUser>();
            _identityService = new Mock<IIdentificationService>();
        }

        [Test]
        public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
        {
            _user.Setup(x => x.Id).Returns(Guid.NewGuid());

            var requestLogger = new LoggingBehaviour<InsertCityOperation>(_logger.Object, _user.Object, _identityService.Object);

            await requestLogger.Process(new InsertCityOperation { Name = "City 1", MaxDailyTax = 40, SingleChargeRuleTimeInMinute = 50, TaxFreeMonths = new List<int>(), TaxFreeWeekDays = new List<DayOfWeek>() }, new CancellationToken());

            _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<Guid>()), Times.Once);
        }

        [Test]
        public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
        {
            var requestLogger = new LoggingBehaviour<InsertCityOperation>(_logger.Object, _user.Object, _identityService.Object);

            await requestLogger.Process(new InsertCityOperation { Name = "City 2", MaxDailyTax = 60, SingleChargeRuleTimeInMinute = 70, TaxFreeMonths = new List<int>(), TaxFreeWeekDays = new List<DayOfWeek>() }, new CancellationToken());

            _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<Guid>()), Times.Never);
        }
    }
}
