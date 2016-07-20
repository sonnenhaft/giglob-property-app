using System.Collections;
using System.Collections.Generic;
using Domain.Storages;

namespace Domain.Persistance.File.Implementation
{
    public class FileEnumeratorStreamSetupable: IEnumerator<Entities.Implementation.File.File>
    {
        private readonly IFileStorage _fileStorage;
        private readonly IEnumerator<Entities.Implementation.File.File> _decoratee;

        public FileEnumeratorStreamSetupable(IFileStorage fileStorage, IEnumerator<Entities.Implementation.File.File> decoratee)
        {
            _fileStorage = fileStorage;
            _decoratee = decoratee;
        }

        private Entities.Implementation.File.File _current;

        public void Dispose()
        {
            _decoratee.Dispose();
        }

        public bool MoveNext()
        {
            _current = null;

            return _decoratee.MoveNext();
        }

        public void Reset()
        {
            _current = null;

            _decoratee.Reset();
        }

        public Entities.Implementation.File.File Current
        {
            get
            {
                var current = _current;

                if(current == null)
                {
                    current = _decoratee.Current;
                }

                if(current.Stream == null)
                {
                    current.Stream = _fileStorage.Get(current.VirtualPath);
                }

                return current;
            }
        }

        object IEnumerator.Current => Current;
    }
}