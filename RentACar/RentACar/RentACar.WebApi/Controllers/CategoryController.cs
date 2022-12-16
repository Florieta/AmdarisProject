using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Categories.Commands.Create;
using RentACar.Application.Categories.Commands.Delete;
using RentACar.Application.Categories.Commands.Update;
using RentACar.Application.Categories.Queries;
using RentACar.Application.Orders.Queries;
using RentACar.Domain.Entitites;
using RentACar.WebApi.ViewModels.Category;

namespace RentACar.WebApi.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        public CategoryController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            GetAllCategories query = new GetAllCategories();
            List<Category> result = await _mediator.Send(query);
            List<GetCategoryViewModel> mappedResult = _mapper.Map<List<GetCategoryViewModel>>(result);
            return Ok(mappedResult);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            GetCategoryById query = new GetCategoryById()
            {
                Id = Id
            };

            Category category = await _mediator.Send(query);

            if (category == null)
            {
                return NotFound();
            }

            GetCategoryViewModel getCategoryDto = _mapper.Map<GetCategoryViewModel>(category);
            return Ok(getCategoryDto);
        }

        [HttpPost]

        public async Task<IActionResult> Add([FromBody] AddCategoryModel addCategoryDto)
        {
            CreateCategory command = _mapper.Map<CreateCategory>(addCategoryDto);
            Category category = await _mediator.Send(command);
            GetCategoryViewModel getCategoryDto = _mapper.Map<GetCategoryViewModel>(category);
            return CreatedAtAction(nameof(GetById), new { Id = category.Id }, getCategoryDto);
        }

        [HttpPut("{Id}")]

        public async Task<IActionResult> Edit([FromBody] EditCategoryViewModel editCategoryDto, int Id)
        {
            UpdateLocation command = _mapper.Map<UpdateLocation>(editCategoryDto);

            command.Id = Id;

            Category category = await _mediator.Send(command);

            if (category == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            DeleteLocation command = new DeleteLocation()
            {
                Id = Id
            };

            try
            {
                Category category = await _mediator.Send(command);

                if (category == null)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
