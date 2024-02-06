using Fihub.Infrastructure.Extensions;


var builder = WebApplication.CreateBuilder(args);

//extension method to load the DbContexts
builder.Services.LoadDbContext(builder.Configuration);


var app = builder.Build();

if (app.Environment.IsDevelopment() ) {
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.Run();
