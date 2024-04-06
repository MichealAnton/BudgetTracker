namespace Expense_Tracker.Models
{
    public class Account
    {
        public int AcccountId { get; set; }
        public string Name { get; set; }
        public int UserId {  get; set; }
        public User User { get; set; }
        public double InitialBudget { get; set; }
        public string Notes { get; set; }
    }
}
