﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWDotNetCore.PizzaApi.Db;
using MWDotNetCore.PizzaApi.Features.Queries;
using MWDotNetCore.Share;

namespace MWDotNetCore.PizzaApi.Features.Pizza
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly DapperService _dapperService;

        public PizzaController()
        {
            _appDbContext = new AppDbContext();
            _dapperService = new DapperService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
        }

        [HttpGet]
        public async Task<IActionResult> GetPizzas()
        {
            var lst = await _appDbContext.Pizzas.ToListAsync();
            return Ok(lst);
        }

        [HttpGet("pizza_extras")]
        public async Task<IActionResult> GetPizzaExtras()
        {
            var lst = await _appDbContext.PizzaExtra.ToListAsync();
            return Ok(lst);
        }

        //[HttpGet("Orders/{invoiceNo}")]
        //public async Task<IActionResult> GetOrder(string invoiceNo)
        //{
        //    var item = await _appDbContext.PizzaOrder.FirstOrDefaultAsync(x=> x.PizzaOrderInvoiceNo == invoiceNo);
        //    var lst = await _appDbContext.PizzaOrderDetail.Where(x => x.PizzaOrderInvoiceNo == invoiceNo).ToListAsync();

        //    return Ok(new
        //    {
        //        Order = item,
        //        OrderDetail = lst
        //    });
        //}

        [HttpGet("Orders/{invoiceNo}")]
        public IActionResult GetOrder(string invoiceNo)
        {
            var item = _dapperService.QueryFirstOrDefault<PizzaOrderInvoiceHeadModel>
                        (
                            PizzaQuery.PizzaOrderQuery, 
                            new { PizzaOrderInvoiceNo = invoiceNo}
                        );

            var lst = _dapperService.Query<PizzaOrderDetailInvoiceModel>
                        (
                            PizzaQuery.PizzaOrderDetailQuery,
                            new { PizzaOrderInvoiceNo = invoiceNo }
                        );

            var model = new PizzaOrderInvoiceResponse()
            {
                Order = item,
                OrderDetails = lst
            };
            return Ok(model);

        }

        [HttpPost("Order")]
        public async Task<IActionResult> OrderAsync(OrderRequest orderRequest)
        {
            var itemPizza = await _appDbContext.Pizzas.FirstOrDefaultAsync(x => x.Id == orderRequest.PizzaId);
            var total = itemPizza.Price;

            if(orderRequest.Extras.Length > 0)
            {
                var lstExtra = await _appDbContext.PizzaExtra.Where(x=> orderRequest.Extras.Contains(x.Id)).ToListAsync();
                total += lstExtra.Sum(x => x.Price);
            }

            var invoiceNo = DateTime.Now.ToString("yyyyMMddmmHHss");
            PizzaOrderModel pizzaOrderModel = new PizzaOrderModel()
            {
                PizzaId = orderRequest.PizzaId,
                PizzaOrderInvoiceNo = invoiceNo,
                TotalAmount = total
            };

            List<PizzaOrderDetailModel> pizzaOrderDetailModels = orderRequest.Extras.Select(ExtraId => new PizzaOrderDetailModel
            {
                PizzaExtraId = ExtraId,
                PizzaOrderInvoiceNo = invoiceNo
            }).ToList();

            await _appDbContext.PizzaOrder.AddAsync(pizzaOrderModel);
            await _appDbContext.PizzaOrderDetail.AddRangeAsync(pizzaOrderDetailModels);
            await _appDbContext.SaveChangesAsync();

            OrderResponse response = new OrderResponse()
            {
                InvoiceNo = invoiceNo,
                Message = "Thank you for your order. Enjoy your pizza.",
                TotalAmount = total
            };
            return Ok(response);
        }
    }
}
