

dotnet ef migrations add migrations_v7 -c AppDbContext


dotnet ef database update migrations_v7 -c AppDbContext



update public."Activity" set "Description" = 'Description'



