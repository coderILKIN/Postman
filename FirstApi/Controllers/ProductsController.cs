using FirstApi.DAL;
using FirstApi.DTOs;
using FirstApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            return Ok(product);
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            List<Product> products = await _context.Products.Where(p => p.DisplayStatis == true).ToListAsync();
            ProductGetAllDto model = new();

            model.Products = products.Select(p=>new ProductListItemDto()
            {
                Id = p.Id,
                Name = p.Name,
                SoldPrice = p.SoldPrice
            }).ToList();
            
            //foreach (var item in products)
            //{
            //    ProductListItemDto itemDto = new()
            //    {
            //        Id = item.Id,
            //        Name = item.Name,
            //        SoldPrice = item.SoldPrice
            //    };

            //    model.Products.Add(itemDto);
            //}
            model.TotalCount = products.Count();
            return Ok(model);
        }
        [HttpPost("create")]
        public IActionResult Create(ProductPostDto productDto)
        {
            Product product = new()
            {
                Name = productDto.Name,
                SoldPrice = productDto.SoldPrice,
                CostPrice = productDto.CostPrice
            };
            _context.Products.Add(product);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, ProductPostDto product)
        {
            Product existed = _context.Products.Find(id);
            if (existed == null) return NotFound();
            _context.Entry(existed).CurrentValues.SetValues(product);
            _context.SaveChanges();
            return Ok(existed);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            Product existed = _context.Products.Find(id);
            if (existed == null) return NotFound();
            _context.Remove(existed);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, new { id });
        }
        [HttpPatch("status/{id}")]
        public IActionResult ChangeDisplayStatus(int id, string statusStr)
        {
            Product product = _context.Products.Find(id);
            if (product == null) return NotFound();
            bool status;
            bool result = bool.TryParse(statusStr, out status);
            if (!result) return BadRequest();
            product.DisplayStatis = status;
            _context.SaveChanges();
            return Ok();

        }
        //[HttpGet("change")]
        //public IActionResult Chang()
        //{
        //    List<Product> products = _context.Products.ToList();
        //    products.ForEach(p => p.DisplayStatis = true);
        //    _context.SaveChanges();
        //    return Ok();
        //}
    }
}
