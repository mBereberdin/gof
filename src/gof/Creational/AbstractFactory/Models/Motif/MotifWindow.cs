namespace gof.Creational.AbstractFactory.Models.Motif;

using gof.Creational.AbstractFactory.Models.Base;

/// <summary>
/// Окно для стандарта Motif.
/// </summary>
public sealed class MotifWindow : Window
{
    /// <inheritdoc cref="MotifWindow"/>
    /// <param name="colour">Цвет.</param>
    /// <param name="size">Размер.</param>
    /// <param name="isMinimizeButtonEnable">Включена ли кнопка уменьшения окна.</param>
    public MotifWindow(string colour, string size, bool isMinimizeButtonEnable) : base(colour, size)
    {
        IsMinimizeButtonEnable = isMinimizeButtonEnable;
    }

    /// <summary>
    /// Включена ли кнопка уменьшения окна.
    /// </summary>
    public bool IsMinimizeButtonEnable { get; set; }
}