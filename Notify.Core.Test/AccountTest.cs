using Nofity.Core;
using Nofity.Core.DomainEvents;
using Nofity.Core.ValueObjects;
using NUnit.Framework;
using System;
using System.Linq;

namespace Notify.Core.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenValidCredentials_WhenCreateAccount_AccountCreated()
        {
            // Given
            var credentials = new Credentials("test@notify.com", "123456789");

            // When
            var account = Account.CreateAccount(credentials);

            // Then
            var @event = account.DomainEvents.Single() as AccountCreated;
            Assert.AreEqual(credentials.Email, @event.Email);
            Assert.AreEqual(credentials.Password, @event.Password);
            Assert.AreEqual(credentials.Email, @event.AggregateId);
        }

        [Test]
        public void GivenInalidCredentials_WhenCreateCredentials_ExceptionThrown()
        {
            // Given

            // When

            // Then
            Assert.Throws(typeof(Exception), () => new Credentials("test.notify.com", "123456789"));

        }
    }
}