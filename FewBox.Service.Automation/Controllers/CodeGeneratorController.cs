using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FewBox.Automation.Web.Swagger;
using FewBox.Service.Automation.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FewBox.Service.Automation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeGeneratorController : ControllerBase
    {
        [HttpPost("dotnet/fromurl")]
        public async Task<IActionResult> Post(DotNetCoreClientUrlRequestDto dotNetCoreClientRequestDto)
        {
            string code = await DotNetClientUtility.GenerateFromUrl(dotNetCoreClientRequestDto.SwaggerUrl, dotNetCoreClientRequestDto.NamespaceName, dotNetCoreClientRequestDto.ClassName);
            return File(Encoding.UTF8.GetBytes(code), "text/plain; charset=utf-8;", $"{dotNetCoreClientRequestDto.ClassName}.cs");
        }

        [HttpPost("dotnet/fromjson")]
        public async Task<IActionResult> Post(DotNetCoreClientJsonRequestDto dotNetCoreClientRequestDto)
        {
            string code = await DotNetClientUtility.GenerateFromJson(dotNetCoreClientRequestDto.SwaggerJson, dotNetCoreClientRequestDto.NamespaceName, dotNetCoreClientRequestDto.ClassName);
            return File(Encoding.UTF8.GetBytes(code), "text/plain; charset=utf-8;", $"{dotNetCoreClientRequestDto.ClassName}.cs");
        }
    }
}