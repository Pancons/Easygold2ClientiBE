using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.API.Services.Interfaces;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;


namespace EasyGold.API.Services.Implementations
{
    public class DocumentiFunzioneService : IDocumentiFunzioneService
    {
        private readonly IDocumentiFunzioneRepository _repository;

        public DocumentiFunzioneService(IDocumentiFunzioneRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<DocumentiFunzioneDTO>> GetAllAsync(DocumentiFunzioneListRequest request)
        {
            var (entities, total) = await _repository.GetAllAsync(request);
            var dtos = entities.Select(MapToDto).ToList();
            return new BaseListResponse<DocumentiFunzioneDTO>(dtos, total);
        }

        public async Task<DocumentiFunzioneDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<DocumentiFunzioneDTO> AddAsync(DocumentiFunzioneDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<DocumentiFunzioneDTO> UpdateAsync(DocumentiFunzioneDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Dof_IDAuto);
            if (entity == null) return null;

            entity.Dof_Funzione = dto.Dof_Funzione;
            entity.Dof_ISONum = dto.Dof_ISONum;
            entity.Dof_Documento = dto.Dof_Documento;
            entity.Dof_TipoDoc = dto.Dof_TipoDoc;
            entity.Dof_Sequenza = dto.Dof_Sequenza;
            entity.Dof_Annulla = dto.Dof_Annulla;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private DocumentiFunzioneDTO MapToDto(DbDocumentiFunzione entity)
        {
            return new DocumentiFunzioneDTO
            {
                Dof_IDAuto = entity.Dof_IDAuto,
                Dof_Funzione = entity.Dof_Funzione,
                Dof_ISONum = entity.Dof_ISONum,
                Dof_Documento = entity.Dof_Documento,
                Dof_TipoDoc = entity.Dof_TipoDoc,
                Dof_Sequenza = entity.Dof_Sequenza,
                Dof_Annulla = entity.Dof_Annulla
            };
        }

        private DbDocumentiFunzione MapToEntity(DocumentiFunzioneDTO dto)
        {
            return new DbDocumentiFunzione
            {
                Dof_IDAuto = dto.Dof_IDAuto,
                Dof_Funzione = dto.Dof_Funzione,
                Dof_ISONum = dto.Dof_ISONum,
                Dof_Documento = dto.Dof_Documento,
                Dof_TipoDoc = dto.Dof_TipoDoc,
                Dof_Sequenza = dto.Dof_Sequenza,
                Dof_Annulla = dto.Dof_Annulla
            };
        }
    }
}