
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.API.Repositories.Interfaces.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Services.Implementations.ACL
{
    public class SessioniEasyGoldService : ISessioniEasyGoldService
    {
        private readonly ISessioniEasyGoldRepository _repository;

        public SessioniEasyGoldService(ISessioniEasyGoldRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<SessioniEasyGoldDTO>> GetAllAsync(SessioniEasyGoldListRequest request)
        {
            var (sessions, total) = await _repository.GetAllAsync(request);
            var list = sessions.Select(MapToDto).ToList();
            return new BaseListResponse<SessioniEasyGoldDTO>(list, total);
        }
// DA QUI 
        public async Task<SessioniEasyGoldDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<SessioniEasyGoldDTO> AddAsync(SessioniEasyGoldDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<SessioniEasyGoldDTO> UpdateAsync(SessioniEasyGoldDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Sse_IDAuto);
            if (entity == null) return null;
     
            entity.Sse_IDCliente = dto.Sse_IDCliente;
            entity.Sse_IDUtente = dto.Sse_IDUtente;
            entity.Sse_DataLogin = dto.Sse_DataLogin;
            entity.Sse_SesScaduta = dto.Sse_SesScaduta;
            entity.Sse_DataLogout = dto.Sse_DataLogout;
            entity.Sse_sesForzata = dto.Sse_sesForzata;
            entity.Sse_DataLogoutForzato = dto.Sse_DataLogoutForzato;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

         public async Task EndSessionAsync(int sessionId)
        {
            var session = await _repository.GetByIdAsync(sessionId);
            if (session != null)
            {
                session.Sse_DataLogout = DateTime.UtcNow;
                session.Sse_SesScaduta = true;
                await _repository.UpdateAsync(session);
            }
        }

        public async Task EndSessionOnTokenExpiryAsync(int userId)
        {
            SessioniEasyGoldListRequest filter = new SessioniEasyGoldListRequest();

            var sessions = await _repository.GetAllAsync(filter);
            foreach (var session in sessions.items)
            {
                if (!session.Sse_SesScaduta)
                {
                    session.Sse_DataLogout = DateTime.UtcNow;
                    session.Sse_SesScaduta = true;
                    await _repository.UpdateAsync(session);
                }
            }
        }

        private SessioniEasyGoldDTO MapToDto(DbSessioniEasyGold entity)
        {
            if (entity == null) return null;
            return new SessioniEasyGoldDTO
            {
                Sse_IDAuto = entity.Sse_IDAuto,
                Sse_IDCliente = entity.Sse_IDCliente,
                Sse_IDUtente = entity.Sse_IDUtente,
                Sse_DataLogin = entity.Sse_DataLogin,
                Sse_SesScaduta = entity.Sse_SesScaduta,
                Sse_DataLogout = entity.Sse_DataLogout,
                Sse_sesForzata = entity.Sse_sesForzata,
                Sse_DataLogoutForzato = entity.Sse_DataLogoutForzato
            };
        }

        private DbSessioniEasyGold MapToEntity(SessioniEasyGoldDTO dto)
        {
            if (dto == null) return null;
            return new DbSessioniEasyGold
            {
                Sse_IDAuto = dto.Sse_IDAuto,
                Sse_IDCliente = dto.Sse_IDCliente,
                Sse_IDUtente = dto.Sse_IDUtente,
                Sse_DataLogin = dto.Sse_DataLogin,
                Sse_SesScaduta = dto.Sse_SesScaduta,
                Sse_DataLogout = dto.Sse_DataLogout,
                Sse_sesForzata = dto.Sse_sesForzata,
                Sse_DataLogoutForzato = dto.Sse_DataLogoutForzato
            };
        }
    }
}