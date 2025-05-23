using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.API.Models.DocumentiCliente;
using EasyGold.API.Models.Entities;
using EasyGold.API.Services.Interfaces.Anagrafiche;
using EasyGold.API.Repositories.Interfaces.Anagrafiche;

namespace EasyGold.API.Services.Implementations.Anagrafiche
{
    public class DocumentiClienteService : IDocumentiClienteService
    {
        private readonly IDocumentiClienteRepository _repository;

        public DocumentiClienteService(IDocumentiClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DocumentoClienteDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(MapToDto);
        }

        public async Task<DocumentoClienteDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<DocumentoClienteDTO> AddAsync(DocumentoClienteDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<DocumentoClienteDTO> UpdateAsync(DocumentoClienteDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Doc_IdAuto);
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

        private DocumentoClienteDTO MapToDto(DbDocumentoCliente entity)
        {
            return new DocumentoClienteDTO
            {
                Doc_IdAuto = entity.Doc_IdAuto,
                Doc_ISONum = entity.Doc_ISONum,
                Doc_Documento = entity.Doc_Documento,
                Doc_ValidoAnni = entity.Doc_ValidoAnni,
                Doc_Annulla = entity.Doc_Annulla
            };
        }

        private DbDocumentoCliente MapToEntity(DocumentoClienteDTO dto)
        {
            return new DbDocumentoCliente
            {
                Doc_IdAuto = dto.Doc_IdAuto,
                Doc_ISONum = dto.Doc_ISONum,
                Doc_Documento = dto.Doc_Documento,
                Doc_ValidoAnni = dto.Doc_ValidoAnni,
                Doc_Annulla = dto.Doc_Annulla
            };
        }
    }
}
