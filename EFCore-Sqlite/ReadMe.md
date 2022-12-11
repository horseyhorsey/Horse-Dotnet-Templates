# Ef Core Sqlite Code First Template
---

Database project to save me time when creating new code first databases

## Using template
---

1. Copy project to your solution

2. Rename project files `EFCore.Sqlite` and the directory to your namespace or name for project

3. Open with VSCode or a similar application and replace all `EFCore.Sqlite` to you namespace

4. You can replace all `MyModel` with your own first model and rename the class files

5. `dotnet restore | dotnet build`

## AppSettings (Optional)
---

1. Remove the `AppSettings` ItemGroup in .csproj if you don't need to configure it that way

2. Adjust the `OnConfiguring` in `DataDbContext`

### Migrations
---

1. Create migrations 

`dotnet ef migration add Initial`

1b. Or put migration into an output directory

`dotnet ef migration add Initial -o Data/Migrations`

2. Add another migration

`dotnet ef migration add 2ndMigration`

3. To remove the last migration. If you have 3 migrations then it will remove the last

`dotnet ef migrations remove`

## Database creating

1. Create database and add the migrations

`dotnet ef database update`

2. Drop the database

`dotnet ef database drop`