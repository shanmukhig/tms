using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using TMS.Web.UI.Controllers;

namespace TMS.Web.UI.Service
{
  public class WebRequest : IWebRequest
  {
    private string url;
    private HttpMethod httpMethod;
    private IEnumerable<KeyValuePair<string, string>> queryParams;
    private IEnumerable<KeyValuePair<string, string>> headers;
    private string postBody;
    private Stream stream;
    private string contentType;

    public WebRequest Url(string url)
    {
      this.url = url;
      return this;
    }

    public WebRequest HttpMethod(HttpMethod httpMethod)
    {
      this.httpMethod = httpMethod;
      return this;
    }

    public WebRequest QueryParams(IEnumerable<KeyValuePair<string, string>> queryParams)
    {
      this.queryParams = queryParams;
      return this;
    }

    public WebRequest Headers(IEnumerable<KeyValuePair<string, string>> headers)
    {
      this.headers = headers;
      return this;
    }

    public WebRequest PostBody(string postBody)
    {
      this.postBody = postBody;
      return this;
    }

    public WebRequest PostBody(Stream stream)
    {
      this.stream = stream;
      return this;
    }


    public Response PostResponse()
    {
      try
      {
        HttpWebResponse webResponse = (HttpWebResponse)PostRequest().GetResponse();
        return new Response
        {
          ContentType = webResponse.ContentType,
          Content = webResponse.GetResponseStream(),
          StatusCode = webResponse.StatusCode,
          StatusDescription = webResponse.StatusDescription
        };
      }
      catch (WebException exception)
      {
        return new Response
        {
          Content = exception.Response.GetResponseStream()
        };
      }
    }

    public Response GetResponse()
    {
      try
      {
        HttpWebResponse webResponse = (HttpWebResponse)GetRequest().GetResponse();
        return new Response
        {
          ContentType = webResponse.ContentType,
          Content = webResponse.GetResponseStream(),
          StatusCode = webResponse.StatusCode,
          StatusDescription = webResponse.StatusDescription
        };
      }
      catch (WebException exception)
      {
        return new Response
        {
          Content = exception.Response.GetResponseStream()
        };
      }
    }

    public HttpWebRequest PostRequest()
    {
      //httpMethod = this.httpMethod;
      ValidateUrl();
      System.Net.WebRequest webRequest = GetWebRequest();
      //webRequest.ContentLength = default(int);
      //webRequest.ContentType = "application/x-www-form-urlencoded";
      //SetHeaders(webRequest);

      byte[] bytes = GetRequestBody();
      if (bytes != null)
      {
        webRequest.ContentLength = bytes.Length;
        Stream requestStream = webRequest.GetRequestStream();
        requestStream.Write(bytes, 0, bytes.Length);
        requestStream.Close();
      }
      else
      {
        webRequest.ContentLength = 0;
      }

      return (HttpWebRequest)webRequest;
    }

    private void SetHeaders(System.Net.WebRequest webRequest)
    {
      webRequest.ContentType = contentType;
      if(headers == null)
        return;
      foreach (KeyValuePair<string, string> header in headers)
        webRequest.Headers.Add(header.Key, header.Value);
    }

    public HttpWebRequest GetRequest()
    {
      httpMethod = System.Net.Http.HttpMethod.Get;
      ValidateUrl();

      return (HttpWebRequest)GetWebRequest();
    }

    public WebRequest ContentType(ContentType contentType)
    {
      switch (contentType)
      {
          //case Controllers.ContentType.Xml:
          //  headers = new[] { new KeyValuePair<string, string>("content-type", "application/json") };
          //  break;
          //case Controllers.ContentType.Json:
          //  headers = new[] { new KeyValuePair<string, string>("content-type", "application/xml") };
          //  break;
          //default:
          //  throw new ArgumentOutOfRangeException("contentType");
        case Controllers.ContentType.Xml:
          this.contentType = "application/xml";
          break;
        case Controllers.ContentType.Json:
          this.contentType = "application/json";
          break;
        default:
          throw new ArgumentOutOfRangeException("contentType");
      }
      return this;
    }

    private byte[] GetRequestBody()
    {
      if (!string.IsNullOrWhiteSpace(postBody) && stream != null)
      {
        throw new ArgumentException("postBody and stream");
      }

      if (!string.IsNullOrWhiteSpace(postBody))
      {
        return Encoding.UTF8.GetBytes(postBody);
      }

      if (stream != null && stream.Length > 0)
      {
        byte[] bytes = new byte[stream.Length];
        stream.Seek(0, SeekOrigin.Begin);
        stream.Read(bytes, 0, bytes.Length);
        return bytes;
      }
      return null;
    }

    private System.Net.WebRequest GetWebRequest()
    {
      if (queryParams != null && queryParams.Any())
      {
        url = string.Format("{0}?{1}", url, ConstructQueryString());
      }

      System.Net.WebRequest webRequest = System.Net.WebRequest.Create(url);
      SetHeaders(webRequest);
      webRequest.Method = httpMethod.ToString();
      return webRequest;
    }

    private void ValidateUrl()
    {
      if (string.IsNullOrWhiteSpace(url))
      {
        throw new ArgumentNullException("url");
      }
    }

    private string ConstructQueryString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var keyValuePair in queryParams)
      {
        sb.AppendFormat("{0}={1}&", keyValuePair.Key, keyValuePair.Value);
      }
      return sb.ToString(0, sb.Length - 1);
    }
  }
}