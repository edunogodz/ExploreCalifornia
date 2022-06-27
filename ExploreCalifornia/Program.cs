
using ExploreCalifornia;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddMvc();
builder.Services.AddControllersWithViews();

var app = builder.Build();


//app.MapGet("/", () => "Hello Asp Net Core!");

//var startup = new Startup(builder.Configuration);

//nao funciona assim
//FeatureToggles features = new FeatureToggles();

app.UseExceptionHandler("/error.html");

//builder.Services.AddTransient<FeatureToggles>(x => new FeatureToggles
//{
//    DeveloperExceptions = builder.Configuration.GetValue<bool>("FeatureToggles:DeveloperExceptions")
//});

//if (app.Environment.IsDevelopment())
// if(builder.Configuration["EnableDeveloprExtensions"] == "True")
//if (builder.Configuration.GetValue<bool>("EnableDeveloprExtensions"))
if (builder.Configuration.GetValue<bool>("FeatureToggles:DeveloperExceptions"))
//if (features.DeveloperExceptions)
{
    app.UseDeveloperExceptionPage();
    //app.UseExceptionHandler("/Error");
    //// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

app.Use(async (context, next) =>
{
    if (context.Request.Path.Value.Contains("invalid"))
        throw new Exception("ERROR!");

    await next();
});

//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Hello world!");
//});

//app.UseMvc(routes =>
//{
//    routes.MapRoute(
//       name: "default",
//        template: "{controller}/{action}/{id}",
//        defaults: new
//        {
//            controller = "Home",
//            action = "Index"
//        });
//});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseFileServer();

app.Run();
