using AutoMapper;
using OnlineTest.Models;
using OnlineTest.Models.Interfaces;
using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.GetDTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.Interface;


namespace OnlineTest.Services.Services
{
    public class TechnologyService : ITechnologyService
    {
        #region Fields 
        private readonly IMapper _mapper;
        private readonly ITechnologyRepository _technologyRepository;
        #endregion
        #region Constructors
        public TechnologyService(IMapper mapper, ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
        }
        #endregion

        #region Methods

        public ResponseDTO GetTechnology()
        {
            var response = new ResponseDTO();
            try
            {
                var technology = _mapper.Map<List<GetTechnologyDTO>>(_technologyRepository.GetTechnology().ToList());
                response.Status = 200;
                response.Message = "Ok";
                response.Data = technology;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO GetTechnologybyId(int id)
        {


            var response = new ResponseDTO();
            try
            {
                var technology = _technologyRepository.GetTechnologybyId(id);
                if (technology == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Technology not found";
                    return response;
                }

                var result = _mapper.Map<GetTechnologyDTO>(technology);
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
        public ResponseDTO GetTechnologyPagination(int PageNo, int RowsPerPage)
        {

            var response = new ResponseDTO();
            try
            {

                var technology = _mapper.Map<List<GetTechnologyDTO>>(_technologyRepository.GetTechnologyPagination(PageNo, RowsPerPage));
                response.Status = 200;
                response.Message = "Ok";
                response.Data = technology;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;

        }
        public ResponseDTO GetTechnologyByName(string technologyname)
        {
            var response = new ResponseDTO();
            try
            {
                var technologyByName = _technologyRepository.GetTechnologyByName(technologyname);
                if (technologyByName == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Technology not found";
                    return response;
                }

                var result = _mapper.Map<GetTechnologyDTO>(technologyByName);
                response.Status = 200;
                response.Data = result;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = ex.Message;
            }
            return response;
        }
        public ResponseDTO AddTechnology(AddTechnologyDTO technology)
        {

            var response = new ResponseDTO();
            try
            {
                var technologyByName = _technologyRepository.GetTechnologyByName(technology.TechName);
                if (technologyByName != null)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Technology already exists";
                    return response;
                }
                technology.IsActive = true;
                technology.CreatedOn = DateTime.UtcNow;
                var technologyId = _technologyRepository.AddTechnology(_mapper.Map<Technology>(technology));
                if (technologyId == 0)
                {
                    response.Status = 400;
                    response.Message = "Not Created";
                    response.Error = "Could not add technology";
                    return response;
                }
                response.Status = 201;
                response.Message = "Created";
                response.Data = technologyId;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;

        }
        public ResponseDTO UpdateTechnology(UpdateTechnologyDTO technology)
        {

            var response = new ResponseDTO();
            try
            {
                var technologyById = _technologyRepository.GetTechnologybyId(technology.Id);
                if (technologyById == null)
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Technology does not exist";
                    return response;
                }
                var technologyByName = _technologyRepository.GetTechnologyByName(technology.TechName);
                if (technologyByName != null)
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Technology already exists";
                    return response;
                }
                technology.ModifiedOn = DateTime.UtcNow;
                var updateFlag = _technologyRepository.UpdateTechnology(_mapper.Map<Technology>(technology));
                if (updateFlag)
                {
                    response.Status = 204;
                    response.Message = "Updated";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Could not update technology";
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
        public ResponseDTO DeleteTechnology(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var technologyById = _technologyRepository.GetTechnologybyId(id);
                if (technologyById == null)
                {
                    response.Status = 400;
                    response.Message = "Not Deleted";
                    response.Error = "Technology does not exist";
                    return response;
                }
                technologyById.IsActive = false;
                var deleteFlag = _technologyRepository.DeleteTechnology(_mapper.Map<Technology>(technologyById));
                if (deleteFlag)
                {
                    response.Status = 204;
                    response.Message = "Deleted";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Deleted";
                    response.Error = "Could not delete technology";
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

        #endregion
    }

}
