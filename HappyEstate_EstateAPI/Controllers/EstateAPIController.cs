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
using System.Net;

namespace HappyEstate_EstateAPI.Controllers
{
    [Route("api/EstateAPI")]
    [ApiController]
    public class EstateAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IEstateRepository _dbEstate;
        private readonly IMapper _mapper;
        public EstateAPIController(IEstateRepository dbEstate, IMapper mapper)
        {
            _dbEstate = dbEstate;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetEstates()
        {
            try
            {
                IEnumerable<Estate> estateList = await _dbEstate.GetAllAsnyc();
                _response.Result = _mapper.Map<List<EstateDTO>>(estateList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id:int}", Name = "GetEstate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetEstate(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var estate = await _dbEstate.GetAsnyc(u => u.Id == id);

                if (estate == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<EstateDTO>(estate);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateEstate([FromBody] EstateCreateDTO createDTO)
        {
            try
            {

                if (await _dbEstate.GetAsnyc(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("ErrorMessages", "Estate already exists");
                    return BadRequest(ModelState);
                }
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                Estate estate = _mapper.Map<Estate>(createDTO);

                await _dbEstate.CreateAsnyc(estate);
                _response.Result = _mapper.Map<EstateDTO>(estate);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetEstate", new { id = estate.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteEstate")]
        public async Task<ActionResult<APIResponse>> DeleteEstate(int id)
        {
            try
            {


                if (id == 0)
                {
                    return BadRequest();
                }

                var estate = await _dbEstate.GetAsnyc(e => e.Id == id);

                if (estate == null)
                {
                    return NotFound();
                }

                await _dbEstate.RemoveAsnyc(estate);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "UpdateEstate")]
        public async Task<ActionResult<APIResponse>> UpdateEstate(int id, [FromBody] EstateDTO updateDTO)
        {
            try
            {


                if (updateDTO == null || id != updateDTO.Id)
                {
                    return BadRequest();
                }

                Estate model = _mapper.Map<Estate>(updateDTO);

                await _dbEstate.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[HttpPatch("{id:int}", Name ="UpdatePartialEstate")]
        //public async Task<IActionResult> UpdatePartialEstate(int id, JsonPatchDocument<EstateUpdateDTO> patchDTO) 
        //{
        //    if (patchDTO == null || id == 0) 
        //    {
        //        return BadRequest();
        //    }

        //    var estate = await _dbEstate.GetAsnyc(u=>u.Id==id, tracked:false);

        //    EstateUpdateDTO estateDTO = _mapper.Map<EstateUpdateDTO>(estate);

        //    if (estate == null) 
        //    {
        //        return BadRequest();
        //    }

        //    patchDTO.ApplyTo(estateDTO, ModelState);
        //    Estate model = _mapper.Map<Estate>(estateDTO);

        //    await _dbEstate.UpdateAsync(model);

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    return NoContent();
        //}
    }
}
