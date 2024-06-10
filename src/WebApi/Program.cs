using Domain.Interfaces.IAluno;
using Domain.Interfaces.ICurso;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IRelacionamentoAlunoTurma;
using Domain.Interfaces.ITurma;
using Domain.Servicos;
using Infra.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
    options.AddPolicy("AllowSpecificOrigin",
    builder => builder
    .WithOrigins("http://localhost:5152/")
    .AllowAnyMethod()
    .AllowAnyHeader())
);



// INTERFACE E REPOSITORIO
builder.Services.AddSingleton<InterfaceAluno, AlunoRepositorio>();
builder.Services.AddSingleton<InterfaceTurma, TurmaRepositorio>();
builder.Services.AddSingleton<InterfaceCurso, CursoRepositorio>();
builder.Services.AddSingleton<InterfaceRelacionamentoAlunoTurmas, RelacionamentoAlunoTurmasRepositorio>();
// SERVI�O DOMINIO
builder.Services.AddSingleton<IAlunoServicos, AlunoServico>();
builder.Services.AddSingleton<ITurmaServicos, TurmaServico>();
builder.Services.AddSingleton<ICursoServicos, CursoServico>();
builder.Services.AddSingleton<IRelacionamentoAlunoTurmasServicos, RelacionamentoAlunoTurmaServico>();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}


app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();

//New
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
