using Finhub.Core.ConfigOptions;
using Finhub.Infrastructure.Extensions;


var builder = WebApplication.CreateBuilder(args);
//#region options
builder.Services.Configure<FinhubOptions>(builder.Configuration.GetSection("Finhub") );
builder.Services.Configure<TradingOptions>(builder.Configuration.GetSection("TradingOptions"));
//#endregion
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
