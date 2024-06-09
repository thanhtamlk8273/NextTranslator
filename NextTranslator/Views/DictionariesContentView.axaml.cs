using Avalonia.ReactiveUI;
using NextTranslator.ViewModels;

namespace NextTranslator.Views;

public partial class DictionariesContentView : ReactiveUserControl<DictionariesContentViewModel>
{
    public DictionariesContentView()
    {
        InitializeComponent();
    }
}