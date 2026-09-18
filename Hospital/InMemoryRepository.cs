using System.Security.Cryptography.X509Certificates;

namespace Hospital;

/// <summary>
/// Репозиторий с данными больницы, хранящимися в памяти.
/// </summary>
internal class InMemoryRepository
{
    /// <summary>
    /// Приватный список отделений.
    /// </summary>
    private List<Department> _departments;

    /// <summary>
    /// Приватный список врачей.
    /// </summary>
    private List<Doctor> _doctors;

    /// <summary>
    /// Приватный список пациентов.
    /// </summary>
    private List<Patient> _patients;

    /// <summary>
    /// Инициализирует новый экземпляр репозитория и заполняет списки тестовыми данными.
    /// </summary>
    public InMemoryRepository()
    {
        _departments = new List<Department>
        {
            new Department { Id = 1, Name = "Терапия", Head = "Сидоров С.С." },
            new Department { Id = 2, Name = "Хирургия", Head = "Иванов И.И." },
            new Department { Id = 3, Name = "Кардиология", Head = "Кузнецова Е.Н." }
        };

        _doctors = new List<Doctor>
        {
            new Doctor { Id = 101, FullName = "Сидоров С.С.", DepartmentId = 1, Specialty = "Терапевт" },
            new Doctor { Id = 102, FullName = "Петрова А.В.", DepartmentId = 2, Specialty = "Хирург" },
            new Doctor { Id = 103, FullName = "Васильев К.М.", DepartmentId = 1, Specialty = "Терапевт" },
            new Doctor { Id = 104, FullName = "Павлов Д.С.", DepartmentId = 2, Specialty = "Хирург" },
            new Doctor { Id = 105, FullName = "Кузнецова Е.Н.", DepartmentId = 3, Specialty = "Кардиолог" },
            new Doctor { Id = 106, FullName = "Смирнов А.А.", DepartmentId = 3, Specialty = "Кардиолог" },
            new Doctor { Id = 107, FullName = "Дмитриева М.В.", DepartmentId = 1, Specialty = "Терапевт" }
        };

        _patients = new List<Patient>
        {
            new Patient { Id = 201, FullName = "Петров П.П.", DoctorId = 101, Diagnosis = "Грипп", Age = 58 },
            new Patient { Id = 202, FullName = "Смирнова О.Н.", DoctorId = 102, Diagnosis = "Аппендицит", Age = 65 },
            new Patient { Id = 203, FullName = "Козлов А.А.", DoctorId = 103, Diagnosis = "Бронхит", Age = 34 },
            new Patient { Id = 204, FullName = "Морозова Е.В.", DoctorId = 104, Diagnosis = "Холецистит", Age = 42 },
            new Patient { Id = 205, FullName = "Соколов Н.И.", DoctorId = 105, Diagnosis = "Гипертония", Age = 71 },
            new Patient { Id = 206, FullName = "Попова Т.С.", DoctorId = 106, Diagnosis = "Аритмия", Age = 63 },
            new Patient { Id = 207, FullName = "Лебедев В.Б.", DoctorId = 107, Diagnosis = "ОРВИ", Age = 19 },
            new Patient { Id = 208, FullName = "Волков Д.М.", DoctorId = 101, Diagnosis = "Пневмония", Age = 45 },
            new Patient { Id = 209, FullName = "Новикова Л.А.", DoctorId = 102, Diagnosis = "Грыжа", Age = 52 },
            new Patient { Id = 210, FullName = "Федоров С.П.", DoctorId = 103, Diagnosis = "Гастрит", Age = 28 },
            new Patient { Id = 211, FullName = "Морозов И.К.", DoctorId = 104, Diagnosis = "Перелом", Age = 31 },
            new Patient { Id = 212, FullName = "Васильева Н.П.", DoctorId = 105, Diagnosis = "Стенокардия", Age = 68 },
            new Patient { Id = 213, FullName = "Кузнецов О.В.", DoctorId = 106, Diagnosis = "Ишемия", Age = 74 },
            new Patient { Id = 214, FullName = "Семенова Е.Д.", DoctorId = 107, Diagnosis = "Ангина", Age = 25 },
            new Patient { Id = 215, FullName = "Тихонов А.Г.", DoctorId = 101, Diagnosis = "Фарингит", Age = 61 }
        };
    }

    /// <summary>
    /// Возвращает список отделений.
    /// </summary>
    /// <returns>Список объектов <see cref="Department"/>.</returns>
    public List<Department> GetDepartments() { return _departments; }

    /// <summary>
    /// Возвращает список врачей.
    /// </summary>
    /// <returns>Список объектов <see cref="Doctor"/>.</returns>
    public List<Doctor> GetDoctors() { return _doctors; }

    /// <summary>
    /// Возвращает список пациентов.
    /// </summary>
    /// <returns>Список объектов <see cref="Patient"/>.</returns>
    public List<Patient> GetPatients() { return _patients; }
}
