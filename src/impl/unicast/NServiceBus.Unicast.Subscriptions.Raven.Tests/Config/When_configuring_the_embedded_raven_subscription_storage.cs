using NUnit.Framework;
using Raven.Storage.Esent;

namespace NServiceBus.Unicast.Subscriptions.Raven.Tests.Config
{
    using global::Raven.Client.Embedded;

    [TestFixture]
    public class When_configuring_the_embedded_raven_subscription_storage
    {
        //HACK: Needed to get escent working w/ NUnit
        TransactionalStorage storage;

        RavenSubscriptionStorage subscriptionStorage;

        [TestFixtureSetUp]
        public void SetUp()
        {
            var config = Configure.With(new[] { GetType().Assembly })
                .DefaultBuilder()
                .EmbeddedRavenSubscriptionStorage();

            subscriptionStorage = config.Builder.Build<RavenSubscriptionStorage>();
        }

        [Test]
        public void It_should_use_an_embedded_document_store()
        {
            Assert.That(subscriptionStorage.Store is EmbeddableDocumentStore);
        }
    }
}