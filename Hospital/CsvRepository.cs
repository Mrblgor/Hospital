using System.Collections.Generic;
using System.IO;

namespace Hospital;

internal class CsvRepository
{
    private string _basePath;
    public CsvRepository(string basePath)
    {
        _basePath = basePath;
    }
    public List<Department> GetDepartments()
    {
        List<Department> departmentsresult = new List<Department>();
        string path = Path.Combine(_basePath, "Department_Baza.csv");

        if (File.Exists(path)) return departmentsresult;

        string[] lines = File.ReadAllLines(path);

        if (lines.Length < 2) return departmentsresult;

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(",");
            if (parts.Length < 3) continue;

            Department dep = new Department();
            dep.Id = int.Parse(parts[0]);
            dep.Name = parts[1];
            dep.Head = parts[2];

            departmentsresult.Add(dep);
        }
        return departmentsresult;
    }
    public List<Doctor> GetDoctors()
    {
        List<Doctor> doctorsresult = new List<Doctor>();
        string path = Path.Combine(_basePath, "Doctor_Baza.csv");

        if(!File.Exists(path)) return doctorsresult;

        string[] lines = File.ReadAllLines (path);

        if (lines.Length < 2) return doctorsresult;

        for (int i = 1;i < lines.Length; i++)
        {
            string[] parts = lines [i].Split(",");
            if (parts.Length < 4) continue; 

            Doctor doc = new Doctor();
            doc.Id = int.Parse(parts[0]);
            doc.FullName = parts[1];
            doc.DepartmentId = int.Parse(parts[2]);
            doc.Specialty = parts[3];

            doctorsresult.Add(doc);
        }
        return doctorsresult;
    }
    public List<Patient> GetPatients()
    {
        List<Patient> patientsresult = new List<Patient>();
        string path = Path.Combine(_basePath, "Patient_Baza.csv");

        if (!File.Exists(path)) return patientsresult;

        string[] lines = File.ReadAllLines (path);

        if (lines.Length < 2) return patientsresult;

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(",");
            if (parts.Length < 5) continue; 

            Patient pat = new Patient();
            pat.Id = int.Parse(parts[0]);
            pat.FullName = parts[1];
            pat.DoctorId = int.Parse(parts[2]);
            pat.Diagnosis = parts[3];
            pat.Age = int.Parse(parts[4]);

            patientsresult.Add(pat);
        }
        return patientsresult;
    }
    
}
