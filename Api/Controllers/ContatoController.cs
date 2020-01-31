using Api.Models;
using Domain.Contracts.Services;
using Domain.Model;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api/contatos")]
    public class ContatoController : ApiController
    {
        private IContatoService contatoService;

        public ContatoController(IContatoService service)
        {
            contatoService = service;
        }

        [HttpGet]
        [Route("")]
        public Task<HttpResponseMessage> Get()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var result = contatoService.GetByRange(0, 25);
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
        [HttpPost]
        [Route("")]
        public Task<HttpResponseMessage> Register(RegisterContatoModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                
                var contatoAdicionado = contatoService.Register(model.Nome, model.Email, model.Endereco, model.Telefone);
                response = Request.CreateResponse(HttpStatusCode.OK, contatoAdicionado);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
        [HttpDelete]
        [Route("{id}")]
        public Task<HttpResponseMessage> Delete(string id)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                contatoService.Delete(id);
                response = Request.CreateResponse(HttpStatusCode.OK, "Contato apagado com sucesso!");
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao remover contato!");
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        protected override void Dispose(bool disposing)
        {
            contatoService.Dispose();
        }
    }
    
}