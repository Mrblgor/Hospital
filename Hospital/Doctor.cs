namespace Hospital;

internal class Doctor
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public int DepartmentId { get; set; }
    public string Specialty { get; set; }
    public bool IsSuregion => Specialty == "Хирург";
    public string GetInfo()
    {
        return $"{FullName} ({Specialty})";
    }
}
