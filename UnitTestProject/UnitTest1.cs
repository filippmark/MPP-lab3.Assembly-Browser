using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.IO;
using ViewModel;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void ShouldNotBeNull()
        {
            var _browser = new NameSpaces();
            var ns =  _browser.UploadNameSpaces(Directory.GetCurrentDirectory() + "\\forTests");
            Assert.IsNotNull(ns);
        }


        [TestMethod]
        public void ShouldContain2NameSpaces()
        {
            var _browser = new NameSpaces();
            var ns = _browser.UploadNameSpaces(Directory.GetCurrentDirectory() + "\\forTests");
            Assert.AreEqual(2, ns.Count);
        }

        [TestMethod]
        public void ShouldContain2Classes()
        {
            var _browser = new NameSpaces();
            var ns = _browser.UploadNameSpaces(Directory.GetCurrentDirectory() + "\\forTests");
            Assert.AreEqual(2,ns[0].Classes.Count);
        }

        [TestMethod]
        public void ShouldHaveCorrectNames()
        {
            var _browser = new NameSpaces();
            var ns = _browser.UploadNameSpaces(Directory.GetCurrentDirectory() + "\\forTests");
            Assert.AreEqual("Faker", ns[0].Classes[0].Name);
        }

        [TestMethod]
        public void ShouldHave3Fields()
        {
            var _browser = new NameSpaces();
            var ns = _browser.UploadNameSpaces(Directory.GetCurrentDirectory() + "\\forTests");
            Assert.AreEqual(3, ns[0].Classes[0].Fields.Count);
        }

        [TestMethod]
        public void ShouldHave13Method()
        {
            var _browser = new NameSpaces();
            var ns = _browser.UploadNameSpaces(Directory.GetCurrentDirectory() + "\\forTests");
            Assert.AreEqual(13, ns[0].Classes[0].Methods.Count);
        }


    }
}
