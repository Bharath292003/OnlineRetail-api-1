using Microsoft.EntityFrameworkCore;
using onlineRetail.Mapping;
using onlineRetail.Model;
using onlineRetail.Repository;
using onlineRetail.Repository.IRepository;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<CombineContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOriginPolicy",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

#region configure automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));
#endregion


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
var app = builder.Build();
app.UseCors("AllowAnyOriginPolicy");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
