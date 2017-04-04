using Sitecore.Cloud.Xdb;
using Sitecore.Diagnostics;
using Sitecore.Pipelines;
using System;
using System.Configuration;

namespace Sitecore.Support.Cloud.Xdb
{
  public class UpdateXdbConnectionStrings
  {
    public void Process(PipelineArgs args)
    {
      Log.Info("Sitecore.Support.155426: Starting updating the timeouts for connection strings between Sitecore application and MongoDB instance.", this);

      var connectTimeout = $"?connectTimeoutMS={Configuration.Settings.GetSetting("connectTimeoutMS")};";
      var socketTimeout = $"?socketTimeoutMS={Configuration.Settings.GetSetting("socketTimeoutMS")};";
      
      string[] xDBConnectionStringNames = { "analytics", "tracking.live", "tracking.history", "tracking.contact" };

      foreach (var name in xDBConnectionStringNames)
      {
        var connectionStringValue = ConfigurationManager.ConnectionStrings[name].ConnectionString;

        connectionStringValue = connectionStringValue.Replace("?", connectTimeout);
        connectionStringValue = connectionStringValue.Replace("?", socketTimeout);

        try
        {
          using (var connectionStringsManager = new ConnectionStringsManager())
          {
            connectionStringsManager.Update(name, connectionStringValue);

            Log.Info($"Sitecore.Support.155426: The '{name}' connection string has been updated: {connectionStringValue}", this);
          }
        }
        catch (Exception e)
        {
          Log.Info($"Sitecore.Support.155426: The 'connectTimeoutMS' and 'socketTimeoutMS' have not been updated. Exception: {e.Message}", this);
        }
      }      
    }
  }
}