using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PublicisSapient.Models;
using PublicisSapient.Models.ViewModels;
using PublicisSapient.Repositories.Interfaces;
using System.Collections.Generic;

namespace PublicisSapient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        private readonly IRepository<CreditCard> _repository;
        private readonly IMapper _mapper;

        public CreditCardsController(IRepository<CreditCard> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public Response<CreditCard> Save([FromBody] CreditCardRequestModel model)
        {
            var response = new Response<CreditCard>();
            var entity = _mapper.Map<CreditCard>(model);
            _repository.Insert(entity);
            response.StatusCode = 200;
            response.Status = true;
            response.Data = entity;
            response.Message = "Success.";

            return response;
        }

        [HttpGet("{id}")]
        public Response<List<CreditCard>> Get(int? id = null)
        {
            var response = new Response<List<CreditCard>>();
            if (!id.HasValue || id.Value == 0)
            {
                var cards = _repository.GetAll();
                response.Data = cards;
            }
            else
            {
                var card = _repository.GetById(id.Value);
                response.Data = new List<CreditCard>() { card };
            }

            response.StatusCode = 200;
            response.Status = true;
            response.Message = "Success.";

            return response;
        }
    }
}
