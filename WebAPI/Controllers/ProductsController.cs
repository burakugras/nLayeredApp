﻿using Business.Abstracts;
using Business.Dtos.Requests;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductRequest createProductRequest)
        {
            await _productService.Add(createProductRequest);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _productService.GetListAsync();
            return Ok(result);
        }
    }
}