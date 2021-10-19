using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.NotesApp.Services.Interface;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.NotesApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalController : ControllerBase
    {
        private readonly INoteService _noteService;

        public ExternalController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet("performance/getnote")]
        public ActionResult<long> GetNotePerformance()
        {
            var stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < 100; i++)
            {
                _noteService.GetUserNotes(1);
            }
            stopwatch.Stop();
            long timeElapsed = stopwatch.ElapsedMilliseconds;

            if(timeElapsed > 100)
            {
                Log.Information($"This endpoint resulted in {timeElapsed}ms");
            }

            return timeElapsed;
        }
    }
}
