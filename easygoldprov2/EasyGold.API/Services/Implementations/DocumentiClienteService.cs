using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.DTO;
using EasyGold.Web2.Models.Cliente.Entities;
using EasyGold.API.Services.Interfaces;

namespace EasyGold.API.Services.Implementations
{
    public class DocumentiClienteService : IDocumentiClienteService
    {
        private readonly IDocumentiClienteRepository _repository;

        public DocumentiClienteService(IDocumentiClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<DocumentiClienteDTO>> GetAllAsync(BaseListRequest request)
        {
            var entities = (await _repository.GetAllAsync()).AsQueryable();

            // Ordinamento e paginazione
            if (request.Sort != null && request.Sort.Any())
            {
                foreach (var sort in request.Sort)
                {
                    if (sort.Field == nameof(DocumentiClienteDTO.Doc_Documento))
                    {
                        entities = sort.Order.ToLower() == "desc"
                            ? entities.OrderByDescending(e => e.Doc_Documento)
                            : entities.OrderBy(e => e.Doc_Documento);
                    }
                }
            }

            var total = entities.Count();
            var paged = entities.Skip(request.Offset).Take(request.Limit).ToList();
            var dtos = paged.Select(ToDTO).ToList();

            return new BaseListResponse<DocumentiClienteDTO>(dtos, total);
        }

        public async Task<DocumentiClienteDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : ToDTO(entity);
        }

        public async Task<DocumentiClienteDTO> AddAsync(DocumentiClienteDTO dto)
        {
            var entity = ToEntity(dto);
            await _repository.AddAsync(entity);
            return ToDTO(entity);
        }

        public async Task<DocumentiClienteDTO> UpdateAsync(DocumentiClienteDTO dto)
        {
            var entity = ToEntity(dto);
            await _repository.UpdateAsync(entity);
            return ToDTO(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        // Conversione manuale
        private static DocumentiClienteDTO ToDTO(DbDocumentiCliente e) => new DocumentiClienteDTO
        {
            Doc_IDAuto = e.Doc_IDAuto,
            Doc_ISONum = e.Doc_ISONum,
            Doc_Documento = e.Doc_Documento,
            Doc_ValidoAnni = e.Doc_ValidoAnni,
            Doc_Annulla = e.Doc_Annulla
        };

        private static DbDocumentiCliente ToEntity(DocumentiClienteDTO dto) => new DbDocumentiCliente
        {
            Doc_IDAuto = dto.Doc_IDAuto ?? 0,
            Doc_ISONum = dto.Doc_ISONum,
            Doc_Documento = dto.Doc_Documento,
            Doc_ValidoAnni = dto.Doc_ValidoAnni,
            Doc_Annulla = dto.Doc_Annulla
        };
    }
}