using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using test6.Models;
using test6.Models.DTO;
using test6.Repository.ClientRepository;
using test6.Services.IUnitOfWork;

namespace test6.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ClientController> _logger;
        private readonly IMapper _mapper;

        public ClientController(IUnitOfWork unitOfWork, ILogger<ClientController> logger, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._logger = logger;
            this._mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetClients([FromQuery] RequestParams requestParams)
        {
                        
                var clients = await this._unitOfWork.Client.GetPagedList(new List<string> { "Address" }, requestParams);
                var result = this._mapper.Map<IList<ClientInfoDTO>>(clients);
                return Ok(result);

           
        }


        //[ActionName(nameof(GetClient))]
        [HttpGet("{id}",Name =nameof(GetClient))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
       
        public async Task<IActionResult> GetClient([FromRoute] int id)
        {
            
                var client = await this._unitOfWork.Client.Get(x => x.Id == id,includes:new List<string> { "Address" });
                                            //IList<>
                var result = this._mapper.Map<ClientInfoDTO>(client);
                return Ok(result);

           
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientDTO createClientDTO)
        {

            if(!ModelState.IsValid)
            {

                _logger.LogError($"Invalid Post attemp in {nameof(CreateClient)}");
                return BadRequest(ModelState);
            }

             
            
                var client = _mapper.Map<Client>(createClientDTO);

                await _unitOfWork.Client.Insert(client);
                await _unitOfWork.Save();

                return CreatedAtRoute(nameof(GetClient), new {id=client.Id},client);

            
            //catch(Exception ex)
            //{
            //    _logger.LogError($"Something went wrong  {nameof(CreateClient)}");
            //    return StatusCode(500, "Internal Server error, Please try leater");
            //}
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateClient([FromRoute] int id , [FromBody] UpdateClientDTO updateClientDTO)
        {
            //throw new Exception();

            if(! ModelState.IsValid)
            {
                _logger.LogError($"Invalid Update Attemp in {nameof(UpdateClient)}");
                return BadRequest(ModelState);
            }

          
                var client = await _unitOfWork.Client.Get(x => x.Id == id, new List<string> { "Address" });
                if(client is null)
                {
                    _logger.LogError($"Invalid Update Attemp in {nameof(UpdateClient)}");
                    return NotFound();
                }

                _mapper.Map(updateClientDTO, client);
                //client = _mapper.Map<client>(updateClientDTO);
                _logger.LogInformation($"------> Adress = {updateClientDTO.Address.City} {client.Address.City}");
                _unitOfWork.Client.update(client);
                await _unitOfWork.Save();

                return NoContent();
                
            
        }

    }
}

