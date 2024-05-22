namespace VC_API.Entities.Relations
{
    public class UserHasPet
    {
        public int UserId { get; set; }
        public User user { get; set; }
        public int PetId { get; set; }
        public Pets pets { get; set; }
    }
}
