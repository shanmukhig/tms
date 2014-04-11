using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using TMS.Web.UI.Controllers;

namespace TMS.Web.UI.Service
{
  public class WebService<T> : IWebService<T> where T : class
  {
    private static Response GetEntities(string criteria)
    {
      Response response = new WebRequest().HttpMethod(HttpMethod.Get)
          .Url(string.Format(ConfigurationManager.AppSettings["baseUri"], typeof (T).Name, criteria))
          .ContentType(ContentType.Json)
          .GetResponse();
      return response.StatusCode == HttpStatusCode.OK ? response : null;
    }

    private static Response CreateUpdateEntity(T entity, HttpMethod httpMethod, HttpStatusCode statusCode)
    {
      Response response = new WebRequest().HttpMethod(httpMethod)
        .Url(string.Format(ConfigurationManager.AppSettings["baseUri"], typeof(T).Name, string.Empty))
        .ContentType(ContentType.Json)
        .PostBody(JsonConvert.SerializeObject(entity)).PostResponse();
      return response.StatusCode == statusCode ? response : null;
    }

    private static Response DeleteEntity(string criteria)
    {
      Response response = new WebRequest().HttpMethod(HttpMethod.Delete)
        .Url(string.Format(ConfigurationManager.AppSettings["baseUri"], typeof(T).Name, criteria))
        .ContentType(ContentType.Json).PostResponse();
      return response.StatusCode == HttpStatusCode.OK ? response : null;
    }

    private static Response PostEntity(T entity)
    {
      return CreateUpdateEntity(entity, HttpMethod.Post, HttpStatusCode.Created);
    }

    private static Response PutEntity(T entity)
    {
      return CreateUpdateEntity(entity, HttpMethod.Put, HttpStatusCode.OK);
    }

    private static IEnumerable<T> SerializeCollection(Response response)
    {
      using (StreamReader reader = new StreamReader(response.Content))
      {
        return JsonConvert.DeserializeObject<IEnumerable<T>>(reader.ReadToEnd());
      }
    }

    private static T Serialize(Response response)
    {
      using (StreamReader reader = new StreamReader(response.Content))
      {
        return JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
      }
    }

    public virtual IEnumerable<T> Get(int? count)
    {
      Response response = GetEntities(count.HasValue ? string.Format("?count={0}", count.Value) : "?count");
      return response != null ? SerializeCollection(response) : null;
    }

    public virtual IEnumerable<T> Get(string searchString, string searchField)
    {
      Response response = GetEntities(string.Format("?searchString={0}&searchFileds={1}", searchString, searchField));
      return response != null ? SerializeCollection(response) : null;
    }

    public virtual T Get(string id)
    {
      Response response = GetEntities(string.Format("/{0}", id));
      return response != null ? Serialize(response) : null;
    }

    public virtual T Create(T resource)
    {
      return Serialize(PostEntity(resource));
    }

    public virtual T Update(T resource)
    {
      return Serialize(PutEntity(resource));
    }

    public virtual void Delete(string id)
    {
      Response response = DeleteEntity(string.Format("/{0}", id));
      if (response.StatusCode != HttpStatusCode.OK)
        throw new InvalidDataException("Failed to delete lead");
    }
  }
}