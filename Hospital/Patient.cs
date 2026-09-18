namespace Hospital;

/// <summary>
/// Представляет пациента больницы.
/// </summary>
internal class Patient
{
    /// <summary>
    /// Уникальный идентификатор пациента.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// ФИО пациента.
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// Идентификатор лечащего врача.
    /// </summary>
    public int DoctorId { get; set; }

    /// <summary>
    /// Диагноз пациента.
    /// </summary>
    public string Diagnosis { get; set; }

    /// <summary>
    /// Возраст пациента.
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Признак того, что пациент пожилого возраста (старше 60 лет).
    /// </summary>
    public bool IsElderly => Age > 60;

    /// <summary>
    /// Возвращает строковое представление информации о пациенте.
    /// </summary>
    /// <returns>Строка вида "ФИО (возраст лет, диагноз)".</returns>
    public string GetInfo()
    {
        return $"{FullName} ({Age} лет, {Diagnosis})";
    }
}
