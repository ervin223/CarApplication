using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using CarApplication.CarTest.Macros;
using CarApplication.Core.ServiceInterface;
using CarApplication.ApplicationServices.Services;
using CarApplication.Data;

namespace CarApplication.CarTest
{
    public abstract class TestBase : IDisposable
    {
        protected IServiceProvider serviceProvider { get; }

        protected TestBase()
        {
            var services = new ServiceCollection();
            SetupServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        public void Dispose()
        {
        }

        protected T Svc<T>()
        {
            return serviceProvider.GetService<T>();
        }

        protected T Macro<T>() where T : IMacros
        {
            return serviceProvider.GetService<T>();
        }

    public virtual void SetupServices(IServiceCollection services)
        {
            services.AddScoped<ICarServices, CarServices>();

            services.AddDbContext<CarContext>(x =>
            {
            });

            RegisterMacros(services);
        }

        private void RegisterMacros(IServiceCollection services)
        {
            var macroBaseType = typeof(IMacros);
            var macros = macroBaseType.Assembly.GetTypes()
                .Where(x => macroBaseType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            foreach (var macro in macros)
            {
                services.AddSingleton(macro);
            }
        }
    }
}