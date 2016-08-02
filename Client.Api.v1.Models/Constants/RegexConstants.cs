﻿using Domain.Entities.User.Implementation;

namespace Client.Api.v1.Models.Constants
{
    public class RegexConstants
    {
        public const string EmailRegex = @"^[a-z0-9\.\-_]+@[a-z0-9\-]+\.[a-z0-9]{2,16}$";
    }
}