namespace MWCodeReview.Interfaces
{
    public interface IUser
    {
        public Task<bool> DeleteUser(uint id);
    }
}
