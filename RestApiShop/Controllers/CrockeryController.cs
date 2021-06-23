using System;
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
        //private readonly DataService _dataService;
        private readonly DataContext _context;

        public CrockeryController(/*DataService dataService,*/ DataContext context)
        {
            //_dataService = dataService;
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public List<Crockery> GetAll()
        {
            //return _dataService.CrockeryPieces;
            return _context.CrockeryItems.ToList();
        }

        [HttpGet("{id}")]
        public Crockery GetById(int id)
        {
            //var crockeryPiece = _dataService.CrockeryPieces.FirstOrDefault(c => c.Id == id);

            var crockeryPiece = _context.CrockeryItems.FirstOrDefault(c => c.Id == id);

            if (crockeryPiece == null)
            {
                throw new KeyNotFoundException();
            }

            return crockeryPiece;
        }

        [HttpPost]
        public void Create(Crockery crockeryPiece)
        {
            //_dataService.CrockeryPieces.Add(crockeryPiece);
            _context.Add(crockeryPiece);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Update(Crockery crockeryPiece)
        {
            //var crockeryPieceToUpdate = _dataService.CrockeryPieces.FirstOrDefault(c => c.Id == crockeryPiece.Id);
            //if(crockeryPieceToUpdate == null)
            //{
            //    throw new KeyNotFoundException();
            //}

            //_dataService.CrockeryPieces[crockeryPiece.Id] = crockeryPiece;
            
            _context.CrockeryItems.Update(crockeryPiece);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //var crockeryPiece = _dataService.CrockeryPieces.FirstOrDefault(c => c.Id == id);

            var crockeryPiece = _context.CrockeryItems.FirstOrDefault(c => c.Id == id);

            if (crockeryPiece == null)
            {
                throw new KeyNotFoundException();
            }
            else
            {
                _context.CrockeryItems.Remove(crockeryPiece);
                _context.SaveChanges();
            }
            
            //_dataService.CrockeryPieces.Remove(crockeryPiece);
        }
    }

}
