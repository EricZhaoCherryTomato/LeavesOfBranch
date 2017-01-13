namespace RepoPattern
{
    public interface IPersonRepository
    {
        Person GetPerson(int personId);
    }
}