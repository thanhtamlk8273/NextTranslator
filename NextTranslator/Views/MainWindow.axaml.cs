using Avalonia.Controls;
using Avalonia.ReactiveUI;
using FluentAvalonia.UI.Controls;
using NextTranslator.ViewModels;
using ReactiveUI;
using System;
using System.Linq;
using System.Reactive.Disposables;

namespace NextTranslator.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(disposables =>
        {
            // Default NavView
            if (this.FindControl<NavigationView>("BaseView") is NavigationView nv && nv.MenuItems.Count > 0)
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
            nv.Content = (Type.GetType(smpPage) is Type type ? Activator.CreateInstance(type) : null);
            nv.DataContext = (DataContext as MainWindowViewModel)?.ViewModel;
        }
    }
}