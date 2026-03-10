namespace TalentGrid.Application.Feature.Mentor.Queries.GetMentorAdvice
{
    public class GetMentorAdviceQuery
    {
        public int EmployeeId { get; set; }
        public string TargetRole { get; set; } = string.Empty;
    }
}
