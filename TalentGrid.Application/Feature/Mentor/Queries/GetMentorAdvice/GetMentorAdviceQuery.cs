namespace TalentGrid.Application.Feature.Mentor.Queries.GetMentorAdvice
{
    public class GetMentorAdviceQuery
    {
        public int EmployeeId { get; set; }
        //public string CurrentRole { get; set; } = string.Empty;
        //public List<string> Skills { get; set; } = new List<string>();
        public string TargetRole { get; set; } = string.Empty;
    }
}
