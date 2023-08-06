namespace gof.Creational.AbstractFactory.Models.Motif;

using gof.Creational.AbstractFactory.Models.Base;

/// <summary>
/// Полоса прокрутки для стандарта Motif.
/// </summary>
public sealed class MotifScrollBar : ScrollBar
{
    /// <inheritdoc cref="MotifScrollBar"/>
    /// <param name="colour">Цвет.</param>
    /// <param name="size">Размер.</param>
    /// <param name="isEnable">Включена ли полоса прокрутки.</param>
    public MotifScrollBar(string colour, string size, bool isEnable) : base(colour, size)
    {
        IsEnable = isEnable;
    }

    /// <summary>
    /// Включена ли полоса прокрутки.
    /// </summary>
    public bool IsEnable { get; set; }
}