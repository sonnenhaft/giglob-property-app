using System;

namespace Domain.Authentication
{
    public interface ICurrentUserService
    {
        bool IsAuthenticated();

        long GetId();
    }
}