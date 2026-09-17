namespace Hospital;

internal class Patient
{
    public int Id {  get; set; }
    public string FullName { get; set; }
    public int DoctorId { get; set; }
    public string Diagnosis { get; set; }
    public int Age {  get; set; }
    public bool IsElderly => Age > 60;
    public string GetInfo()
    {
        return $"{FullName} ({Age} лет, {Diagnosis})";
    }
}
