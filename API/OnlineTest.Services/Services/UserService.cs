using AutoMapper;
using OnlineTest.Model.Interfaces;
using OnlineTest.Models;
using OnlineTest.Models.Interfaces;
using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.GetDTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.Interface;

namespace OnlineTest.Services.Services
{
    public class UserService : IUserService
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IHasherService _hasherService;
        #endregion

        #region Constructors
        public UserService(IMapper mapper, IUserRepository userRepository, IHasherService hasherService, IUserRoleRepository userRoleRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;   
            _hasherService = hasherService;
        }

        #endregion

        #region Methods

        public ResponseDTO GetUsers()
        {
            var response = new ResponseDTO();
            try
            {
                var data = _mapper.Map<List<GetUserDTO>>(_userRepository.GetUsers().ToList());
                response.Status = 200;
                response.Message = "Ok";
                response.Data = data;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }
        public ResponseDTO GetUserPagination(int PageNo, int RowsPerPage)
        {

            var response = new ResponseDTO();
            try
            {
                var users = _mapper.Map<List<GetUserDTO>>(_userRepository.GetUserPagination(PageNo,RowsPerPage).ToList());
                response.Status = 200;
                response.Message = "Ok";
                response.Data = users;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }
        public ResponseDTO GetUserbyId(int id)
        {

            var response = new ResponseDTO();
            try
            {
                var user = _userRepository.GetUserbyId(id);
                if (user == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "User not found";
                    return response;
                }
                var result = _mapper.Map<GetUserDTO>(user);
              
                response.Status = 200;
                response.Message = "Ok";
                response.Data = result;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO GetUserbyEmail(string email)
        {

            var response = new ResponseDTO();
            try
            {
                var user = _userRepository.GetUserByEmail(email);
                if (user == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "User not found";
                    return response;
                }
                var result = _mapper.Map<GetUserDTO>(user);
                
                response.Status = 200;
                response.Message = "Ok";
                response.Data = result;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }
        public ResponseDTO AddUser(AddUserDTO user)
        {

            var response = new ResponseDTO();
            try
            {
                var userByEmail = _userRepository.GetUserByEmail(user.Email);
                if (userByEmail != null)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Email already exists";
                    return response;
                }
                user.Password = _hasherService.Hash(user.Password);
                user.IsActive = true;
                var userId = _userRepository.AddUser(_mapper.Map<User>(user));

                if (userId==0)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Could not add user";
                    return response;
                }
                if(user.IsAdmin)
                {
                    var roleAdmin = new UserRole
                    {
                        UserId = userId,
                        RoleId = 1
                    };
                    _userRoleRepository.AddRole(roleAdmin);
                }
                var roleUser = new UserRole
                {
                    UserId = userId,
                    RoleId = 2
                };
                _userRoleRepository.AddRole(roleUser);
                response.Status = 201;
                response.Message = "Created";
                response.Data = userId;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;

        }
        public ResponseDTO UpdateUser(UpdateUserDTO user)
        {

            var response = new ResponseDTO();
            try
            {
                var userById = _userRepository.GetUserbyId(user.Id);
                if (userById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "User not found";
                    return response;
                }
                var userByEmail = _userRepository.GetUserByEmail(user.Email);
                if (userByEmail != null && userByEmail.Id != user.Id)
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Email already exists";
                    return response;
                }
                var updateFlag = _userRepository.UpdateUser(_mapper.Map<User>(user));
            
                if (updateFlag)
                {
                    response.Status = 204;
                    response.Message = "Updated";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Could not update user";
                }
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }
        public ResponseDTO DeleteUser(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var userById = _userRepository.GetUserbyId(id);
                if (userById == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "User not found";
                    return response;
                }
                userById.IsActive = false;
                var deleteFlag = _userRepository.DeleteUser(userById);
                if (deleteFlag)
                {
                    response.Status = 204;
                    response.Message = "Deleted";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Deleted";
                    response.Error = "Could not delete user";
                }
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public GetUserDTO IsUserExists(TokenDTO user)
        {
            var result = _userRepository.GetUserByEmail(user.Username);
            if (result == null || result.Password != _hasherService.Hash(user.Password))
                return null;
            return _mapper.Map<GetUserDTO>(result);
        }
        #endregion
    }
}
