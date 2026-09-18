namespace Hospital;

/// <summary>
/// Представляет врача больницы.
/// </summary>
internal class Doctor
{
    /// <summary>
    /// Уникальный идентификатор врача.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// ФИО врача.
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// Идентификатор отделения, в котором работает врач.
    /// </summary>
    public int DepartmentId { get; set; }

    /// <summary>
    /// Специальность врача.
    /// </summary>
    public string Specialty { get; set; }

    /// <summary>
    /// Признак того, что врач является хирургом.
    /// </summary>
    public bool IsSuregion => Specialty == "Хирург";

    /// <summary>
    /// Возвращает строковое представление информации о враче.
    /// </summary>
    /// <returns>Строка вида "ФИО (Специальность)".</returns>
    public string GetInfo()
    {
        return $"{FullName} ({Specialty})";
    }
}
