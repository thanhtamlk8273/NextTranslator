using Avalonia.Controls;
using Avalonia.ReactiveUI;
using FluentAvalonia.UI.Controls;
using Microsoft.Extensions.DependencyInjection;
using NextTranslator.ViewModels;
using ReactiveUI;
using System;

namespace NextTranslator.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(disposables =>
        {
            // Default NavView
            if (this.FindControl<NavigationView>("BaseView") is NavigationView nv)
            {
                nv.SelectionChanged += OnBaseViewSelectionChanged;
                nv.SelectedItem = nv.MenuItems[0];
            }
        });
    }

    private void OnBaseViewSelectionChanged(object? sender, NavigationViewSelectionChangedEventArgs e)
    {
        if (sender is not NavigationView nv) return;

        if (e.IsSettingsSelected)
        {
            nv.Content = null;
        }
        else if (e.SelectedItem is NavigationViewItem nvi)
        {
            var smpPage = $"NextTranslator.Views.{nvi.Tag}";
            var pageModelName = $"NextTranslator.ViewModels.{nvi.Tag}Model";
            Console.WriteLine($"Getting {smpPage}");
            nv.Content = Type.GetType(smpPage) is Type vType ? Activator.CreateInstance(vType) : null;
            nv.DataContext = Type.GetType(pageModelName) is Type vmType ?
                ((MainWindowViewModel?)this.DataContext)?.ServiceProvider.GetRequiredService(vmType) : null;

            if (nv.Content is null)
            {
                Console.WriteLine("view is null");
            }
        }
    }
}