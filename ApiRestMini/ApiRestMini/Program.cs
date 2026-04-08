using System.Collections.Generic;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

//Configuración de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Activar Swagger en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Lista en memoria para simular base de datos
var productos = new List<Producto>
{
    new Producto { Id = 1, Nombre = "Laptop", Precio = 1200 },
    new Producto { Id = 2, Nombre = "Mouse", Precio = 25 }
};

//Endpoints
app.MapGet("/productos", () => productos);

app.MapGet("/productos/{id}", (int id) =>
{
    var producto = productos.FirstOrDefault(p => p.Id == id);
    return producto is not null ? Results.Ok(producto) : Results.NotFound();
});

app.MapPost("/productos", (Producto nuevo) =>
{
    nuevo.Id = productos.Max(p => p.Id) + 1;
    productos.Add(nuevo);
    return Results.Created($"/productos/{nuevo.Id}", nuevo);
});

app.MapPut("/productos/{id}", (int id, Producto actualizado) =>
{
    var producto = productos.FirstOrDefault(p => p.Id == id);
    if (producto is null) return Results.NotFound();

    producto.Nombre = actualizado.Nombre;
    producto.Precio = actualizado.Precio;
    return Results.Ok(producto);
});

app.MapDelete("/productos/{id}", (int id) =>
{
    var producto = productos.FirstOrDefault(p => p.Id == id);
    if (producto is null) return Results.NotFound();

    productos.Remove(producto);
    return Results.NoContent();
});

app.Run();

//Modelo
record Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public double Precio { get; set; }
}
