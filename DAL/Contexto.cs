using Microsoft.EntityFrameworkCore;

public class Contexto : DbContext
{
    public DbSet<Recetas> Recetas { get; set; }
    public DbSet<OrdenDeProducciones> OrdenDeProducciones { get; set; }
    public DbSet<MateriasPrimas> MateriasPrimas { get; set; }
    public DbSet<Productos> Productos { get; set; } 

    public Contexto(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Productos>().HasData(
                new Productos
                {
                    ProductoId = 1,
                    Descripcion = "Dulce de leche",
                    Nombre = "Bizcocho",
                    Precio = 500,
                    Existencia = 100
                },
                new Productos
                {
                    ProductoId = 2,
                    Descripcion = "De agua",
                    Nombre = "Pan",
                    Precio = 50,
                    Existencia = 100
                },
                new Productos
                {
                    ProductoId = 3,
                    Descripcion = "De coco",
                    Nombre = "Galletas",
                    Precio = 50,
                    Existencia = 100
                }

        );


        modelBuilder.Entity<MateriasPrimas>().HasData(
            new MateriasPrimas
            {
                MateriaPrimaId = 1,
                Descripcion = "azucar",
                Nombre = "morena",
                Precio = 50,
                Existencia = 100
            },
             new MateriasPrimas
             {
                 MateriaPrimaId = 2,
                 Descripcion = "Harina",
                 Nombre = "Blanca",
                 Precio = 50,
                 Existencia = 100
             },
              new MateriasPrimas
              {
                  MateriaPrimaId = 3,
                  Descripcion = "Elevadura",
                  Nombre = "no se",
                  Precio = 50,
                  Existencia = 100
              },
               new MateriasPrimas
               {
                   MateriaPrimaId = 4,
                   Descripcion = "sal",
                   Nombre = "molida",
                   Precio = 50,
                   Existencia = 100
               }

            );


    }
}

