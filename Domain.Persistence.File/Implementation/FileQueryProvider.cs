using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Storages;

namespace Domain.Persistence.File.Implementation
{
    public class FileQueryProvider : IQueryProvider
    {
        private readonly IFileStorage _fileStorage;
        private readonly IQueryProvider _decoratee;

        public FileQueryProvider(IFileStorage fileStorage, IQueryProvider decoratee)
        {
            _fileStorage = fileStorage;
            _decoratee = decoratee;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            var query = _decoratee.CreateQuery(expression);

            if (query is IQueryable<Entities.Implementation.File.File>)
            {
                query = new FileQueryableStreamSetupable(_fileStorage, (IQueryable<Entities.Implementation.File.File>) query);
            }

            return query;
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            var query = _decoratee.CreateQuery<TElement>(expression);

            if (typeof (TElement) == typeof (Entities.Implementation.File.File))
            {
                query = (IQueryable<TElement>) new FileQueryableStreamSetupable(_fileStorage, (IQueryable<Entities.Implementation.File.File>) query);
            }

            return query;
        }

        public object Execute(Expression expression)
        {
            var result = _decoratee.Execute(expression);

            if (result.GetType() == typeof (Entities.Implementation.File.File))
            {
                var file = result as Entities.Implementation.File.File;
                file.Stream = _fileStorage.Get(file.VirtualPath);
            }
            else if (result is IEnumerable<Entities.Implementation.File.File>)
            {
                var files = (IEnumerable<Entities.Implementation.File.File>) result;

                foreach (var file in files)
                {
                    file.Stream = _fileStorage.Get(file.VirtualPath);
                }
            }

            return result;
        }

        public TResult Execute<TResult>(Expression expression)
        {
            var result = _decoratee.Execute<TResult>(expression);

            if (typeof (TResult) == typeof (Entities.Implementation.File.File))
            {
                var file = result as Entities.Implementation.File.File;
                file.Stream = _fileStorage.Get(file.VirtualPath);
            }
            else if (typeof (IEnumerable<Entities.Implementation.File.File>).IsAssignableFrom(typeof (TResult)))
            {
                var files = (IEnumerable<Entities.Implementation.File.File>) result;

                foreach (var file in files)
                {
                    file.Stream = _fileStorage.Get(file.VirtualPath);
                }
            }

            return result;
        }
    }
}