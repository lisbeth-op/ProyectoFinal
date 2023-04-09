using DocumentFormat.OpenXml.InkML;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class RecetasBLL
{
    private readonly Contexto _contexto;

    public RecetasBLL(Contexto contexto)
    {
        _contexto = contexto;
    }
    public bool Existe(int recetaID)
    {
        return _contexto.Recetas.Any(p => p.RecetaId == recetaID);
    }
    public bool Insertar(Recetas receta)
    {
        _contexto.Recetas.Add(receta);
        var producto = _contexto.Productos.Find(receta.ProductoId);
        if (producto != null)
        {
            producto.RecetaId = receta.RecetaId;
            _contexto.Entry(producto).State=EntityState.Modified;
        }
        return _contexto.SaveChanges() > 0;
    }
    public bool Guardar(Recetas receta) 
    {
        if (Existe(receta.RecetaId))
        {
            return Modificar(receta);

        }
        else
        {

            return Insertar(receta);
        }
    }
    public Recetas? Buscar(int recetaId)
    {
        return _contexto.Recetas.Include(r => r.detalleRecetas)
                                 .ThenInclude(dr => dr.MateriaPrimaId)
                                 .SingleOrDefault(r => r.RecetaId == recetaId);
    }

    public List<Recetas> GetList(Expression<Func<Recetas, bool>> criterio)
    {
        return _contexto.Recetas.Include(r => r.detalleRecetas)
                                 .ThenInclude(dr => dr.MateriaPrimaId)
                                 .Where(criterio).ToList();
    }
    public bool Modificar(Recetas receta)
    {
        _contexto.Entry(receta).State = EntityState.Modified;
        var producto = _contexto.Productos.Find(receta.ProductoId);
        if (producto != null)
        {
            producto.RecetaId = receta.RecetaId;
            _contexto.Entry(producto).State = EntityState.Modified;
        }
        return _contexto.SaveChanges()>0;
    }

    public bool Eliminar(int recetaId)
    {
        var receta = _contexto.Recetas.SingleOrDefault(r => r.RecetaId == recetaId);

        if (receta != null)
        {
            _contexto.Recetas.Remove(receta);
            return _contexto.SaveChanges() > 0;
        }
        return false;
    }

}
