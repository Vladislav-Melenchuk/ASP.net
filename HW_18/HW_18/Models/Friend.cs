namespace HW_18.Models
{
    public class Friend
    {
        public int Id { get; set; }

        public string UserId { get; set; }      
        public string FriendId { get; set; }    

        public bool IsConfirmed { get; set; }

        
        public User User { get; set; }          
        public User FriendUser { get; set; }    
    }

}
