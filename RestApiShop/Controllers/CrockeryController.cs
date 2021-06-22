using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RestApiShop.Data;
using RestApiShop.Models;

namespace RestApiShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CrockeryController : ControllerBase
    {
        private readonly DataService _dataService;

        public CrockeryController(DataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public List<Crockery> GetAll()
        {
            return _dataService.CrockeryPieces;
        }

        [HttpGet("{id}")]
        public Crockery GetById(int id)
        {
            var crockeryPiece = _dataService.CrockeryPieces.FirstOrDefault(c => c.Id == id);

            if (crockeryPiece == null)
            {
                throw new KeyNotFoundException();
            }

            return crockeryPiece;
        }

        [HttpPost]
        public void Create(Crockery crockeryPiece)
        {
            _dataService.CrockeryPieces.Add(crockeryPiece);
        }

        [HttpPut]
        public void Update(Crockery crockeryPiece)
        {
            var crockeryPieceToUpdate = _dataService.CrockeryPieces.FirstOrDefault(c => c.Id == crockeryPiece.Id);

            if(crockeryPieceToUpdate == null)
            {
                throw new KeyNotFoundException();
            }

            _dataService.CrockeryPieces[crockeryPiece.Id] = crockeryPiece;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var crockeryPiece = _dataService.CrockeryPieces.FirstOrDefault(c => c.Id == id);

            if (crockeryPiece == null)
            {
                throw new KeyNotFoundException();
            }

            _dataService.CrockeryPieces.Remove(crockeryPiece);
        }
    }

}
