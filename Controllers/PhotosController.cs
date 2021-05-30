using System;
using System.Linq;
using meistrelis.Dtos.Picture;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace meistrelis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        [HttpPost]
        public ActionResult<PictureResponseDto> GetPrediction(PictureSendDto pdt)
        {
            var requestData = new {payload = new {image = new {imageBytes = pdt.Picture}}};
            var client = new RestClient("https://automl.googleapis.com");
            var req =
                new RestRequest(
                    "v1beta1/projects/888184073798/locations/us-central1/models/ICN6419536022165520384:predict", Method.POST);
            req.RequestFormat = DataFormat.Json;
            req.AddJsonBody(requestData);
            req.AddHeader("Authorization", Environment.GetEnvironmentVariable("PSQL_CONNECTION") ?? "");
            var response = client.Execute(req);
            Console.Write(response);
            var parsedContent = JsonConvert.DeserializeObject<PicturePayloadDto>(response.Content);
            var picResp =  new PictureResponseDto();
            picResp.Class = parsedContent.Payload.First().DisplayName;
            return picResp;
        }
        
    }
}