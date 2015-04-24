using System;
using TechTalk.SpecFlow;
using SpecFlowTest;
using NUnit.Framework;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecFlowTest.Tests
{
    [Binding]
    public class CreateAClientSteps
    {
        private Table clientTable;

        [BeforeScenario]
        public void ScenarioSetUp()
        {
            DeleteAllClients();
        }

        [AfterScenario]
        public void ScenarioTearDown()
        {
            DeleteAllClients();
        }

        private static void DeleteAllClients()
        {
            using (var db = new SpecFlowTestContext())
            {
                var allClients = (from c in db.Clients select c).ToList();
                foreach (var c in allClients)
                {
                    db.Clients.Remove(c);
                }
                db.SaveChanges();
            }
        }

        [Given(@"I have the following client details")]
        public void GivenIHaveTheFollowingClientDetails(Table table)
        {
            clientTable = table;
        }

        [When(@"I press Create")]
        public void WhenIPressAdd()
        {
            using (var db = new SpecFlowTestContext())
            {
                Client client = new Client
                {
                    FirstName = clientTable.Rows[0]["FirstName"],
                    LastName = clientTable.Rows[0]["LastName"]
                };

                db.Clients.Add(client);
                db.SaveChanges();
            }
        
        }

        [Then(@"the client should be added to the database")]
        public void ThenTheClientShouldBeAddedToTheDatabase()
        {
            Client client = new Client
            {
                FirstName = clientTable.Rows[0]["FirstName"],
                LastName = clientTable.Rows[0]["LastName"]
            };

            using (var db = new SpecFlowTestContext())
            {
                var results = from c in db.Clients
                              where (c.FirstName == client.FirstName)
                                 && (c.LastName == client.LastName)
                              select c;

                Client result = results.First<Client>();
                Assert.AreEqual(client.FirstName, result.FirstName);
                Assert.AreEqual(client.LastName, result.LastName);
            }
        }
    }
}
