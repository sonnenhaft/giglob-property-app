using System;
using System.IO;
using Domain.Tools;
using Moq;
using NUnit.Framework;

namespace Domain.Persistence.FileStorage.Tests
{
    [TestFixture]
    public class FileStorageTests
    {
        private Implementation.FileStorage _fileStorage;

        [SetUp]
        public void Setup()
        {
            var vpuMock = new Mock<IVirtualPathUtility>();
            vpuMock.Setup(x => x.ConvertToFullPath(It.IsAny<string>()))
                   .Returns<string>(vPath => vPath.Replace("~", AppDomain.CurrentDomain.BaseDirectory));
            _fileStorage = new Implementation.FileStorage(vpuMock.Object);
        }

        [OneTimeTearDown]
        public void FixtureTearDown()
        {
            Directory.Delete($@"{AppDomain.CurrentDomain.BaseDirectory}\files\", true);
        }

        [Test]
        public void Create_Random1024BytesWritesToFile_CreatesFileWithByteArrayContent()
        {
            var expected = new byte[1024];
            new Random().NextBytes(expected);
            var filename = Guid.NewGuid()
                               .ToString();

            using(var ms = new MemoryStream())
            {
                ms.Write(expected, 0, expected.Length);
                _fileStorage.Create(ms, $@"~\files\{filename}", FileMode.CreateNew);
            }

            byte[] actual = new byte[1024];

            using(var fs = new FileStream($@"{AppDomain.CurrentDomain.BaseDirectory}\files\{filename}", FileMode.Open))
            {
                fs.Read(actual, 0, (int) fs.Length);
            }

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Get_FileWith1024RandomBytes_ReturnsStreamWithByteArrayContent()
        {
            var expected = new byte[1024];
            new Random().NextBytes(expected);
            var filename = Guid.NewGuid()
                               .ToString();

            using (var fs = new FileStream($@"{AppDomain.CurrentDomain.BaseDirectory}\files\{filename}", FileMode.CreateNew))
            {
                fs.Write(expected, 0, expected.Length);
            }


            byte[] actual = new byte[1024];
            using(var result = _fileStorage.Get($@"~\files\{filename}"))
            {
                result.Read(actual, 0, (int) result.Length);
            }

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}