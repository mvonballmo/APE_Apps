// <copyright file="HttpClientFactory.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System.Net.Http;

namespace Albums.Services
{
  public class HttpClientFactory : IHttpClientFactory
  {
    public HttpClient CreateClient()
    {
      return new HttpClient();
    }
  }
}