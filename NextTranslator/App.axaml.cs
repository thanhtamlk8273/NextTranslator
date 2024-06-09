using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NextTranslator.Configurations;
using NextTranslator.Services;
using NextTranslator.ViewModels;
using NextTranslator.Views;
using System;

namespace NextTranslator
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var mainWindow = new MainWindow();

                // Register all the services needed for the application to run
                var collection = new ServiceCollection();
                collection.AddCommonServices(mainWindow, ReadConfigurationFile());
                collection.AddSingleton<IServiceProvider>(sp => sp);

                // Creates a ServiceProvider containing services from the provided IServiceCollection
                var services = collection.BuildServiceProvider();

                var vm = services.GetRequiredService<MainWindowViewModel>();

                mainWindow.DataContext = vm;
                desktop.MainWindow = mainWindow;
            }

            base.OnFrameworkInitializationCompleted();
        }

        private IConfigurationRoot ReadConfigurationFile()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true);
            return builder.Build();
        }
    }

    public static class ServiceCollectionExtensions
    {
        public static void AddCommonServices(this IServiceCollection collection, Window mainWindow, IConfigurationRoot configurationRoot)
        {
            collection.AddFileService(mainWindow);
            collection.AddSingleton<AppConfigurations>(configurationRoot.GetSection("AppConfigurations").Get<AppConfigurations>() ??
                                                       new AppConfigurations());
            collection.AddTransient<DictionariesContentViewModel>();
            collection.AddTransient<TranslationViewModel>();
            collection.AddTransient<MainWindowViewModel>();
        }
    }
}