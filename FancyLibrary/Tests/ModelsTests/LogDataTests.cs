using Data.Entities;
using NUnit.Framework;
using System;

namespace Tests.ModelsTests
{
    public class LogDataTests
    {
        private LogData logData;

        [SetUp]
        public void Setup()
        {
            logData = new LogData
            {
                Id = 1,
                IsOnline = true,
                RegisterDate = DateTime.Today,
                LastTimeLoggedIn = DateTime.Today,
                TimesLoggedIn = 1
            };
        }

        [Test]
        public void IsReturningCorrectLogDataId()
        {
            Assert.That(logData.Id, Is.EqualTo(1));
        }

        [Test]
        public void IsReturningCorrectLogDataIsOnline()
        {
            Assert.That(logData.IsOnline, Is.EqualTo(true));
        }

        [Test]
        public void IsReturningCorrectLogDataRegisterDate()
        {
            Assert.That(logData.RegisterDate, Is.EqualTo(DateTime.Today));
        }

        [Test]
        public void IsReturningCorrectLogDataLastTimeLoggedIn()
        {
            Assert.That(logData.LastTimeLoggedIn, Is.EqualTo(DateTime.Today));
        }

        [Test]
        public void IsReturningCorrectLogDataTimesLoggedIn()
        {
            Assert.That(logData.TimesLoggedIn, Is.EqualTo(1));
        }
    }
}
