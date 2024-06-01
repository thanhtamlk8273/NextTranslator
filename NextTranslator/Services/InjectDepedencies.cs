using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextTranslator.Services;

public static class ServiceCollectionExtensions
{
    public static void AddFileService(this IServiceCollection collection, Window window)
    {
        collection.AddSingleton<IFilesService>(x => new FilesService(window));
    }
}
