namespace Hospital;

/// <summary>
/// Представляет врача больницы.
/// </summary>
internal class Doctor
{
    private int _id;

    /// <summary>
    /// Уникальный идентификатор врача (только для чтения).
    /// </summary>
    public int Id => _id;

    /// <summary>
    /// ФИО врача.
    /// </summary>
    public string FullName { get; init; }

    /// <summary>
    /// Идентификатор отделения, в котором работает врач.
    /// </summary>
    public int DepartmentId { get; init; }

    /// <summary>
    /// Специальность врача.
    /// </summary>
    public string Specialty { get; init; }

    /// <summary>
    /// Признак того, что врач является хирургом.
    /// </summary>
    public bool IsSurgeon => Specialty == "Хирург";

    /// <summary>
    /// Конструктор с полным набором параметров.
    /// </summary>
    public Doctor(int id, string fullName, int departmentId, string specialty)
    {
        _id = id;
        FullName = fullName;
        DepartmentId = departmentId;
        Specialty = specialty;
    }

    /// <summary>
    /// Возвращает строковое представление информации о враче.
    /// </summary>
    /// <returns>Строка вида "ФИО (Специальность)".</returns>
    public string GetInfo()
    {
        return $"{FullName} ({Specialty})";
    }
}
