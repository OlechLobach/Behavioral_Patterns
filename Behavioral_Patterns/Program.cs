using MediatorPattern;


namespace MainProject { 
class Program
{
    static void Main(string[] args)
    {
        ChatRoom chatMediator = new ChatRoom();

        User user1 = new ChatUser(chatMediator, "User 1");
        User user2 = new ChatUser(chatMediator, "User 2");
        User user3 = new ChatUser(chatMediator, "User 3");

        chatMediator.AddUser(user1);
        chatMediator.AddUser(user2);
        chatMediator.AddUser(user3);

        user1.Send("Hello, everyone!");
        user2.Send("Hi, User 1!");
        user3.Send("Hey there!");
    }
}
}
