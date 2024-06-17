using Application.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interceptors
{
    public class EntityWithAuditCommandInterceptor : DbCommandInterceptor
    {
        private readonly IUser _user;

        private readonly TimeProvider _dateTime;

        public EntityWithAuditCommandInterceptor(IUser user,
            TimeProvider dateTime)
        {
            _user = user;
            _dateTime = dateTime;
        }
    }
}
