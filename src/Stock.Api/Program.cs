using Microsoft.EntityFrameworkCore;
using Stock.Api.Endpoints;
using Stock.Api.Extensions;
using Stock.Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices();

var app = builder.Build();

app.RegisterMiddlewares();

app.RegisterEndpoints();

app.Run();
