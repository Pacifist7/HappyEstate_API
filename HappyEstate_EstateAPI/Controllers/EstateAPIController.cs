using AutoMapper;
using HappyEstate_EstateAPI.Data;
using HappyEstate_EstateAPI.Models;
using HappyEstate_EstateAPI.Models.Dto;
using HappyEstate_EstateAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace HappyEstate_EstateAPI.Controllers
{
    [Route("api/EstateAPI")]
    [ApiController]
    public class EstateAPIController : ControllerBase
    {
        private readonly IEstateRepository _dbEstate;
        private readonly IMapper _mapper;
        public EstateAPIController(IEstateRepository dbEstate, IMapper mapper)
        {
            _dbEstate = dbEstate;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<EstateDTO>>> GetEstates() 
        {
            IEnumerable<Estate> estateList = await _dbEstate.GetAllAsnyc();
            return Ok(_mapper.Map<List<EstateDTO>>(estateList));
        }

        [HttpGet("{id:int}", Name ="GetEstate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]      
        public async Task<ActionResult<EstateDTO>> GetEstate(int id)
        {
            if (id==0)
            {
                return BadRequest();
            }

            var estate = await _dbEstate.GetAsnyc(u => u.Id == id);

            if (estate == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EstateDTO>(estate));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EstateDTO>> CreateEstate([FromBody]EstateCreateDTO createDTO) 
        {
            if (await _dbEstate.GetAsnyc(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null) 
            {
                ModelState.AddModelError("CustomError","Estate already exists");
                return BadRequest(ModelState);
            }
            if (createDTO == null)
            {
                return BadRequest(createDTO);
            }

            Estate model = _mapper.Map<Estate>(createDTO);

            await _dbEstate.CreateAsnyc(model);
            return CreatedAtRoute("GetEstate", new {id=model.Id}, model);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteEstate")]
        public async Task<IActionResult> DeleteEstate(int id) 
        {
             if (id ==0)
            {
                return BadRequest();
            }

             var estate = await _dbEstate.GetAsnyc(e => e.Id == id);

            if (estate== null)
            {
                return NotFound();
            }

            await _dbEstate.RemoveAsnyc(estate);
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "UpdateEstate")]
        public async Task<IActionResult> UpdateEstate(int id, [FromBody]EstateDTO updateDTO) 
        {
            if (updateDTO ==null || id != updateDTO.Id) 
            {
                return BadRequest();
            }

            Estate model = _mapper.Map<Estate>(updateDTO);

            await _dbEstate.UpdateAsync(model);
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPatch("{id:int}", Name ="UpdatePartialEstate")]
        public async Task<IActionResult> UpdatePartialEstate(int id, JsonPatchDocument<EstateUpdateDTO> patchDTO) 
        {
            if (patchDTO == null || id == 0) 
            {
                return BadRequest();
            }

            var estate = await _dbEstate.GetAsnyc(u=>u.Id==id, tracked:false);

            EstateUpdateDTO estateDTO = _mapper.Map<EstateUpdateDTO>(estate);

            if (estate == null) 
            {
                return BadRequest();
            }

            patchDTO.ApplyTo(estateDTO, ModelState);
            Estate model = _mapper.Map<Estate>(estateDTO);

            await _dbEstate.UpdateAsync(model);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }
    }
} 
