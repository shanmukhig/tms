using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FluentValidation;
using FluentValidation.Mvc;
using StructureMap;
using TMS.Web.UI.DependencyResolution;

namespace TMS.Web.UI
{
  // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
  // visit http://go.microsoft.com/?LinkId=9394801
  public class MvcApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();

      IContainer container = IoC.Initialize();
      DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
      GlobalConfiguration.Configuration.DependencyResolver = new StructureMapDependencyResolver(container);

      WebApiConfig.Register(GlobalConfiguration.Configuration);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundle(BundleTable.Bundles);
      FluentValidationModelValidatorProvider.Configure(); 
      FluentValidationModelValidatorProvider validationProvider = new FluentValidationModelValidatorProvider(new StructreMapValidatorFactory(container));
      DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
      validationProvider.AddImplicitRequiredValidator = false;
      ModelValidatorProviders.Providers.Add(validationProvider);
    }
  }

  public class StructreMapValidatorFactory : ValidatorFactoryBase
  {
    private readonly IContainer _container;

    public StructreMapValidatorFactory(IContainer container)
    {
      _container = container;
    }

    public override IValidator CreateInstance(Type validatorType)
    {
      return (IValidator) _container.TryGetInstance(validatorType);
    }
  }

  public class BundleConfig
  {
    public static void RegisterBundle(BundleCollection bundleCollection)
    {
      Bundle scriptBundle = new ScriptBundle("~/Scripts")
        .Include(
        "~/Scripts/modernizr.js",
          "~/Scripts/jquery-2.1.0.min.js",
        //  //"~/Scripts/jqBootstrapValidation.js",
          "~/Scripts/jquery.dataTables.min.js",
        //  "~/Scripts/jquery.ext.dataTables.js",
          "~/Scripts/jquery.metisMenu.js",
          "~/Scripts/bootstrap.min.js",
        //  "~/Scripts/moment.min.js",
        //  "~/Scripts/bootstrap-datetimepicker.js",
          "~/Scripts/dataTables.bootstrap.js",
          //"~/Scripts/jquery.dataTables.min.js",
        //  "~/Scripts/morris.js",
          "~/Scripts/sb-admin.js",
            "~/Scripts/Common.js"
        //  "~/Scripts/bootstrap-select.min.js",
        //  "~/Scripts/bootstrap-tooltip.min.js",
        //  "~/Scripts/bootstrap-transition.min.js",
        //  "~/Scripts/bootstrap-confirm.min.js",
        //  "~/Scripts/jquery.validate.min.js",
        //  "~/Scripts/bootstrap-dialog.min.js",
        //  "~/Scripts/bootstrap-spinedit.js"
        );

      Bundle styleBundle = new StyleBundle("~/Content")
        .Include(
        "~/Content/bootstrap.min.css",
        //  //"~/Content/glyphicons.css",
        //  //"~/Content/halflings.css",
        //  //"~/Content/bootstrap-theme.min.css",
        //  "~/Content/bootstrap-datetimepicker.min.css",
          "~/Content/dataTables.bootstrap.css",
        //  //"~/Content/bootstrap-datepicker3.css",
        //  //"~/Content/flags-large.css",
        //  //"~/Content/fam-icons.css",
          "~/Content/font-awesome.css",
          "~/Content/sb-admin.css"
        //  //"~/Content/timeline.css",
        //  "~/Content/bootstrap-select.min.css",
        //  "~/Content/bootstrap-dialog.min.css",
        //  "~/Content/bootstrap-spinedit.css"
        );

      bundleCollection.Add(scriptBundle);
      bundleCollection.Add(styleBundle);
    }
  }
}