using Yarp.ReverseProxy.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromMemory(
        routes: new[]
        {
            new RouteConfig
            {
                RouteId  = "orders",
                ClusterId = "orders-cluster",
                Match    = new() { Path = "/orders/{**catchAll}" }
            },
            new RouteConfig
            {
                RouteId  = "orders-hub",
                ClusterId = "orders-cluster",
                Match    = new() { Path = "/hub/orders/{**catchAll}" }
            },
            new RouteConfig
            {
                RouteId  = "payments",
                ClusterId = "payments-cluster",
                Match    = new() { Path = "/payments/{**catchAll}" }
            }
        },
        clusters: new[]
        {
            new ClusterConfig
            {
                ClusterId    = "orders-cluster",
                Destinations = new Dictionary<string, DestinationConfig>
                {
                    ["primary"] = new() { Address = "http://order-service:8080/" }
                }
            },
            new ClusterConfig
            {
                ClusterId    = "payments-cluster",
                Destinations = new Dictionary<string, DestinationConfig>
                {
                    ["primary"] = new() { Address = "http://payment-service:8080/" }
                }
            }
        });

var app = builder.Build();

app.UseWebSockets(); 
app.MapReverseProxy();

app.Run();
