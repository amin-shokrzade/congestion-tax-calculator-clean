using Application.Interfaces;

namespace Website.Infrastructure
{
    public abstract class EndpointGroupBase
    {
        public abstract void Map(WebApplication app);
    }
}
