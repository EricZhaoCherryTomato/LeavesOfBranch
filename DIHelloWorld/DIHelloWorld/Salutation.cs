namespace DIHelloWorld
{
    internal class Salutation
    {
        private readonly IMessageWriter _writer;

        public Salutation(IMessageWriter writer)
        {
            _writer = writer;
        }

        public void Exclaim()
        {
            _writer.Write("Hello DI");
        }
    }
}