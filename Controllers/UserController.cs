using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MyHabitsApi.Domains;
using MyHabitsApi.DTOs.RequestsDTOs;
using MyHabitsApi.DTOs.ResponsesDTOs;
using MyHabitsApi.Pagination;
using MyHabitsApi.Pagination.Parameters;
using MyHabitsApi.Repository.Interfaces;
using Newtonsoft.Json;

namespace MyHabitsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Policy = "UserOnly")]
        public async Task<ActionResult<PagedList<UserResponseDTO>>> GetAllUsersAsync([FromQuery]UserPaginationParameter pagination)
        {
            var users = await _unitOfWork.UserRepository.GetAllUsersAsync(pagination);
            var metadata = new
            {
                PageNumber = users.CurrentPage,
                PageSize = users.PageSize,
                TotalPages = users.TotalPages,
                HasNext = users.HasNext,
                HasPreview = users.HasPreview
            };
            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));
            var usersResponseDTO = _mapper.Map<IEnumerable<UserResponseDTO>>(users);
            return Ok(usersResponseDTO);
        }

        [HttpGet("{id:int:min(1)}", Name = "GetUserById")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<UserResponseDTO>> GetUserById(int id)
        {
            var user = await _unitOfWork.UserRepository.GetUserByIdAsync(id);
            if (user is null)
                return NotFound($"Usuário com o id = {id} não encontrado!");
            var userResponseDTO = _mapper.Map<UserResponseDTO>(user);
            return Ok(userResponseDTO);
        }

        [HttpPost]
        public async Task<ActionResult<UserResponseDTO>> PostUser(CreateUserRequestDTO createUserRequestDTO)
        {
            if (createUserRequestDTO is null)
                return BadRequest("Informe um usuário válido!");
            var user = _mapper.Map<User>(createUserRequestDTO);
            user = await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.CommitAsync();
            var userResponseDTO = _mapper.Map<UserResponseDTO>(user);
            return CreatedAtAction(nameof(GetUserById), new {id = userResponseDTO.Id}, userResponseDTO);
        }

        [HttpPatch("{id:int:min(1)}")]
        public async Task<ActionResult> PatchUserById(int id, JsonPatchDocument<UpdateUserRequestDTO> updateUser)
        {
            var user = await _unitOfWork.UserRepository.GetUserByIdAsync(id);
            if (user is null)
                return NotFound($"Usuário com o id = {id} não encontrado!");
            var updateDTO = _mapper.Map<UpdateUserRequestDTO>(user);
            updateUser.ApplyTo(updateDTO, ModelState);
            if (!ModelState.IsValid || !TryValidateModel(updateUser))
                return BadRequest(ModelState);
            _mapper.Map(updateDTO, user);
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.CommitAsync();
            return NoContent();
        }

        [HttpDelete("{id:int:min(1)}")]
        [Authorize(Policy = "SuperAdminOnly")]
        public async Task<ActionResult> DeleteUserById(int id)
        {
            var user = await _unitOfWork.UserRepository.GetUserByIdAsync(id);
            if (user is null)
                return NotFound($"Usuário com o id = {id} não encontrado!");
            _unitOfWork.UserRepository.Delete(user);
            await _unitOfWork.CommitAsync();
            return NoContent();
        }
    }
}
