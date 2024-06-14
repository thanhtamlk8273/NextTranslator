using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;

namespace NextTranslator.Controls;

public partial class EditableTextBlock : UserControl
{
    public static readonly StyledProperty<string?> TextProperty = AvaloniaProperty.Register<EditableTextBlock, string?>
        (nameof(Text), default(string), false, BindingMode.TwoWay);

    public string? Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public EditableTextBlock()
    {
        InitializeComponent();
    }
}