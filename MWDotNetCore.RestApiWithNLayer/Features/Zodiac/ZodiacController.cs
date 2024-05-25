﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using static MWDotNetCore.RestApiWithNLayer.Features.LatHtaukBayDin.LatHtaukBayDinController;

namespace MWDotNetCore.RestApiWithNLayer.Features.Zodiac
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZodiacController : ControllerBase
    {
        private async Task<Zodiac> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("Zodiac.json");
            var model = JsonConvert.DeserializeObject<Zodiac>(jsonStr);
            return model;
        }

        [HttpGet]
        public async Task<IActionResult> Zodiacsigndetail()
        {
            var model = await GetDataAsync();
            return Ok(model.ZodiacSignsDetail);
        }

        [HttpGet("{date}")]
        public async Task<IActionResult> Zodiacsigndetail(string date)
        {
            var model = await GetDataAsync();
            var zodiacSignDetail = model.ZodiacSignsDetail.FirstOrDefault(x => x.Dates == date);
            if (zodiacSignDetail == null)
            {
                return NotFound("Zodiac sign detail not found for the provided date.");
            }

            return Ok(zodiacSignDetail);
        }


        public class Zodiac
        {
            public Zodiacsignsdetail[] ZodiacSignsDetail { get; set; }
        }

        public class Zodiacsignsdetail
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string MyanmarMonth { get; set; }
            public string ZodiacSignImageUrl { get; set; }
            public string ZodiacSign2ImageUrl { get; set; }
            public string Dates { get; set; }
            public string Element { get; set; }
            public string ElementImageUrl { get; set; }
            public string LifePurpose { get; set; }
            public string Loyal { get; set; }
            public string RepresentativeFlower { get; set; }
            public string Angry { get; set; }
            public string Character { get; set; }
            public string PrettyFeatures { get; set; }
            public Trait[] Traits { get; set; }
        }

        public class Trait
        {
            public string Name { get; set; }
            public int Percentage { get; set; }
        }

    }
}