using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using RoleBased.Infrastructure.Persistance;
using RoleBased.Core.Mapping;

namespace RoleBased.IoC.Configaration;

public static class ServiceCollectionExtention
{
    public static IServiceCollection MapCore(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<RoleBasedDbContext>(option=>
        {
            option.UseSqlServer(configuration.GetConnectionString("Conn"));
            option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); // I add This (this is for if update is not working. because dbconn trtacks all data, so sometime it restrict to update same data)
        });

        services.AddAutoMapper(typeof(MappingExtention).Assembly);

        ////new 9/9/2023
        //services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        //services.AddTransient<ICountryRepository, CountryRepository>(); // add new
        //services.AddTransient<IStateRepository, StateRepository>(); // add new

        //services.AddValidatorsFromAssembly(typeof(ICore).Assembly);

        //services.AddMediatR(cfg =>
        //{
        //    cfg.RegisterServicesFromAssemblies(typeof(ICore).Assembly);
        //    //validation register
        //    cfg.AddBehavior(typeof(IPipelineBehavior<,>),typeof(validationBehavior<,>));
        //});
        //new end

        return services;
    } 
}
