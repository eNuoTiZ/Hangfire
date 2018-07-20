using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TutoHangfire.Controllers
{
    [Produces("application/json")]
    [Route("api/BuildMinesweeper")]
    public class BuildMinesweeperController : Controller
    {
        // GET: api/BuildMinesweeper
        [HttpGet]
        public void Get()
        {
            BackgroundJob.Enqueue(() =>
                BuildMinesweeper()
            );
        }

        // GET: api/BuildMinesweeper/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/BuildMinesweeper
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/BuildMinesweeper/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public int BuildMinesweeper()
        {
            Process p = new Process();
            p.StartInfo.FileName = @"C:\Program Files\Unity\Editor\Unity.exe";
            p.StartInfo.Arguments = @"-batchmode -projectPath=D:\Prog\Unity\Minesweeper -quit -batchmode -executeMethod BuildMyGame.BuildAndroid -logFile %LOCALAPPDATA%\Unity\Editor\Minesweeper.log D:\Prog\Unity\Minesweeper\Minesweeper.apk";

            p.Start();
            p.WaitForExit();
            
            return p.ExitCode;
        }
    }
}
