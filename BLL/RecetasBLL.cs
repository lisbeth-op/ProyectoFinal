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
        bool paso=false;
        _contexto.Recetas.Add(receta);
        paso= _contexto.SaveChanges() > 0;
        var producto = _contexto.Productos.Find(receta.ProductoId);
        if (producto != null)
        {
            producto.RecetaId = receta.RecetaId;
            _contexto.Entry(producto).State=EntityState.Modified;
        }
        return paso;
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
                                 .SingleOrDefault(r => r.RecetaId == recetaId);
    }

    public List<Recetas> GetList(Expression<Func<Recetas, bool>> criterio)
    {
        return _contexto.Recetas.Include(r => r.detalleRecetas)
                                 .Where(criterio).ToList();
    }
    public bool Modificar(Recetas receta)
    {
        bool paso = false;
        _contexto.Entry(receta).State = EntityState.Modified;
        paso= _contexto.SaveChanges()>0;
        var producto = _contexto.Productos.Find(receta.ProductoId);
        if (producto != null)
        {
            producto.RecetaId = receta.RecetaId;
            _contexto.Entry(producto).State = EntityState.Modified;
        }
        return paso;
    }

    public bool Eliminar(int recetaId)
    {
        var receta = _contexto.Recetas.SingleOrDefault(r => r.RecetaId == recetaId);
        bool paso = false;
        if (receta != null)
        {
            var producto = _contexto.Productos.Find(receta.ProductoId);
            if (producto != null)
            {
                producto.RecetaId =0;
                _contexto.Entry(producto).State = EntityState.Modified;
            }
            paso=_contexto.SaveChanges()>0;
            _contexto.Recetas.Remove(receta);
        }
        return paso;
    }

}
