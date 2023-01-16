using HappyEstate_EstateAPI.Data;
using HappyEstate_EstateAPI.Models;
using HappyEstate_EstateAPI.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HappyEstate_EstateAPI.Controllers
{
    [Route("api/EstateAPI")]
    [ApiController]
    public class EstateAPIController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<EstateDTO>> GetEstates() 
        {
            return Ok(EstateStore.estateList);
        }

        [HttpGet("{id:int}", Name ="GetEstate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(200 , Type=typeof(EstateDTO))]  ---> Another way
      

        public ActionResult<EstateDTO> GetEstate(int id)
        {
            if (id==0)
            {
                return BadRequest();
            }

            var estate = EstateStore.estateList.FirstOrDefault(u => u.Id == id);

            if (estate == null)
            {
                return NotFound();
            }

            return Ok(estate);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<EstateDTO> CreateEstate([FromBody]EstateDTO estateDTO) 
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if (EstateStore.estateList.FirstOrDefault(u => u.Name.ToLower() == estateDTO.Name.ToLower()) != null) 
            {
                ModelState.AddModelError("CustomError","Estate already exists");
                return BadRequest(ModelState);
            }
            if (estateDTO == null)
            {
                return BadRequest(estateDTO);
            }
            if (estateDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            estateDTO.Id = EstateStore.estateList.OrderByDescending(u=>u.Id).FirstOrDefault().Id +1;
            EstateStore.estateList.Add(estateDTO);

            return CreatedAtRoute("GetEstate", new {id=estateDTO.Id}, estateDTO);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteEstate")]
        public IActionResult DeleteEstate(int id) 
        {
             if (id ==0)
            {
                return BadRequest();
            }
             var estate = EstateStore.estateList.FirstOrDefault(e => e.Id == id);
            if (estate== null)
            {
                return NotFound();
            }
            EstateStore.estateList.Remove(estate);
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "UpdateEstate")]
        public IActionResult UpdateEstate(int id, [FromBody]EstateDTO estateDTO) 
        {
            if (estateDTO ==null || id != estateDTO.Id) 
            {
                return BadRequest();
            }
            var estate = EstateStore.estateList.FirstOrDefault(u=>u.Id==id);
            estate.Name= estateDTO.Name;
            estate.Sqft=estateDTO.Sqft;
            estate.Occupancy=estateDTO.Occupancy;

            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPatch("{id:int}", Name ="UpdatePartialEstate")]
        public IActionResult UpdatePartialEstate(int id, JsonPatchDocument<EstateDTO> patchDTO) 
        {
            if (patchDTO == null || id == 0) 
            {
                return BadRequest();
            }
            var estate = EstateStore.estateList.FirstOrDefault(u=>u.Id==id);
            if (estate == null) 
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(estate, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
} 
