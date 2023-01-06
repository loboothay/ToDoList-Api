using Api_ToDoMongo.Data.Configurations;
using Api_ToDoMongo.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Api_ToDoMongo.Data.Repositories
{    
    public class TarefasRepository : ITarefasRepository
    {
        private readonly IMongoCollection<TarefaModel> _tarefas;

        public TarefasRepository(IDatabaseConfiguration databaseConfiguration)
        {
            var client = new MongoClient(databaseConfiguration.ConnectionString);
            var database = client.GetDatabase(databaseConfiguration.DatabaseName);

            _tarefas = database.GetCollection<TarefaModel>("tarefas");
        }

        public void Adicionar(TarefaModel tarefa)
        {
            _tarefas.InsertOne(tarefa);
        }

        public void Atualizar(string id, TarefaModel tarefa)
        {
            _tarefas.ReplaceOne(x => x.Id == id, tarefa);
        }

        public IEnumerable<TarefaModel> Buscar()
        {
            return _tarefas.Find(tarefas => true).ToList();
        }

        public TarefaModel BuscarPorId(string id)
        {
            return _tarefas.Find(tarefas => tarefas.Id == id).FirstOrDefault();
        }
    }
}
