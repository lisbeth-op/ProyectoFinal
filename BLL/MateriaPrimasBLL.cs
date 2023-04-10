using System.Linq;
using System.Linq.Expressions;
using DocumentFormat.OpenXml.InkML;
using Microsoft.EntityFrameworkCore;

public class MateriaPrimaBLL
{
    private readonly Contexto _Contexto;

    public MateriaPrimaBLL(Contexto Contexto)
    {
        _Contexto = Contexto;
    }



    public bool Existe(int MateriaPrimaId)
    {
        return _Contexto.MateriasPrimas.Any(p => p.MateriaPrimaId == MateriaPrimaId);
    }
    private bool Modificar(MateriasPrimas materiaPrima)
    {
        _Contexto.Entry(materiaPrima).State = EntityState.Modified;
        return _Contexto.SaveChanges() > 0;
    }
    private bool Insertar(MateriasPrimas materiaPrima)
    {
        _Contexto.MateriasPrimas.Add(materiaPrima);
        return _Contexto.SaveChanges() > 0;
    }
    public List<MateriasPrimas> GetList(Expression<Func<MateriasPrimas, bool>> ctr)
    {
        return _Contexto.MateriasPrimas.AsNoTracking().Where(ctr).ToList();
    }
    public bool Guardar(MateriasPrimas materiaPrima)
    {
        if (!Existe(materiaPrima.MateriaPrimaId))
        {
            return this.Insertar(materiaPrima);
        }
        else
        {
            return this.Modificar(materiaPrima);
        }
    }
    public MateriasPrimas? Buscar(String Nombre)
    {
        return _Contexto.MateriasPrimas.Where(p => p.Descripcion == Nombre).AsTracking().SingleOrDefault();
    }

    public bool Eliminar(MateriasPrimas materiaPrima)
    {
        _Contexto.Entry(materiaPrima).State = EntityState.Deleted;
        return _Contexto.SaveChanges() > 0;
    }

    public MateriasPrimas? Buscar(int id)
    {
        return _Contexto.MateriasPrimas.Where(p => p.MateriaPrimaId == id).AsTracking().SingleOrDefault();
    }
    
}