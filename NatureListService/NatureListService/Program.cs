using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using NatureListService.Configurations;
using NatureListService.Services;
using NatureListService.Models.CarriageDataModel;
using System.Text;
using Microsoft.Extensions.Options;
using NatureListService.Models.Database;

var builder = WebApplication.CreateBuilder(args);

AddAuthentication(builder);
AddUserStorage(builder);
AddCarriageDataStorage(builder);
builder.Services.XtraReportGeneratorService();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
    app.InitializeUserStorage();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

static void AddAuthentication(WebApplicationBuilder builder) {
    builder.Services.Configure<JwtConfiguration>(builder.Configuration.GetSection("JWT"));
    builder.Services.AddAuthorization();
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options => {
            JwtConfiguration jwtConfiguration = builder.Configuration.GetSection("JWT").Get<JwtConfiguration>();
            options.TokenValidationParameters = new TokenValidationParameters {
                ValidateIssuer = true,
                ValidIssuer = jwtConfiguration.Issuer,
                ValidateAudience = true,
                ValidAudience = jwtConfiguration.Audience,
                ValidateLifetime = true,
                IssuerSigningKey = jwtConfiguration.SymmetricSecurityKey,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero,
            };
        });
    builder.Services.AddControllers()
        .AddXmlSerializerFormatters();
    builder.Services.AddJwtTokenServicee();
}
static void AddUserStorage(WebApplicationBuilder builder) {
    builder.Services.AddXpoCustomSession<UserDataModelUnitOfWork>(true, options =>
            options.UseConnectionStringForUserDataModel(builder.Configuration)
                .UseAutoCreationOption(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema)
                .UseEntityTypes(new Type[] { typeof(User), typeof(Role) }));
    builder.Services.AddXpoUserStorageService();
}
static void AddCarriageDataStorage(WebApplicationBuilder builder) {
    builder.Services.AddXpoCustomSession<CarriageDataModelUnitOfWork>(true, options =>
            options.UseConnectionStringForCarriageDataModel(builder.Configuration)
                .UseAutoCreationOption(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema)
                .UseEntityTypes(new Type[] { typeof(Carriage), typeof(FreightType), typeof(Invoice),
                typeof(Operation), typeof(OperationState), typeof(Station), typeof(Train),
                typeof(TrainIndex)}));
    builder.Services.AddXpoDataStorageService();
}