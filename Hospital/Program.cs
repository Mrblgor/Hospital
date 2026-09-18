using System;
using System.Collections.Generic;

namespace Hospital;

/// <summary>
/// Точка входа в программу, демонстрирующую работу с больничными данными.
/// </summary>
internal class Program
{
    /// <summary>
    /// Главный метод программы. Запрашивает источник данных и выполняет демонстрационные запросы.
    /// </summary>
    static void Main()
    {
        List<Department> departments;
        List<Doctor> doctors;
        List<Patient> patients;

        Console.WriteLine("1 — InMemory, 2 — CSV");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            InMemoryRepository mem = new InMemoryRepository();
            departments = mem.GetDepartments();
            doctors = mem.GetDoctors();
            patients = mem.GetPatients();
        }
        else if (choice == "2")
        {
            CsvRepository csv = new CsvRepository("data");
            departments = csv.GetDepartments();
            doctors = csv.GetDoctors();
            patients = csv.GetPatients();
        }
        else
        {
            Console.WriteLine("Неверный выбор");
            return;
        }

        // 1. Врач пациента
        Doctor doc = FindDoctor(patients[0], doctors);
        if (doc != null)
            Console.WriteLine($"1. FindDoctor(\"{patients[0].FullName}\"): " + doc.GetInfo());
        else
            Console.WriteLine($"1. FindDoctor(\"{patients[0].FullName}\"): —");

        // 2. Отделение врача
        Department dep = FindDepartment(doc, departments);
        if (dep != null)
            Console.WriteLine($"2. FindDepartment(doctor \"{(doc != null ? doc.FullName : "")}\"): " + dep.GetInfo());
        else
            Console.WriteLine($"2. FindDepartment(doctor \"{(doc != null ? doc.FullName : "")}\"): —");

        // 3. Средний возраст
        Console.WriteLine("3. GetAverageAge: " + GetAverageAge(patients) + " лет");

        // 4. Количество по диагнозам
        Console.Write("4. CountPatientsByDiagnosis: ");
        Dictionary<string, int> diagnosisCount = CountPatientsByDiagnosis(patients);
        bool first = true;
        foreach (KeyValuePair<string, int> pair in diagnosisCount)
        {
            if (!first) Console.Write(", ");
            Console.Write($"{pair.Key} — {pair.Value}");
            first = false;
        }
        Console.WriteLine();

        // 5. Вывод всех пациентов
        Console.WriteLine("5. PrintAllPatients:");
        PrintAllPatients(patients, doctors, departments);

        Patient unknown = new Patient { FullName = "Неизвестный пациент" };
        Doctor notFound = FindDoctor(unknown, doctors);
        if (notFound == null)
            Console.WriteLine($"Не найдено: FindDoctor(\"Неизвестный пациент\") -> null");
        else
            Console.WriteLine($"Найден: {notFound.GetInfo()}");
    }

    /// <summary>
    /// Находит лечащего врача для указанного пациента.
    /// </summary>
    /// <param name="patient">Пациент, для которого ищется врач.</param>
    /// <param name="doctors">Список врачей.</param>
    /// <returns>Объект <see cref="Doctor"/> или <c>null</c>, если врач не найден.</returns>
    static Doctor FindDoctor(Patient patient, List<Doctor> doctors)
    {
        if (patient == null) return null;
        foreach (Doctor d in doctors)
        {
            if (d.Id == patient.DoctorId) return d;
        }
        return null;
    }

    /// <summary>
    /// Находит отделение, в котором работает указанный врач.
    /// </summary>
    /// <param name="doctor">Врач, для которого ищется отделение.</param>
    /// <param name="departments">Список отделений.</param>
    /// <returns>Объект <see cref="Department"/> или <c>null</c>, если отделение не найдено.</returns>
    static Department FindDepartment(Doctor doctor, List<Department> departments)
    {
        if (doctor == null) return null;
        foreach (Department d in departments)
        {
            if (d.Id == doctor.DepartmentId) return d;
        }
        return null;
    }

    /// <summary>
    /// Вычисляет средний возраст пациентов.
    /// </summary>
    /// <param name="patients">Список пациентов.</param>
    /// <returns>Средний возраст или 0, если список пуст.</returns>
    static double GetAverageAge(List<Patient> patients)
    {
        if (patients.Count == 0) return 0;
        int sum = 0;
        foreach (Patient p in patients)
        {
            sum += p.Age;
        }
        return (double)sum / patients.Count;
    }

    /// <summary>
    /// Подсчитывает количество пациентов по каждому диагнозу.
    /// </summary>
    /// <param name="patients">Список пациентов.</param>
    /// <returns>Словарь, где ключ — диагноз, значение — количество пациентов.</returns>
    static Dictionary<string, int> CountPatientsByDiagnosis(List<Patient> patients)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();
        foreach (Patient p in patients)
        {
            if (result.ContainsKey(p.Diagnosis))
                result[p.Diagnosis]++;
            else
                result[p.Diagnosis] = 1;
        }
        return result;
    }

    /// <summary>
    /// Выводит в консоль информацию обо всех пациентах с указанием их врача и отделения.
    /// </summary>
    /// <param name="patients">Список пациентов.</param>
    /// <param name="doctors">Список врачей.</param>
    /// <param name="departments">Список отделений.</param>
    static void PrintAllPatients(List<Patient> patients, List<Doctor> doctors, List<Department> departments)
    {
        foreach (Patient p in patients)
        {
            Doctor d = FindDoctor(p, doctors);
            Department dep = FindDepartment(d, departments);

            string doctorInfo = d != null ? d.GetInfo() : "—";
            string depName = dep != null ? dep.Name : "—";

            Console.WriteLine($"\"{p.GetInfo()}\" — врач {doctorInfo}, отделение \"{depName}\"");
        }
    }
}
