using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Categories.Commands.Create;
using RentACar.Application.Categories.Commands.Update;
using RentACar.Application.Categories.Queries;
using RentACar.Application.Orders.Queries;
using RentACar.Domain.Entitites;
using RentACar.WebApi.ViewModels.Category;

namespace RentACar.WebApi.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : BaseController<CategoryController>
    {
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            GetAllCategories query = new GetAllCategories();
            List<Category> result = await base.Mediator.Send(query);
            List<GetCategoryDto> mappedResult = base.Mapper.Map<List<GetCategoryDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("GetById/{categoryId}")]
        public async Task<IActionResult> GetById(int categoryId)
        {
            GetCategoryById query = new GetCategoryById()
            {
                Id = categoryId
            };

            Category category = await base.Mediator.Send(query);

            if (category == null)
            {
                return NotFound();
            }

            GetCategoryDto getCategoryDto = base.Mapper.Map<GetCategoryDto>(category);
            return Ok(getCategoryDto);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] AddCategoryDto addCategoryDto)
        {
            CreateCategory command = base.Mapper.Map<CreateCategory>(addCategoryDto);
            Category category = await base.Mediator.Send(command);
            GetCategoryDto getCategoryDto = base.Mapper.Map<GetCategoryDto>(category);
            return CreatedAtAction(nameof(GetById), new { categoryId = category.Id }, getCategoryDto);
        }

        [HttpPost]
        [Route("Edir/{categoryId}")]
        public async Task<IActionResult> Edit([FromBody] EditCategoryDto editCategoryDto, int categoryId)
        {
            UpdateCategory command = base.Mapper.Map<UpdateCategory>(editCategoryDto);

            command.Id = categoryId;

            Category category = await base.Mediator.Send(command);

            if (category == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
