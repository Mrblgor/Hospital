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

        switch (choice)
        {
            case "1":
                InMemoryRepository mem = new InMemoryRepository();
                departments = mem.GetDepartments();
                doctors = mem.GetDoctors();
                patients = mem.GetPatients();
                break;

            case "2":
                CsvRepository csv = new CsvRepository("data");
                departments = csv.GetDepartments();
                doctors = csv.GetDoctors();
                patients = csv.GetPatients();
                break;

            default:
                Console.WriteLine("Неверный выбор");
                return;
        }

        if (departments == null || doctors == null || patients == null)
        {
            Console.WriteLine("Не удалось загрузить данные.");
            return;
        }

        if (patients.Count == 0)
        {
            Console.WriteLine("Список пациентов пуст.");
            return;
        }

        // 1. Врач пациента
        Doctor doc = FindDoctor(patients[0], doctors);
        if (doc != null)
        {
            Console.WriteLine($"1. FindDoctor(\"{patients[0].FullName}\"): " + doc.GetInfo());
        }

        // 2. Отделение врача
        Department dep = FindDepartment(doc, departments);
        if (dep != null)
        {
            Console.WriteLine($"2. FindDepartment(доктор \"{doc.FullName}\"): " + dep.GetInfo());
        }

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
    }

    /// <summary>
    /// Находит лечащего врача для указанного пациента.
    /// </summary>
    static Doctor FindDoctor(Patient patient, List<Doctor> doctors)
    {
        if (patient == null || doctors == null) return null;
        foreach (Doctor d in doctors)
        {
            if (d.Id == patient.DoctorId) return d;
        }
        return null;
    }

    /// <summary>
    /// Находит отделение, в котором работает указанный врач.
    /// </summary>
    static Department FindDepartment(Doctor doctor, List<Department> departments)
    {
        if (doctor == null || departments == null) return null;
        foreach (Department d in departments)
        {
            if (d.Id == doctor.DepartmentId) return d;
        }
        return null;
    }

    /// <summary>
    /// Вычисляет средний возраст пациентов.
    /// </summary>
    static double GetAverageAge(List<Patient> patients)
    {
        if (patients == null || patients.Count == 0) return 0;
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
    static Dictionary<string, int> CountPatientsByDiagnosis(List<Patient> patients)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();
        if (patients == null) return result;
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
    static void PrintAllPatients(List<Patient> patients, List<Doctor> doctors, List<Department> departments)
    {
        if (patients == null || doctors == null || departments == null) return;
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
