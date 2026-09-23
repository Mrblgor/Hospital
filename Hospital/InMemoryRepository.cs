namespace Hospital;

/// <summary>
/// Репозиторий с данными больницы, хранящимися в памяти.
/// </summary>
internal class InMemoryRepository
{
    private List<Department> _departments;
    private List<Doctor> _doctors;
    private List<Patient> _patients;

    /// <summary>
    /// Инициализирует новый экземпляр репозитория и заполняет списки тестовыми данными.
    /// </summary>
    public InMemoryRepository()
    {
        _departments = new List<Department>
        {
            new Department(1, "Терапия",     "Сидоров С.С."),
            new Department(2, "Хирургия",    "Иванов И.И."),
            new Department(3, "Кардиология", "Кузнецова Е.Н.")
        };

        _doctors = new List<Doctor>
        {
            new Doctor(101, "Сидоров С.С.",    1, "Терапевт"),
            new Doctor(102, "Петрова А.В.",    2, "Хирург"),
            new Doctor(103, "Васильев К.М.",   1, "Терапевт"),
            new Doctor(104, "Павлов Д.С.",     2, "Хирург"),
            new Doctor(105, "Кузнецова Е.Н.",  3, "Кардиолог"),
            new Doctor(106, "Смирнов А.А.",    3, "Кардиолог"),
            new Doctor(107, "Дмитриева М.В.",  1, "Терапевт")
        };

        _patients = new List<Patient>
        {
            new Patient(201, "Петров П.П.",     101, "Грипп",        58),
            new Patient(202, "Смирнова О.Н.",   102, "Аппендицит",   65),
            new Patient(203, "Козлов А.А.",     103, "Бронхит",      34),
            new Patient(204, "Морозова Е.В.",   104, "Холецистит",   42),
            new Patient(205, "Соколов Н.И.",    105, "Гипертония",   71),
            new Patient(206, "Попова Т.С.",     106, "Аритмия",      63),
            new Patient(207, "Лебедев В.Б.",    107, "ОРВИ",         19),
            new Patient(208, "Волков Д.М.",     101, "Пневмония",    45),
            new Patient(209, "Новикова Л.А.",   102, "Грыжа",        52),
            new Patient(210, "Федоров С.П.",    103, "Гастрит",      28),
            new Patient(211, "Морозов И.К.",    104, "Перелом",      31),
            new Patient(212, "Васильева Н.П.",  105, "Стенокардия",  68),
            new Patient(213, "Кузнецов О.В.",   106, "Ишемия",       74),
            new Patient(214, "Семенова Е.Д.",   107, "Ангина",       25),
            new Patient(215, "Тихонов А.Г.",    101, "Фарингит",     61)
        };
    }

    /// <summary>
    /// Возвращает список отделений.
    /// </summary>
    public List<Department> GetDepartments() { return _departments; }

    /// <summary>
    /// Возвращает список врачей.
    /// </summary>
    public List<Doctor> GetDoctors() { return _doctors; }

    /// <summary>
    /// Возвращает список пациентов.
    /// </summary>
    public List<Patient> GetPatients() { return _patients; }
}
