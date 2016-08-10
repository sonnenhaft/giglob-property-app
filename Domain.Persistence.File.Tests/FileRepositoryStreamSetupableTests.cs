using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Domain.Persistence.File.Implementation;
using Domain.Repositories;
using Domain.Storages;
using Moq;
using NUnit.Framework;

namespace Domain.Persistence.File.Tests
{
    [TestFixture]
    public class FileRepositoryStreamSetupableTests
    {
        private FileRepositoryStreamSetupable _fileRepositoryStreamSetupable;
        private byte[] _fileBytes;

        [SetUp]
        public void Setup()
        {
            var fileRepositoryMock = new Mock<IFileRepository>();
            var fileStorageMock = new Mock<IFileStorage>();
            _fileBytes = new byte[1024];
            new Random().NextBytes(_fileBytes);

            fileRepositoryMock.Setup(x => x.GetAll())
                              .Returns(
                                  new EnumerableQuery<Entities.Implementation.File.File>(
                                      new List<Entities.Implementation.File.File>
                                      {
                                          new Entities.Implementation.File.File
                                          {
                                              Id = Guid.NewGuid(),
                                              CreationDate = DateTime.UtcNow,
                                              IsDeleted = false,
                                              Extension = "txt",
                                              Name = "test.txt",
                                              VirtualPath = "vpath"
                                          }
                                      }));
            fileRepositoryMock.Setup(x => x.Get(It.IsAny<Guid>()))
                              .Returns(
                                  new Entities.Implementation.File.File
                                  {
                                      Id = Guid.NewGuid(),
                                      CreationDate = DateTime.UtcNow,
                                      IsDeleted = false,
                                      Extension = "txt",
                                      Name = "test.txt",
                                      VirtualPath = "vpath"
                                  });

            fileStorageMock.Setup(x => x.Get("vpath"))
                           .Returns(() => new MemoryStream(_fileBytes));

            _fileRepositoryStreamSetupable = new FileRepositoryStreamSetupable(fileStorageMock.Object, fileRepositoryMock.Object);
        }

        [Test]
        public void GetAll_None_ReturnsFilesWithStream()
        {
            var expected = _fileBytes;
            var actual = new byte[_fileBytes.Length];

            using (var file = _fileRepositoryStreamSetupable.GetAll()
                                                            .First())
            {
                file.Stream.Read(actual, 0, (int) file.Stream.Length);
            }

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Get_ExistingFileId_ReturnsFileWithStream()
        {
            var expected = _fileBytes;
            var actual = new byte[_fileBytes.Length];

            using (var file = _fileRepositoryStreamSetupable.Get(Guid.Empty))
            {
                file.Stream.Read(actual, 0, (int) file.Stream.Length);
            }

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}