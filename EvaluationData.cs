public class EvaluationData
{
    public int EmployeeId { get; set; }
    public int GroupId { get; set; }
    public DateTime AnsweredOn { get; set; }
    public int Answer1 { get; set; }
    public int Answer2 { get; set; }
    public int Answer3 { get; set; }
    public int Answer4 { get; set; }
    public int Answer5 { get; set; }

    public double AverageScore => (Answer1 + Answer2 + Answer3 + Answer4 + Answer5) / 5.0;
}
