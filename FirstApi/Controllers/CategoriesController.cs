using FirstApi.DAL;
using FirstApi.DTOs.CategoryDtos;
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
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            Category category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound();
            return Ok(category);

        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            List<Category> categories = await _context.Categories.ToListAsync();

            return Ok(categories);
        }
        [HttpPost("create")]
        public IActionResult Create(CategoryPostDto categoryDto)
        {
            Category category = new()
            {
                Name = categoryDto.Name
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok(category);

        }
        [HttpPut("update/{id}")]
        public IActionResult Update(int id,CategoryPostDto category)
        {
            Category existed = _context.Categories.Find(id);
            if (existed == null) return NotFound();
            _context.Entry(existed).CurrentValues.SetValues(category);
            _context.SaveChanges();
            return Ok(category);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            Category existed = _context.Categories.Find(id);
            if (existed == null) return NotFound();
            _context.Categories.Remove(existed);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, new { id });
        }

    }
}
