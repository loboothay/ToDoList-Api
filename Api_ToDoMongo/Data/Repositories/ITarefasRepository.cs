using Api_ToDoMongo.Models;
using System.Collections.Generic;

namespace Api_ToDoMongo.Data.Repositories
{
    public interface ITarefasRepository
    {
        void Adicionar(TarefaModel tarefa);
        void Atualizar(string id, TarefaModel tarefa);

        IEnumerable<TarefaModel> Buscar();
        TarefaModel BuscarPorId(string id);

        void Excluir(string id);
    }
}