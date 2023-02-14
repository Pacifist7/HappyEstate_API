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
    [Route("api/EstateNumberAPI")]
    [ApiController]
    public class EstateNumberAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IEstateNumberRepository _dbEstateNumber;
        private readonly IEstateRepository _dbEstate;
        private readonly IMapper _mapper;
        public EstateNumberAPIController(IEstateNumberRepository dbEstateNumber, IMapper mapper, IEstateRepository dbEstate)
        {
            _dbEstateNumber = dbEstateNumber;
            _mapper = mapper;
            this._response = new();
            _dbEstate = dbEstate;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetEstateNumbers()
        {
            try
            {
                IEnumerable<EstateNumber> estateNumberList = await _dbEstateNumber.GetAllAsnyc(includePreperties:"Estate");
                _response.Result = _mapper.Map<List<EstateNumberDTO>>(estateNumberList);
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

        [HttpGet("{id:int}", Name = "GetEstateNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetEstateNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var estateNumber = await _dbEstateNumber.GetAsnyc(u => u.EstateNo == id);

                if (estateNumber == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<EstateNumberDTO>(estateNumber);
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
        public async Task<ActionResult<APIResponse>> CreateEstateNumber([FromBody] EstateNumberCreateDTO createDTO)
        {
            try
            {

                if (await _dbEstateNumber.GetAsnyc(u => u.EstateNo == createDTO.EstateNo) != null)
                {
                    ModelState.AddModelError("ErrorMessages", "Estate Number already exists");
                    return BadRequest(ModelState);
                }

                if(await _dbEstate.GetAsnyc(u=>u.Id== createDTO.EstateID) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Villa ID is Invalid!");
                    return BadRequest(ModelState);
                }

                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                EstateNumber estateNumber = _mapper.Map<EstateNumber>(createDTO);

                await _dbEstateNumber.CreateAsnyc(estateNumber);
                _response.Result = _mapper.Map<EstateNumberDTO>(estateNumber);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetEstate", new { id = estateNumber.EstateNo }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteEstateNumber")]
        public async Task<ActionResult<APIResponse>> DeleteEstateNumber(int id)
        {
            try
            {


                if (id == 0)
                {
                    return BadRequest();
                }

                var estateNumber = await _dbEstateNumber.GetAsnyc(e => e.EstateNo == id);

                if (estateNumber == null)
                {
                    return NotFound();
                }

                await _dbEstateNumber.RemoveAsnyc(estateNumber);
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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "UpdateEstateNumber")]
        public async Task<ActionResult<APIResponse>> UpdateEstateNumber(int id, [FromBody] EstateNumberUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.EstateNo)
                {
                    return BadRequest();
                }

                if (await _dbEstate.GetAsnyc(u => u.Id == updateDTO.EstateID) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Villa ID is Invalid!");
                    return BadRequest(ModelState);
                }

                EstateNumber model = _mapper.Map<EstateNumber>(updateDTO);

                await _dbEstateNumber.UpdateAsync(model);
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
    }
}
