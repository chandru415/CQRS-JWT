using Application.Common.Interfaces;
using System;

namespace Infrastructure.Persistence
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
