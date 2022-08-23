namespace OnlineMall.Models.Users
{
    public class CartBudgetM : CartM
    {

        public CartBudgetM()
        {
             
        } 
        public double BudgetMaxAmount { get; set; }
        public bool isStrict { get; set; }
        public DateTime NotificationDate { get; set; }

    }
}
