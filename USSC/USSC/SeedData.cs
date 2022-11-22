using USSC.Entities;

namespace USSC;

public static class SeedData
{
    // users hardcoded for simplicity, store in a db with hashed passwords in production applications
    public static List<UsersEntity> Users = new List<UsersEntity>
    {
        new UsersEntity()
        {
            Id = Guid.Empty, 
            Surname = "Test", 
            Name = "User", 
            Patronymic = "UserPatr", 
            Email = "test@mail.ru", 
            HashedPassword = "test"
        }
    };
}