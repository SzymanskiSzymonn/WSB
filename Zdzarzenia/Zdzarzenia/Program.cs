namespace Zdzarzenia
{
    public delegate void MessageHandler(string message);
    public class Publisher
    {
        public event MessageHandler MessageEvent;

        public void SendMessage(string message)
        {
            if (MessageEvent != null)
            {
                MessageEvent(message);
            }
        }
    }

    public class Subscriber
    {

        public void OnMessageReceived(string message)
        {
            Console.WriteLine("Otrzymałem wiadomość: {0}", message);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Publisher publisher = new Publisher();
            Subscriber subscriber = new Subscriber();
            
            publisher.MessageEvent += subscriber.OnMessageReceived;
            publisher.SendMessage("test1");
            publisher.SendMessage("test2");
            publisher.SendMessage("test3");
            publisher.SendMessage("test4");
            publisher.MessageEvent -= subscriber.OnMessageReceived;
            publisher.SendMessage("test5");
        }
    }
}