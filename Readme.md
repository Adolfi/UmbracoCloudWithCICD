# Welcome to Umbraco Cloud

In order to run Umbraco locally you will need to [install the .NET 10.0 SDK](https://dotnet.microsoft.com/download) (if you do not have this already).

With dotnet installed, run the following commands in your terminal application of choice:

```
cd src/UmbracoProject
dotnet build
dotnet run
```

The first time the project is run locally, you will see the restore boot up screen from Umbraco Cloud. If the environment you have cloned already contained Umbraco Deploy metadata files (such as Document Types), these will automatically be extracted with the option to restore content from the Cloud environment into the local installation.

```
Note: When running locally, we recommend that you setup a developer certificate and run the website under HTTPS. If you haven't configured one already, then run the following dotnet command:

dotnet dev-certs https --trust
```

### Running locally

Running Umbraco locally will automatically use SQLite out of the box and create a Umbraco.sqlite.db file in `~/umbraco/Data/Umbraco.sqlite.db`. The database schema will be automatically created, so it starts up ready for use.

Browse to the URLs from the terminal output of `dotnet run` to see your Umbraco site or alternatively open the `src/UmbracoProject/UmbracoProject.csproj` file in Visual Studio or JetBrains Rider.

# CI/CD

## Deployment Process

1. **Feature Development** - Create a feature branch and develop
2. **Push & Test** - Unit tests run automatically on every push
3. **Pull Request** - Create PR against `main` (tests run again)
4. **Merge & Release** - When merged to `main`, release pipeline triggers:
   - Syncs changes from Umbraco Cloud
   - Packages and uploads artifact
   - Automatically deploys to Umbraco Cloud

All branches are tested on push. Deployment only happens from `main` via release pipeline.

For manual deployment, trigger the `Release Pipeline` workflow from GitHub Actions.