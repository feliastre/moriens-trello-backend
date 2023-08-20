namespace MoriensTrello.WebApi.Persistence;

using Microsoft.EntityFrameworkCore;

using MoriensTrello.WebApi.Persistence.Models;

public class MoriensTrelloDbContext : DbContext {
    public virtual DbSet<MonthPlan> MonthPlans { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseNpgsql("Server=localhost;Port=1313;Database=MoriensTrello;User Id=morienstrello;Password=pwd_for_tests;").UseSnakeCaseNamingConvention();
    }

    public MoriensTrelloDbContext(DbContextOptions<MoriensTrelloDbContext> options): base(options){
    }
}
