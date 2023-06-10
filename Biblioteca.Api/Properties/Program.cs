


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BibliotecaContext>(options => options.UseSqlServer(
                 builder.Configuration.GetConnectionString("BibliotecaContext")));

builder.Services.AddTransient<IprestamosRepository, PresatamoRepositories>();