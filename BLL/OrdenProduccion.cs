using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class OrdenesProduccionBLL
{
    private readonly Contexto _contexto;

    public OrdenesProduccionBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Modificar(OrdenDeProducciones orden)
    {
        bool result = false;
        Productos? producto;
        Recetas? receta;
        MateriasPrimas? materias;
        var ordenAnterior = _contexto.OrdenDeProducciones
            .Where(o => o.OrdenDeProduccionId == orden.OrdenDeProduccionId)
            .Include(o => o.DetalleOrdenDeProduccions)
            .AsNoTracking()
            .SingleOrDefault();

        foreach (var detalle in ordenAnterior.DetalleOrdenDeProduccions)
        {
            producto = _contexto.Productos.Find(detalle.ProductoId);
            if (producto != null)
            {
                receta = _contexto.Recetas.Find(producto.ProductoId);
                if (receta != null)
                {
                    foreach (var recetaDetalle in receta.detalleRecetas)
                    {
                        materias = _contexto.MateriasPrimas.Find(recetaDetalle.MateriaPrimaId);
                        if (materias != null)
                        {
                            materias.Existencia += recetaDetalle.Cantidad;
                            _contexto.Entry(materias).State = EntityState.Modified;
                        }
                    }
                }
                producto.Existencia -= detalle.Cantidad;
                _contexto.Entry(producto).State = EntityState.Modified;

            }

        }
        _contexto.Entry(ordenAnterior).State = EntityState.Detached;

        foreach (var detalle in orden.DetalleOrdenDeProduccions)
        {
            producto = _contexto.Productos.Find(detalle.ProductoId);
            if (producto != null)
            {
                receta = _contexto.Recetas.Find(producto.ProductoId);
                if (receta != null)
                {
                    foreach (var recetaDetalle in receta.detalleRecetas)
                    {
                        materias = _contexto.MateriasPrimas.Find(recetaDetalle.MateriaPrimaId);
                        if (materias != null)
                        {
                            materias.Existencia -= recetaDetalle.Cantidad;
                            _contexto.Entry(materias).State = EntityState.Modified;
                        }
                    }
                }

                producto.Existencia += detalle.Cantidad;
                _contexto.Entry(producto).State = EntityState.Modified;
            }

        }
        var DetalleEliminar = _contexto.Set<DetalleOrdenDeProduccion>().Where(o => o.OrdenDeProduccionId == orden.OrdenDeProduccionId).AsNoTracking();
        _contexto.Set<DetalleOrdenDeProduccion>().RemoveRange(DetalleEliminar);
        _contexto.Set<DetalleOrdenDeProduccion>().AddRange(orden.DetalleOrdenDeProduccions);
        _contexto.Entry(orden).State = EntityState.Modified;

        result = _contexto.SaveChanges() > 0;
        _contexto.Entry(orden).State = EntityState.Detached;
        return result;

    }

    public bool Insertar(OrdenDeProducciones orden)
    {
        bool result = false;
        Productos? producto;
        Recetas? receta;
        MateriasPrimas? materias;
        foreach (var detalle in orden.DetalleOrdenDeProduccions)
        {
            producto = _contexto.Productos.Find(detalle.ProductoId);
            if (producto != null)
            {
                receta = _contexto.Recetas.Find(producto.ProductoId);
                if (receta != null)
                {
                    foreach (var recetaDetalle in receta.detalleRecetas)
                    {
                        materias = _contexto.MateriasPrimas.Find(recetaDetalle.MateriaPrimaId);
                        if (materias != null)
                        {
                            materias.Existencia -= recetaDetalle.Cantidad;
                            _contexto.Entry(materias).State = EntityState.Modified;
                        }
                    }
                }
                producto.Existencia += detalle.Cantidad;
                _contexto.Entry(producto).State = EntityState.Modified;


            }

        }
        _contexto.Set<DetalleOrdenDeProduccion>().AddRange(orden.DetalleOrdenDeProduccions);
        _contexto.OrdenDeProducciones.Add(orden);

        result = _contexto.SaveChanges() > 0;
        _contexto.Entry(orden).State = EntityState.Detached;
        return result;

    }
    public bool Guardar(OrdenDeProducciones orden)
    {
        if (Existe(orden.OrdenDeProduccionId))
        {
            return Modificar(orden);
        }
        else
            return Insertar(orden);
    }

    public OrdenDeProducciones? Buscar(int ordenId)
    {
        return _contexto.OrdenDeProducciones
            .Where(o => o.OrdenDeProduccionId == ordenId)
            .Include(o => o.DetalleOrdenDeProduccions)
            .AsNoTracking()
            .SingleOrDefault();
    }

    public bool Eliminar(int id)
    {
        bool result = false;

        try
        {

            Productos? producto;
            Recetas? receta;
            MateriasPrimas? materias;
            var ordenAnterior = Buscar(id);
            foreach (var detalle in ordenAnterior.DetalleOrdenDeProduccions)
            {
                producto = _contexto.Productos.Find(detalle.ProductoId);
                if (producto != null)
                {
                    receta = _contexto.Recetas.Find(producto.ProductoId);
                    if (receta != null)
                    {
                        foreach (var recetaDetalle in receta.detalleRecetas)
                        {
                            materias = _contexto.MateriasPrimas.Find(recetaDetalle.MateriaPrimaId);
                            if (materias != null)
                            {
                                materias.Existencia += recetaDetalle.Cantidad;
                                _contexto.Entry(materias).State = EntityState.Modified;
                            }
                        }
                    }
                    producto.Existencia -= detalle.Cantidad;
                    _contexto.Entry(producto).State = EntityState.Modified;

                }

            }
            _contexto.Database.ExecuteSqlRaw($"Delete from DetalleOrdenDeProduccion where OrdenDeProduccionId={id}");


            if (ordenAnterior != null)
            {
                _contexto.OrdenDeProducciones.Remove(ordenAnterior);
                result = _contexto.SaveChanges() > 0;
                _contexto.Entry(ordenAnterior).State = EntityState.Deleted;

            }
        }
        catch (Exception)
        {
            throw;
        }

        return result;
    }

    public List<OrdenDeProducciones> GetList(Expression<Func<OrdenDeProducciones, bool>> ctr)
    {
        List<OrdenDeProducciones> lista = new List<OrdenDeProducciones>();

        try
        {
            lista = _contexto.OrdenDeProducciones.AsNoTracking().ToList();
        }
        catch (Exception)
        {
            throw;
        }

        return lista;
    }

    public List<OrdenDeProducciones> GetListByFecha(DateTime fechaInicio, DateTime fechaFin)
    {
        List<OrdenDeProducciones> lista = new List<OrdenDeProducciones>();

        try
        {
            lista = _contexto.OrdenDeProducciones.Where(op => op.Fecha >= fechaInicio && op.Fecha <= fechaFin).ToList();
        }
        catch (Exception)
        {
            throw;
        }

        return lista;
    }

    public bool Existe(int id)
    {
        bool encontrado = false;

        try
        {
            encontrado = _contexto.OrdenDeProducciones.Any(op => op.OrdenDeProduccionId == id);
        }
        catch (Exception)
        {
            throw;
        }

        return encontrado;
    }


}