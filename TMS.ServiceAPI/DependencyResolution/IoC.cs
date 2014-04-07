// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using StructureMap;
using TMS.Business;
using TMS.Data;
using TMS.Entities;

namespace TMS.ServiceAPI.DependencyResolution
{
  public static class IoC
  {
    public static IContainer Initialize()
    {
      return new Container(
        expression =>
        {
          expression.For<IDomainService<Course>>().HybridHttpOrThreadLocalScoped().Use<CourseDomainSource>();
          expression.For<IDomainService<Lead>>().HybridHttpOrThreadLocalScoped().Use<LeadDomainService>();
          expression.For<IDomainService<User>>().HybridHttpOrThreadLocalScoped().Use<UserDomainService>();
          expression.For<IDomainService<Country>>().HybridHttpOrThreadLocalScoped().Use<CountryDomainService>();

          expression.For<DataProvider<Course>>().HybridHttpOrThreadLocalScoped().Use<CourseDataProvider>();
          expression.For<DataProvider<Lead>>().HybridHttpOrThreadLocalScoped().Use<LeadDataProvider>();
          expression.For<DataProvider<User>>().HybridHttpOrThreadLocalScoped().Use<UserDataProvider>();
          expression.For<DataProvider<Country>>().HybridHttpOrThreadLocalScoped().Use<CountryDataProvider>();
          expression.Scan(scanner =>
          {
            scanner.TheCallingAssembly();
            scanner.WithDefaultConventions();
          });
        });
    }
  }
}