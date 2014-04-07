using System;

namespace TMS.Data
{
  [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
  public class EnsureIndex : Attribute
  {

  }
}