using Api_ToDoMongo.Data.Repositories;
using Api_ToDoMongo.Models;
using Api_ToDoMongo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Api_ToDoMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private ITarefasRepository _tarefasRepository;

        public TarefasController(ITarefasRepository tarefasRepository)
        {
            _tarefasRepository = tarefasRepository;
        }

        // GET: api/<tarefas>
        [HttpGet]
        public IActionResult Get()
        {
            var tarefas = _tarefasRepository.Buscar();
            return Ok(tarefas);
        }

        // GET api/<tarefas>/{id}
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var tarefa = _tarefasRepository.BuscarPorId(id);

            if (tarefa == null)
                return NotFound();

            return Ok(tarefa);
        }

        // POST api/<tarefas>
        [HttpPost]
        public IActionResult Post([FromBody] TarefasViewModels novaTarefa)
        {
            //Pode usar o mapper
            var tarefa = new TarefaModel(novaTarefa.Nome, novaTarefa.Descricao);

            _tarefasRepository.Adicionar(tarefa);
            return Created("", tarefa);
        }

        // PUT api/<tarefas>/{id}
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] TarefasViewModels tarefaAtualizada)
        {
            var tarefa = _tarefasRepository.BuscarPorId(id);

            if (tarefa == null)
                return NotFound();

            tarefa.AtualizaTarefas(tarefaAtualizada.Nome, tarefaAtualizada.Descricao, tarefaAtualizada.TarefaConcluida);

            _tarefasRepository.Atualizar(id, tarefa);

            return Ok(tarefa);
        }

        // DELETE api/<tarefas>/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var tarefa = _tarefasRepository.BuscarPorId(id);

            if (tarefa == null)
                return NotFound();

            _tarefasRepository.Excluir(id);

            return Ok("Tarefa excluida!!");
        }
    }
}
