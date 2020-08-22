using AppTrackerBackendService.Entity;
using AppTrackerService.Controllers;
using NUnit.Framework;
using System.Collections.Generic;
using Moq;
using AppNarcServer.Context;
using AppNarcServer.Context.Administrator;

namespace AppNarcServerTest
{
    public class AppUsageControllerUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }
        
        /// <summary>
        /// Tests the GET method for the <see cref="AppUsageControlelr"/> class.
        /// Handles sunny day scenario where we create 1 <see cref="AppUsage"/> and expect the result to be returned.
        /// </summary>
        [Test]
        public void TestGetByUser_SunnyDay()
        {
            // Arrange
            string appName = "TestApp";
            string userId = "TestUser";
            int timeUsed = 15;
            AppEnvironment environment = AppEnvironment.Windows;

            var appUsageProviderMock = new Mock<AppUsageProvider>();
            List<AppUsage> expectedAppUsages = new List<AppUsage>();
            AppUsage expectedAppUsage = CreateAppUsage(appName, timeUsed, userId, environment);

            expectedAppUsages.Add(expectedAppUsage);

            appUsageProviderMock.Setup(provider => provider.FindByUser(userId)).Returns(expectedAppUsages);

            // Act
            AppUsageController appUsageController = new AppUsageController(appUsageProviderMock.Object, null);
            List<AppUsage> appUsages = appUsageController.Get(userId);

            AppUsage actualAppUsage = appUsages.Find(x => x.Name.Equals(appName));

            // Assert
            Assert.AreEqual(expectedAppUsage, actualAppUsage);
        }

        /// <summary>
        /// Sunny day test for create a new <see cref="AppUsage"/> using the the POST method in <see cref="AppUsageController"/>
        /// </summary>
        [Test]
        public void TestPostAppUsageNew_SunnyDay()
        {
            // Arrange
            string userId = "TestUser";
            string appName = "TestApp";
            int timeUsed = 15;
            AppEnvironment environment = AppEnvironment.Windows;

            List<AppUsage> testAppUsages = new List<AppUsage>();            
            
            AppUsage testAppUsage = CreateAppUsage(appName, timeUsed, userId, environment);

            testAppUsages.Add(testAppUsage);

            var appUsageAdministratorMock = new Mock<IAppUsageAdministrator>();
            appUsageAdministratorMock.Setup(admin => admin.SaveAppUsage(testAppUsage));

            var appUsageProviderMock = new Mock<IAppUsageProvider>();
            AppUsage nullAppUsage = null;
            appUsageProviderMock.Setup(provider => provider.FindByUserAndName(userId, appName)).Returns(nullAppUsage);

            AppUsageController appUsageController = new AppUsageController(appUsageProviderMock.Object, appUsageAdministratorMock.Object);

            // Act
            List<AppUsage> actualAppUsageResults = appUsageController.Post(testAppUsages);

            // Assert
            AppUsage actualAppUsage = actualAppUsageResults.Find(x => x.Name.Equals(appName));                       
        }

        /// <summary>
        /// Sunny day test for updating a <see cref="AppUsage"/> using the the POST method in <see cref="AppUsageController"/>
        /// </summary>
        [Test]
        public void TestPostAppUsageUpdate_SunnyDay()
        {
            // Arrange
            string userId = "TestUser";
            string appName = "TestApp";
            int timeUsed = 15;
            AppEnvironment environment = AppEnvironment.Windows;

            int expectedTimeUsed = 30;

            AppUsage appUsage = CreateAppUsage(appName, timeUsed, userId, environment);
            List<AppUsage> appUsages = new List<AppUsage>
            {
                appUsage
            };

            AppUsage expectedAppUsage = CreateAppUsage(appName, expectedTimeUsed, userId, environment);
            List<AppUsage> expectedAppUsages = new List<AppUsage>
            {
                expectedAppUsage
            };

            var appUsageProviderMock = new Mock<IAppUsageProvider>();
            appUsageProviderMock.Setup(provider => provider.FindByUserAndName(userId, appName)).Returns(appUsage);

            var appUsageAdministratorMock = new Mock<IAppUsageAdministrator>();
            appUsageAdministratorMock.Setup(admin => admin.SaveAppUsage(new AppUsage()));

            AppUsageController appUsageController = new AppUsageController(appUsageProviderMock.Object, appUsageAdministratorMock.Object);

            // Act
            List<AppUsage> actualAppUsages = appUsageController.Post(appUsages);
            AppUsage actualAppUsage = actualAppUsages.Find(x => x.Name.Equals(appName));

            // Assert
            Assert.AreEqual(expectedAppUsage, actualAppUsage);
        }

        /// <summary>
        /// Creates a <see cref="AppUsage"/> for testing purposes.
        /// </summary>
        /// <param name="appName">Application name of the test AppUsage.</param>
        /// <param name="timeUsed">Time used for the test AppUsage.</param>
        /// <param name="userId">User ID associated with the AppUsage.</param>
        /// <param name="environment">Environment associated with the AppUsage.</param>
        /// <returns></returns>
        private static AppUsage CreateAppUsage(string appName, int timeUsed, string userId, AppEnvironment environment)
        {
            return new AppUsage
            {
                Name = appName,
                TimeUsed = timeUsed,
                UserId = userId,
                Environment = environment,
            };
        }
    }
}