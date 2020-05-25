using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Test
{
    [TestClass]
    public class DocumentTest
    {
        private Document _validDocument;
        private Document _invalidDocument;
        public DocumentTest()
        {
            _invalidDocument =  new Document("123");
            _validDocument =  new Document("75737486044");
        }

        //red, green, refactory
        [TestMethod]
        public void Should_Return_Notification_When_Document_Is_Invalid()
        {  
            Assert.IsFalse(_invalidDocument.Valid);
            Assert.IsTrue(_invalidDocument.Notifications.Count > 0);
        }

          [TestMethod]
        public void Should_Return_Notification_When_Document_Is_Null()
        { 
            _invalidDocument = new Document(null);
            Assert.IsFalse(_invalidDocument.Valid);            
            Assert.IsTrue(_invalidDocument.Notifications.Count > 0);
        }

          [TestMethod]
        public void Should_Return_Notification_When_Document_Is_Empty()
        {
            _invalidDocument = new Document(string.Empty);
            
            Assert.IsFalse(_invalidDocument.Valid);            
            Assert.IsTrue(_invalidDocument.Notifications.Count > 0);
        }

          [TestMethod]
        public void Should_Return_Not_Notification_When_Document_Is_Valid()
        {
            Assert.IsTrue(_validDocument.Valid);            
            Assert.IsTrue(_validDocument.Notifications.Count == 0);
        }
    }
}
