using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TMS.ServiceAPI.Controllers
{
  public abstract class CustomController<T> : ApiController, IController<T> where T : class
  {
    //public virtual HttpResponseMessage Get()
    //{
    //  throw new NotImplementedException();
    //}

    public virtual HttpResponseMessage Get(int? count)
    {
      throw new System.NotImplementedException();
    }

    public virtual HttpResponseMessage Get(string searchString, string searchFileds)
    {
      throw new System.NotImplementedException();
    }

    public virtual HttpResponseMessage GetOne(string id)
    {
      throw new System.NotImplementedException();
    }

    public virtual HttpResponseMessage Create(T resource)
    {
      throw new System.NotImplementedException();
    }

    public virtual HttpResponseMessage Update(T resource)
    {
      throw new System.NotImplementedException();
    }

    public virtual HttpResponseMessage Delete(string id)
    {
      throw new System.NotImplementedException();
    }

    protected void Error(HttpStatusCode statusCode, string errorMessage = null, object[] args = null)
    {
      string message = string.IsNullOrWhiteSpace(errorMessage)
        ? string.Empty
        : args == null || args.Length == 0 ? errorMessage : string.Format(errorMessage, args);

      throw new HttpResponseException(
        new HttpResponseMessage
        {
          StatusCode = statusCode,
          Content = new StringContent(message),
          ReasonPhrase = message
        });
    }
  }
}