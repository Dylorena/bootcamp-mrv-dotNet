using System;
using System.Collections.Generic;
using Series.interfaces;

namespace Series
{
  public class serieRepositorio : IRepositorio<Series>
  {
    private List<Series> listaSerie = new List<Series>();
    public void Atualiza(int id, Series entidade)
    {
      listaSerie[id] = entidade;
    }

    public void Excluir(int id)
    {
      listaSerie[id].Excluir();
    }

    public void Insere(Series entidade)
    {
      listaSerie.Add(entidade);
    }

    public List<Series> Lista()
    {
      List<Series> temp = new List<Series>();

      foreach (var serie in listaSerie)
      {
        if (!serie.wasExcluded())
        {
          temp.Add(serie);
        }
      }
      return temp;
    }

    public int ProximoId()
    {
      return listaSerie.Count;
    }

    public Series RetornaPorId(int id)
    {
      return listaSerie[id];
    }
  }
}