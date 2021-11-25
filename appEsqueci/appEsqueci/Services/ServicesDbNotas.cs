using System;
using System.Collections.Generic;
using System.Text;
using appEsqueci.Models;
using SQLite;

namespace appEsqueci.Services
{
    public class ServicesDbNotas
    {
        SQLiteConnection conn;
        public string StatuMessage { get; set; }

        public ServicesDbNotas(string dbPath)
        {
            if (dbPath == "")
            {
                dbPath = App.DbPath;
            }
            conn = new SQLiteConnection(dbPath); // Define o Banco
            conn.CreateTable<ModelNotas>();  //Cria a tabela Notas
        }

        public void Inserir(ModelNotas nota)
        {
            try
            {

                if (string.IsNullOrEmpty(nota.Titulo))
                {
                    throw new Exception("Titulo da nota não informado");
                }

                if (string.IsNullOrEmpty(nota.Dados))
                {
                    throw new Exception("Dados da nota não informados");
                }

                int result = conn.Insert(nota);

                StatuMessage = result > 0
                    ? string.Format("{0} registro(s) adicionado(s): [Nota: {1}]", result, nota.Titulo)
                    : string.Format("0 registros adicionados");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public List<ModelNotas>ListarNotas()
        {
            List<ModelNotas> lista = new List<ModelNotas>();
            try
            {
                lista = conn.Table<ModelNotas>().ToList();
                StatuMessage = "Listagem das Notas";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lista;
        }

        public void Alterar(ModelNotas notas)
        {
            try
            {
                int result = conn.Update(notas);
                StatuMessage = string.Format("Registros alterados: {0}", result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public void Excluir(int id)
        {
            try
            {
                // _ = conn.Delete(notas);
                int result = conn.Table<ModelNotas>().Delete(r => r.Id == id);
                StatuMessage = string.Format("Registros deletados: {0}", result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<ModelNotas> Localizar(string paramTitulo, bool paramFavorito)
        {
            List<ModelNotas> lista = new List<ModelNotas>();
            try
            {
                var resp = from p in conn.Table<ModelNotas>()
                           where p.Favorito == paramFavorito && p.Titulo.ToLower().Contains(paramTitulo.ToLower())
                           select p;

                lista = resp.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lista;
        }

        public ModelNotas GetNota(int id)
        {
            try
            {
                ModelNotas objNotas = new ModelNotas();
                objNotas = conn.Table<ModelNotas>().First(p => p.Id == id);
                StatuMessage = "Encontrou a nota.";
                return objNotas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
