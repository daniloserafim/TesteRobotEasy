using ApiCotacao.Libraries;
using ApiCotacao.Model;
using ApiCotacao.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiCotacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotacaoController : ControllerBase
    {
        private readonly ICotacaoRepository _repository;
        public CotacaoController(ICotacaoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Cotacao>> GetCotacoes()
        {
            return await _repository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cotacao>> GetCotacao(int id)
        {
            return await _repository.Get(id);
        }

        [HttpGet("{moedaBase}, {moedaAlvo}")]
        public async Task<ActionResult<Cotacao>> GetCotacao(string moedaBase, string moedaAlvo)
        {
            var nelson = await _repository.Get(moedaBase, moedaAlvo);

            if (nelson == null) {
                string valorCotacao = CotacaoUseCases.GetCotacaoSelenium(moedaBase, moedaAlvo);
                Cotacao cotacao = CotacaoUseCases.BuildCotacao(moedaBase, moedaAlvo, valorCotacao);
                return await PostNelson(cotacao);
            }

            return nelson;
        }

        [HttpPost]
        public async Task<ActionResult<Cotacao>> PostNelson(Cotacao cotacao)
        {
            var newCotacao = await _repository.Create(cotacao);
            return CreatedAtAction(nameof(GetCotacao), new { id = newCotacao.Id }, newCotacao);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var cotacaoToDelete = await _repository.Get(id);

            if (cotacaoToDelete == null)
            {
                return NotFound();
            }

            await _repository.Delete(cotacaoToDelete.Id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> PutCotacoes(int id, [FromBody] Cotacao cotacao)
        {
            if (id == cotacao.Id)
            {
                return BadRequest();
            }

            await _repository.Update(cotacao);
            return NoContent();
        }
    }
}
