// <copyright file="AlbumsWebService.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Albums.Models;
using Newtonsoft.Json;

namespace Albums.Services
{
  /// <summary>
  /// Example web service showing the usage of the HttpClient.
  /// </summary>
  public class AlbumsWebService : IWebService<Album>
  {
    public AlbumsWebService(IHttpClientFactory clientFactory)
    {
      if (clientFactory == null) { throw new ArgumentNullException(nameof(clientFactory)); }

      _client = clientFactory.CreateClient();

      // Set a base-address so we don't need to repeat ourselves.
      _client.BaseAddress = new Uri("http://localhost:3000");

      // Set global headers for all requests.
      // _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "JWTToken");
    }

    public async Task<IEnumerable<Album>> Get()
    {
      var result = await _client.GetAsync("/albums/");

      if (result.IsSuccessStatusCode)
      {
        var stringResult = await result.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IEnumerable<Album>>(stringResult);
      }

      throw new InvalidOperationException("Could not load albums from server.");
    }

    public async Task<int> Post(Album toPost)
    {
      var serializedObject = JsonConvert.SerializeObject(toPost);
      var content = new StringContent(serializedObject, Encoding.UTF8, "application/json");
      var result = await _client.PostAsync("/api/something", content);

      // Same handling as with get. Check the status code and read out the result.
      throw new NotImplementedException();
    }

    private readonly HttpClient _client;
  }
}