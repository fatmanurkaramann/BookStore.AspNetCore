﻿using Business.DTOs;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthorService
    {
        List<Author> GetAllAuthor();
        Task<Author> GetById(int id);
        Task<Author> Add(CreateAuthorDto authorDto);
    }
}
