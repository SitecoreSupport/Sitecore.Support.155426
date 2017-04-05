# Sitecore.Support.155426
Sitecore xDB Cloud 1.0 doesn't support custom connection timeout for the `analytics`, `tracking.live`, `tracking.history` and `tracking.contact` databases in MongoDB.

The default connection string between Sitecore application and MongoDB isntance looks like:

```
mongodb://{user-name}:{password}@{host1}:{port1},{host2}:{port2}/{guid}-Analytics?ssl=true;replicaSet={hostX}
```

The patch updates connection strings for the above databases with the `connectTimeoutMS`and `socketTimeoutMS` parameters, which could be configured using the `Sitecore.Support.155426.config` file.
    
```
mongodb://{user-name}:{password}@{host1}:{port1},{host2}:{port2}/{guid}-Analytics?socketTimeoutMS=1000;connectTimeoutMS=1000;ssl=true;replicaSet={hostX}
```

## License  
This patch is licensed under the [Sitecore Corporation A/S License for GitHub](https://github.com/sitecoresupport/Sitecore.Support.155426/blob/master/LICENSE).  

## Download  
Downloads are available via [GitHub Releases](https://github.com/sitecoresupport/Sitecore.Support.155426/releases).  

[![Github All Releases](https://img.shields.io/github/downloads/SitecoreSupport/Sitecore.Support.155426/total.svg)](https://github.com/SitecoreSupport/Sitecore.Support.155426/releases)
