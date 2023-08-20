using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;

using MoriensTrello.WebApi.Persistence;
using MoriensTrello.WebApi.Persistence.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options => {
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddDbContext<MoriensTrelloDbContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("MoriensTrelloDb"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("debug", async (IConfiguration conf, MoriensTrelloDbContext context) => {
    await context.MonthPlans.AddAsync(new MonthPlan {
        Name = "The test one"
    });
    await context.SaveChangesAsync();
});

app.Run();
