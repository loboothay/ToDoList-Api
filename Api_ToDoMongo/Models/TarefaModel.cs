using System;

namespace Api_ToDoMongo.Models
{
    public class TarefaModel
    {
        public TarefaModel(string nome, string descricao)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            Descricao = descricao;
            Status = false;
            DataCadastro = DateTime.UtcNow;
            DataConclusao = null;
        }

        public string Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Status { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataConclusao { get; private set; }
    }
}