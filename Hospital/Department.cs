namespace Hospital;

/// <summary>
/// Представляет отделение больницы.
/// </summary>
internal class Department
{
    /// <summary>
    /// Уникальный идентификатор отделения.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название отделения.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// ФИО заведующего отделением.
    /// </summary>
    public string Head { get; set; }

    /// <summary>
    /// Возвращает строковое представление информации об отделении.
    /// </summary>
    /// <returns>Строка вида "Название (зав.: ФИО)".</returns>
    public string GetInfo()
    {
        return $"{Name} (зав.: {Head})";
    }
}
