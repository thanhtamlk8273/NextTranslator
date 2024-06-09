using Avalonia.ReactiveUI;
using NextTranslator.ViewModels;
using System;

namespace NextTranslator.Views;

public partial class DictionariesContentView : ReactiveUserControl<DictionariesContentViewModel>
{
    public DictionariesContentView()
    {
        InitializeComponent();
    }

    private void ListBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        if (e.RemovedItems.Count > 0 && e.RemovedItems[0] is DictionarySelectionModel deselected)
        {
            deselected.IsSelected = false;
        }

        if (e.AddedItems.Count > 0 && e.AddedItems[0] is DictionarySelectionModel selected) {
            selected.IsSelected = true;
        }
    }
}