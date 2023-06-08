using BE_TALENTO.Persistence.DapperConnection;
using BE_TALENTO.Persistence.Repositories;
using BE_TALENTO.Security.token;

namespace BE_TALENTO.ConfigurationServices
{
    public static class ConfigurationServices
    {
        public static IServiceCollection AddInjectionDependencies(this IServiceCollection services)
        {
            /*
			** ***********************    Inicialización Inyección de dependencia    ***************************
			*/
            services.AddTransient<IFactoryConnection, FactoryConnection>();
            services.AddScoped<JwtGenerateInterface, JwtGenerate>();
            services.AddScoped<AuthInterface, AuthRepository>();
            services.AddScoped<DashboardInterface, DashboardRepository>();
            services.AddScoped<ClientInterface, ClientRepository>();
            services.AddScoped<StoreInterface, StoreRepository>();
            services.AddScoped<ProductInterface, ProductRepository>();
            services.AddScoped<CheckOutInterface, CheckOutRepository>();

            return services;
        }
    }

}


