using Tacta.EventStore.Domain;

namespace Nofity.Core
{
    public sealed class AccountId : EntityId
    {
        public string Email { get; }

        public AccountId(string email)
        {
            Email = email;
        }

        public override string ToString() => Email;
    }
}
