using PainterPriceOfferServcie.Api;
using PainterPriceOfferServcie.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCorsOrigin();
builder.Services.AddBasicServices(typeof(Application).Assembly, builder.Configuration);
builder.Services.AddSwaggerServices();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
//app.UseAuthentication();
//app.UseAuthorization();
app.UseSwaggerServices();
//app.UseDefaultHealthCheckEndpoint();
app.UseExceptionHandler();

app.MapControllers();

app.Run();
