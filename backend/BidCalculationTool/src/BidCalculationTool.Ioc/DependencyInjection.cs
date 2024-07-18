[ExcludeFromCodeCoverage]
public static class DependencyInjection {
    public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services) {
        AddRepository(services);
        AddService(services);
        AddAutoMapper(services);
        return services;
    }

    private static void AddAutoMapper(IServiceCollection services) {
        services.AddAutoMapper(typeof(VehicleProfile));
    }

    private static void AddService(IServiceCollection services) {
        services.AddScoped<IVehicleService, VehicleService>();
        services.AddScoped<IVehicleTypeService, VehicleTypeService>();
    }

    private static void AddRepository(IServiceCollection services) {
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
    }
}