using Avalonia.ReactiveUI;
using NextTranslator.ViewModels;

namespace NextTranslator.Views;

public partial class TranslationView : ReactiveUserControl<TranslationViewModel>
{
    public TranslationView()
    {
        InitializeComponent();
    }
}