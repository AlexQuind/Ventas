using ventas.infrastructure.DbContexts;

Console.WriteLine("Creando la DB si no existe...");
VentasContext db = new VentasContext();
db.Database.EnsureCreated();
Console.WriteLine("Listo!!!!!");
Console.ReadKey();
