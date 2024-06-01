﻿using Microsoft.Extensions.DependencyInjection;
using System;

namespace NextTranslator.ViewModels
{
    public class MainWindowViewModel(IServiceProvider serviceProvider) : ViewModelBase
    {
#pragma warning disable CA1822 // Mark members as static
        public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as static

        public TranslationViewModel ViewModel { get; set; } = serviceProvider.GetRequiredService<TranslationViewModel>();
    }
}