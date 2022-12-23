using System;
using System.Collections.Generic;
using Tacta.EventStore.Domain;

namespace Nofity.Core.ValueObjects
{
    public sealed class Credentials : ValueObject
    {
        public string Email { get; }
        public string Password { get; }

        public Credentials(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || string.IsNullOrWhiteSpace(password))
                throw new Exception("Credentials are invalid");

            Email = email;
            Password = password;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Email;
            yield return Password;
        }
    }
}
