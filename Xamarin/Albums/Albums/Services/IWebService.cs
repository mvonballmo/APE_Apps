// <copyright file="IWebService.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Albums.Services
{
  public interface IWebService<T>
  {
    Task<IEnumerable<T>> Get();

    Task<int> Post(T toPost);
  }
}