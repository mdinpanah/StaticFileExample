using Microsoft.Extensions.FileProviders;
using System.Runtime.Intrinsics.Arm;

//var builder = WebApplication.CreateBuilder(args);
var builder = WebApplication.CreateBuilder(
    new WebApplicationOptions()
    { WebRootPath="myroot"}
    );
var app = builder.Build();

app.UseStaticFiles();  //Works with  web root (myroot)

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
              //builder.Environment.ContentRootPath+ "\\mywebroot " ) 
    Path.Combine(builder.Environment.ContentRootPath, "mywebroot ") ) 
}  );  //Works with  mywebroot


app.UseRouting();








//app.UseEndpoints(endpoints => { 
// endpoints.Map("/", async (Context) =>
// { await Context.Response.WriteAsync("Hello"); });

//});


app.Map("/", async (context) =>
{
    await context.Response.WriteAsync("Hello");
});

//app.MapGet("/", () => "Hello World!");

app.Run();
