using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Storages;

namespace Domain.Persistance.File.Implementation
{
    public class FileQueryableStreamSetupable: IQueryable<Entities.Implementation.File.File>
    {
        private readonly IFileStorage _fileStorage;
        private readonly IQueryable<Entities.Implementation.File.File> _decoratee;

        public FileQueryableStreamSetupable(IFileStorage fileStorage, IQueryable<Entities.Implementation.File.File> decoratee)
        {
            _fileStorage = fileStorage;
            _decoratee = decoratee;

            Provider = new FileQueryProvider(_fileStorage, _decoratee.Provider);
        }

        public Expression Expression => _decoratee.Expression;
        public Type ElementType => _decoratee.ElementType;
        public IQueryProvider Provider { get; }

        public IEnumerator<Entities.Implementation.File.File> GetEnumerator()
        {
            return new FileEnumeratorStreamSetupable(_fileStorage, _decoratee.GetEnumerator());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}