namespace Hospital;

/// <summary>
/// Представляет отделение больницы.
/// </summary>
internal class Department
{
    private int _id;

    /// <summary>
    /// Уникальный идентификатор отделения (только для чтения).
    /// </summary>
    public int Id => _id;

    /// <summary>
    /// Название отделения.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// ФИО заведующего отделением.
    /// </summary>
    public string Head { get; init; }

    /// <summary>
    /// Конструктор с полным набором параметров.
    /// </summary>
    public Department(int id, string name, string head)
    {
        _id = id;
        Name = name;
        Head = head;
    }

    /// <summary>
    /// Возвращает строковое представление информации об отделении.
    /// </summary>
    /// <returns>Строка вида "Название (зав.: ФИО)".</returns>
    public string GetInfo()
    {
        return $"{Name} (зав.: {Head})";
    }
}
