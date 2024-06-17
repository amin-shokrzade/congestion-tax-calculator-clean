using System.Reflection;

namespace Website.Infrastructure
{
    public static class WebApplicationExtensions
    {
        public static RouteGroupBuilder MapGroup(this WebApplication app, EndpointGroupBase group)
        {
            var groupName = group.GetType().Name.ToLower();
            var namespaceName = group.GetType().Namespace?.Split('.').LastOrDefault()?.ToLower();

            namespaceName = namespaceName ?? "other";
            return app
                .MapGroup($"/api/{namespaceName}/{groupName}")
                .WithGroupName(groupName)
                .WithTags(groupName)
                .WithOpenApi();
        }

        public static WebApplication MapEndpoints(this WebApplication app)
        {
            var endpointGroupType = typeof(EndpointGroupBase);

            var assembly = Assembly.GetExecutingAssembly();

            var endpointGroupTypes = assembly.GetExportedTypes()
                .Where(t => t.IsSubclassOf(endpointGroupType));

            foreach (var type in endpointGroupTypes)
            {
                if (Activator.CreateInstance(type) is EndpointGroupBase instance)
                {
                    instance.Map(app);
                }
            }

            return app;
        }
    }
}
