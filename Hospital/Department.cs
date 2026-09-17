namespace Hospital;

internal class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Head {  get; set; }
    public string GetInfo ()
    {
        return $"{Name} (зав.: {Head})";
    }
}
