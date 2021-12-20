﻿using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reports.DAL.Entities;

namespace Reports.Server.Services
{
    public interface IChangeService
    {
        Task<Change> Create(Guid taskId, string comment, string creationTime);
        DbSet<Change> GetAllChanges();
        Task<Change> GetChangeById(Guid changeId);
        Task<Change> GetChangeByTime(string creationTime);
    }
}