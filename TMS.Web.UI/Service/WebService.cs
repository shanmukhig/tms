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

    public virtual T Get(string Id)
    {
      Response response = GetEntities(string.Format("/{0}", Id));
      return response != null ? Serialize(response) : null;
    }

    public virtual T Create(T resource)
    {
      throw new NotImplementedException();
    }

    public virtual T Update(T resource)
    {
      throw new NotImplementedException();
    }

    public virtual void Delete(string Id)
    {
      throw new NotImplementedException();
    }
  }
}