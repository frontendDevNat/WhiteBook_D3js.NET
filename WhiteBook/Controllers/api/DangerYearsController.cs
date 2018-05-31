using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WhiteBook.Models;

namespace WhiteBook.Controllers.api
{
    [Produces("application/json")]
    [Route("api/DangerYears")]
    public class DangerYearsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        private readonly List<DangerDataPoint> dataPoints;

        public DangerYearsController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            dataPoints = GetSOData();
        }

        // GET: api/DangerYears
        [HttpGet]
        public async Task<IActionResult> GetDangerYear()
        {            
            var dangerYear = await _context.DangerYears.Include(d => d.Danger).Include(d => d.Year)
                .OrderBy(d => d.DangerId).ThenBy(d => d.Year.Value)
                .ToListAsync();

            List<DangerDataPoint> dangerDataPointItems = new List<DangerDataPoint>();

            foreach (var item in dangerYear)
            {
                DangerDataPoint dangerDataPoint =
                    new DangerDataPoint { DangerId = item.DangerId, DangerName = item.Danger.Descr, Year = item.Year.Value, Amount = item.Amount };

                dangerDataPointItems.Add(dangerDataPoint);
            }

            return Ok(dangerDataPointItems);
            //return Ok(dangerYear);            
        }

        //// GET: api/DangerYears
        //[HttpGet]
        //public IEnumerable<DangerYear> GetDangerYears()
        //{
        //    return _context.DangerYears;
        //}


        // GET: api/DangerYears
        //[HttpGet]
        //public IEnumerable<DangerDataPoint> GetDangerYears()
        //{
        //    return dataPoints.OrderBy(m => m.DangerName).ThenBy(m => m.DangerDate).ToList();
        //}


        // GET: api/DangerYears/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDangerYear([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dangerYear = await _context.DangerYears.Where(m => m.DangerId == id).ToListAsync();

            return Ok(dangerYear);

            //var dangerYear = await _context.DangerYears.SingleOrDefaultAsync(m => m.DangerId == id);

            //if (dangerYear == null)
            //{
            //    return NotFound();
            //}

            //return Ok(dangerYear);
        }


        private List<DangerDataPoint> GetSOData()
        {
            //string webRootPath = _hostingEnvironment.WebRootPath;
            //string contentRootPath = _hostingEnvironment.ContentRootPath;
            //
            //return Content(webRootPath + "\n" + contentRootPath);

            string contentRootPath = _hostingEnvironment.ContentRootPath;

            var path = Path.Combine(contentRootPath, @"Data\DangerYears.json");
            //var json = File.ReadAllText(path);
            var json = System.IO.File.ReadAllText(path);
            var soData = JsonConvert.DeserializeObject<List<DangerDataPoint>>(json);
            return soData;
        }

    }

    public class DangerDataPoint
    {
        public int DangerId { get; set; }
        public string DangerName { get; set; }        
        public int Year { get; set; }
        public DateTime DangerDate
        {
            get
            {
                return new DateTime(Year, 1, 1);
            }
            set { }
        }

        public float Amount { get; set; }

    }

}