using CRUDStreaming.Opcoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDStreaming.Class
{
    class Streaming : EntidadeBase
    {
        // Propriedade da Class Streaming /////////////
        private string Titulo { get; set; }
        private int Ano { get; set; }
        private Genero Genero { get; set; }
        private string Descricao { get; set; }
        private bool Excluido { get; set; }

        // Construtor da class Streaming ////// 
        public Streaming(int idMovie, string titulo, int ano, Genero genero, string descricao)
        {
            this.IdMovie = idMovie;
            this.Titulo = titulo;
            this.Ano = ano;
            this.Genero = genero;
            this.Descricao = descricao;
            this.Excluido = false; 
        }

        // Este esta fazendo a conversão do objeto em string para que seja possivel exibir na tela./////
        public override string ToString()
        {
            var retorno = "";
            retorno += "Genero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            return retorno;
        }

        // Esses dois metodos, irão ser encapsulados para que seja possivel retornar o titulo e a Id, pois eles estão como privados ///
        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.IdMovie;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public bool Excluir()
        {
            return this.Excluido = true;
        }
    }
}
