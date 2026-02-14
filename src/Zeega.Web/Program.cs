using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using Zed.NHibernate;
using Zed.Transaction;
using Zeega.Domain;
using Zeega.Infrastructure.Dal.NHibernate.ModelMapping;
using Zeega.Infrastructure.Dal.NHibernate.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure NHibernate
var modelMapper = new ModelMapper();
modelMapper.AddMappings();
NHibernateSessionProvider.Init(cfg =>
    cfg.DataBaseIntegration(c => {
        c.Dialect<MsSql2012Dialect>();
        c.Driver<NHibernate.Driver.MicrosoftDataSqlClientDriver>();
        c.ConnectionString = builder.Configuration.GetConnectionString("ZeegaDb");
        c.BatchSize = 100;
        c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
        //c.SchemaAction = SchemaAutoAction.Validate;
        c.LogFormattedSql = true;
        c.LogSqlInConsole = true;
    })
    .SetProperty(NHibernate.Cfg.Environment.CurrentSessionContextClass, "thread_static")
    .AddMapping(modelMapper.CompileMappingForAllExplicitlyAddedEntities()));

// Register NHibernate session factory and repositories
builder.Services.AddSingleton<ISessionFactory>(NHibernateSessionProvider.SessionFactory);
builder.Services.AddScoped<IAppTenantsRepository, AppTenantsNhRepository>();
builder.Services.AddScoped<IUnitOfWorkManager, NHibernateUnitOfWorkManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
