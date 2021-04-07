using System;

namespace Series
{
  public class Series : EntidadeBase
  {
    private Genero Genero { get; set; }
    private string Titulo { get; set; }
    private string Descricao { get; set; }
    private int Ano { get; set; }
    private bool isExcluido { get; set; }

    public Series(int id, Genero genero, string titulo, string descricao, int ano)
    {
      this.Id = id;
      this.Genero = genero;
      this.Titulo = titulo;
      this.Descricao = descricao;
      this.Ano = ano;
      this.isExcluido = false;
    }

    public string retornaTitulo()
    {
      return this.Titulo;
    }
    public int retornaId()
    {
      return this.Id;
    }

    public void Excluir()
    {
      this.isExcluido = true;
    }

    public bool wasExcluded()
    {
      return this.isExcluido;
    }

    // Environment pula linha, pega do SO como pular linha
    public override string ToString()
    {
      string retorno = "";
      retorno += $"Gênero: {this.Genero} {Environment.NewLine}";
      retorno += $"Título: {this.Titulo} {Environment.NewLine}";
      retorno += $"Descrição: {this.Descricao} {Environment.NewLine}";
      retorno += $"Ano de início: {this.Ano} {Environment.NewLine}";
      return retorno;
    }
  }
}