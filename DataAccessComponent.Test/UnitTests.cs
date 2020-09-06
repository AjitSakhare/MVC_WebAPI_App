using Moq;
using NUnit.Framework;
using System;

namespace DataAccessComponent.Test
{
    public class UnitTests
    {
        private Mock<IContactInfoDC> _IcontInfoMock;
        private zUserDetail _zUserDetail;
        private ContactInfoDC _contactInfoDC;
        private ContactInfoEntities _contactInfoEntities;

        [SetUp]
        public void SetUp()
        {
            _zUserDetail = new zUserDetail();
            _IcontInfoMock = new Mock<IContactInfoDC>();
            _contactInfoDC = new ContactInfoDC(_contactInfoEntities);
        }

        [Test]
        public void DAL_InsertDetails_ThrowArgumentNullExceptionIfRequestIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _contactInfoDC.InsertDetails(null));
            Assert.AreEqual(Convert.ToString(ExceptionTypes.ArgumentNullException), exception.ParamName);
        }

        [Test]
        public void DAL_InsertDetails_Success()
        {
            var user = new zUserDetail { FirstName = "Rahul", LastName = "Raj", Email = "test@gmail.com", PhoneNumber = 1234567891, Status = true };
            var isAdded = _contactInfoDC.InsertDetails(user);
            Assert.IsTrue(isAdded);
        }

        [Test]
        public void DAL_UpdateDetails_Success()
        {
            var user = new zUserDetail { Id = 1, FirstName = "RahulU", LastName = "RajU", Email = "test@gmail.com", PhoneNumber = 21345846558, Status = true };
            var isUpdated = _contactInfoDC.UpdateDetails(user);
            Assert.IsTrue(isUpdated);
        }

        [Test]
        public void DAL_DeleteRecord_Success()
        {
            var isDeleted = _contactInfoDC.DeleteRecord(1);
            Assert.IsTrue(isDeleted);
        }

        [Test]
        public void DAL_GetAllInfoList_Success()
        {
            var users = _contactInfoDC.GetAllInfoList();
            Assert.IsNotNull(users);
            Assert.IsTrue(users.Count > 0);
        }

        //[Test]
        //public void DAL_InsertDetails_ThrowInvalidOperationException()
        //{
        //    var exception = Assert.Throws<System.InvalidOperationException>(() => _contactInfoDC.InsertDetails(_zUserDetail));
        //    Assert.True(exception.Message.Contains("No connection string"));
        //}
    }
}
