using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace NextTranslator.Services;

public static class ServiceCollectionExtensions
{
    public static void AddFileService(this IServiceCollection collection, Window window)
    {
        collection.AddSingleton<IDictionariesProviderService, DictionariesProviderService>();
        collection.AddSingleton<IFilesService>(x => new FilesService(window));
    }
}
