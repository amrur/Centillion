using MediatR;

namespace TestConsoleApp
{
    class TestMediatR
    {

    }

    public class Ping : IRequest<string> { }
    public class PingHandler : IRequestHandler<Ping, string>
    {
        public string Handle(Ping request)
        {
            return "Pong";
        }
    }
}
