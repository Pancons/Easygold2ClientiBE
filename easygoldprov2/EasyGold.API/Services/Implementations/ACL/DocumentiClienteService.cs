using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Repositories.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.API.Services.Interfaces.ACL;

namespace EasyGold.API.Services.Implementations.ACL
{
    public class DocumentiClienteService : IDocumentiClienteService
    {
        private readonly IDocumentiClienteRepository _repository;

        public DocumentiClienteService(IDocumentiClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<DocumentiClienteDTO>> GetAllAsync(DocumentiClienteListRequest request)
        {
            var (documents, total) = await _repository.GetAllAsync(request);
            var list = documents.Select(MapToDto).ToList();
            return new BaseListResponse<DocumentiClienteDTO>(list, total);
        }

        public async Task<DocumentiClienteDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<DocumentiClienteDTO> AddAsync(DocumentiClienteDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<DocumentiClienteDTO> UpdateAsync(DocumentiClienteDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Doc_IDAuto);
            if (entity == null) return null;

            entity.Doc_ISONum = dto.Doc_ISONum;
            entity.Doc_Documento = dto.Doc_Documento;
            entity.Doc_ValidoAnni = dto.Doc_ValidoAnni;
            entity.Doc_Annulla = dto.Doc_Annulla;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private DocumentiClienteDTO MapToDto(DbDocumentiCliente entity)
        {
            return new DocumentiClienteDTO
            {
                Doc_IDAuto = entity.Doc_IDAuto,
                Doc_ISONum = entity.Doc_ISONum,
                Doc_Documento = entity.Doc_Documento,
                Doc_ValidoAnni = entity.Doc_ValidoAnni,
                Doc_Annulla = entity.Doc_Annulla
            };
        }

        private DbDocumentiCliente MapToEntity(DocumentiClienteDTO dto)
        {
            return new DbDocumentiCliente
            {
                Doc_IDAuto = dto.Doc_IDAuto,
                Doc_ISONum = dto.Doc_ISONum,
                Doc_Documento = dto.Doc_Documento,
                Doc_ValidoAnni = dto.Doc_ValidoAnni,
                Doc_Annulla = dto.Doc_Annulla
            };
        }
    }
}