using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace appEsqueci.Models
{

    [Table("Tb_Anotacoes")]
    public class ModelNotas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Titulo { get; set; }
        [NotNull]
        public string Dados { get; set; }
        [NotNull]
        public bool Favorito { get; set; }

        public ModelNotas()
        {
            this.Id = 0;
            this.Dados = "";
            this.Favorito = false;
            this.Titulo = "";
        }

    }
}
