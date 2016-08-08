using System;

namespace Domain.Entities.Implementation.PropertyOffer.Enums
{
    [Flags]
    public enum RoomCount
    {
        One = 1,
        Two = 2,
        Three = 4,
        More = 8
    }
}