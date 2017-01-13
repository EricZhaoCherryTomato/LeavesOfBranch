using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace RepoPattern.Unit.Tests
{
    [TestFixture]
    public class PersonSeviceTests
    {
        [Test]
        public void ShouldBeAbleToCallPersonServiceAndGetPerson()
        {
            var expected = new Person { Id = 1, FirstName = "John", LastName = "Doe"};
            var personReposityMock = new Mock<IPersonRepository>();
            personReposityMock.Setup(pr => pr.GetPerson(1)).Returns(new Person { Id = 1, FirstName = "John", LastName = "Doe" });
            var personService = new PersonService(personReposityMock.Object);
            var actual = personService.GetPerson(expected.Id);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
        }
    }
}
