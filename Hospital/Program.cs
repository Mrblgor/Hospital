using System;
using System.Collections.Generic;

namespace Hospital;

internal class Program
{
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
            patients = mem.Patients();
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

    static Doctor FindDoctor(Patient patient, List<Doctor> doctors)
    {
        if (patient == null) return null;
        foreach (Doctor d in doctors)
        {
            if (d.Id == patient.DoctorId) return d;
        }
        return null;
    }

    static Department FindDepartment(Doctor doctor, List<Department> departments)
    {
        if (doctor == null) return null;
        foreach (Department d in departments)
        {
            if (d.Id == doctor.DepartmentId) return d;
        }
        return null;
    }

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