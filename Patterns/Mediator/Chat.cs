using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    public abstract class ChatMediator
    {
        public abstract void SendMessage(string message, User user);
    }

    public class ChatRoom : ChatMediator
    {
        private List<User> users = new List<User>();

        public override void SendMessage(string message, User user)
        {
            foreach (var u in users)
            {
                if (u != user)
                {
                    u.Receive(message);
                }
            }
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }
    }

    public abstract class User
    {
        protected ChatMediator mediator;
        protected string name;

        public User(ChatMediator mediator, string name)
        {
            this.mediator = mediator;
            this.name = name;
        }

        public abstract void Send(string message);
        public abstract void Receive(string message);
    }

    public class ChatUser : User
    {
        public ChatUser(ChatMediator mediator, string name) : base(mediator, name)
        {
        }

        public override void Send(string message)
        {
            Console.WriteLine($"{name} sends: {message}");
            mediator.SendMessage(message, this);
        }

        public override void Receive(string message)
        {
            Console.WriteLine($"{name} receives: {message}");
        }
    }
}
