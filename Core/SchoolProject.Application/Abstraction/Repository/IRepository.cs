﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Abstraction.Repository
{
	public interface IRepository<T> where T : BaseEntity
	{
        DbSet<T> Table { get; }
    }
}

