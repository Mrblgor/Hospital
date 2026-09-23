using System;
namespace Hospital;

/// <summary>
/// Представляет пациента больницы.
/// </summary>
internal class Patient
{
    private int _id;
    private int _age;

    /// <summary>
    /// Уникальный идентификатор пациента (только для чтения).
    /// </summary>
    public int Id => _id;

    /// <summary>
    /// ФИО пациента.
    /// </summary>
    public string FullName { get; init; }

    /// <summary>
    /// Идентификатор лечащего врача.
    /// </summary>
    public int DoctorId { get; init; }

    /// <summary>
    /// Диагноз пациента.
    /// </summary>
    public string Diagnosis { get; init; }

    /// <summary>
    /// Возраст пациента. Допустимый диапазон: от 0 до 150.
    /// </summary>
    public int Age
    {
        get => _age;
        init => _age = ValidateAge(value);
    }

    /// <summary>
    /// Признак того, что пациент пожилого возраста (старше 60 лет).
    /// </summary>
    public bool IsElderly => Age > 60;

    /// <summary>
    /// Конструктор с полным набором параметров.
    /// </summary>
    public Patient(int id, string fullName, int doctorId, string diagnosis, int age)
    {
        _id = id;
        FullName = fullName;
        DoctorId = doctorId;
        Diagnosis = diagnosis;
        Age = age;
    }

    /// <summary>
    /// Возвращает строковое представление информации о пациенте.
    /// </summary>
    /// <returns>Строка вида "ФИО (возраст лет, диагноз)".</returns>
    public string GetInfo()
    {
        return $"{FullName} ({Age} лет, {Diagnosis})";
    }

    /// <summary>
    /// Проверяет возраст: должен быть в диапазоне от 0 до 150.
    /// </summary>
    private static int ValidateAge(int value)
    {
        if (value < 0 || value > 150)
        {
            throw new ArgumentException(
                "Возраст должен быть в диапазоне от 0 до 150.", nameof(Age));
        }
        return value;
    }
}
