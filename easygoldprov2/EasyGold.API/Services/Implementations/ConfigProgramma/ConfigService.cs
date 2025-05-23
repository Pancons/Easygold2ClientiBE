using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using EasyGold.API.Models;
using EasyGold.API.Models.DTO.Config;
using EasyGold.API.Models.Entities.Config;
using EasyGold.API.Repositories.Interfaces.ConfigProgramma;
using EasyGold.API.Services.Interfaces.ConfigProgramma;

namespace EasyGold.API.Services.Implementations.ConfigProgramma
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigRepository _repository;

        public ConfigService(IConfigRepository repository)
        {
            _repository = repository;
        }

        public async Task<JsonDocument> GetParametriConfigurazione(int idNazione)
        {
            var entities = (await _repository.GetAllAsync()).AsQueryable();

            var configDictionary = entities.Where(e => e.Sys_IDNazione == null || e.Sys_IDNazione == idNazione)
                .GroupBy(e => e.Sys_Sezione)
                .ToDictionary(
                    g => g.Key,
                    g => g.ToDictionary(
                        e => e.Sys_NomeCampo,
                        e => TryParseValue(e.Sys_Valore, e.Sys_TipoCampo)
                    )
                );

            JsonDocument json = JsonSerializer.SerializeToDocument(configDictionary, JsonSerializerOptions.Web);

            return json;
        }

        public async Task<BaseListResponse<ConfigDTO>> GetAllAsync(BaseListRequest request)
        {
            var entities = (await _repository.GetAllAsync()).AsQueryable();

            // Ordinamento
            if (request.Sort != null && request.Sort.Any())
            {
                foreach (var sort in request.Sort)
                {
                    if (sort.Field == nameof(ConfigDTO.Sys_NomeCampo))
                    {
                        entities = sort.Order.ToLower() == "desc"
                            ? entities.OrderByDescending(e => e.Sys_NomeCampo)
                            : entities.OrderBy(e => e.Sys_NomeCampo);
                    }
                    // Aggiungi altri campi se necessario
                }
            }

            var total = entities.Count();

            // Paginazione
            var paged = entities.Skip(request.Offset).Take(request.Limit).ToList();

            var dtos = paged.Select(ToDTO).ToList();

            return new BaseListResponse<ConfigDTO>(dtos, total);
        }

        public async Task<ConfigDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : ToDTO(entity);
        }

        public async Task<ConfigDTO> AddAsync(ConfigDTO dto)
        {
            var entity = ToEntity(dto);
            await _repository.AddAsync(entity);
            return ToDTO(entity);
        }

        public async Task<ConfigDTO> UpdateAsync(ConfigDTO dto)
        {
            var entity = ToEntity(dto);
            await _repository.UpdateAsync(entity);
            return ToDTO(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        // Conversioni esplicite
        private static ConfigDTO ToDTO(DbConfig e) => new ConfigDTO
        {
            Sys_IDAuto = e.Sys_IDAuto,
            Sys_Sezione = e.Sys_Sezione,
            Sys_IDNazione = e.Sys_IDNazione,
            Sys_NomeCampo = e.Sys_NomeCampo,
            Sys_TipoCampo = e.Sys_TipoCampo,
            Sys_Valore = e.Sys_Valore,
            Sys_Lunghezza = e.Sys_Lunghezza
        };

        private static DbConfig ToEntity(ConfigDTO dto) => new DbConfig
        {
            Sys_IDAuto = dto.Sys_IDAuto ?? 0,
            Sys_Sezione = dto.Sys_Sezione,
            Sys_IDNazione = dto.Sys_IDNazione,
            Sys_NomeCampo = dto.Sys_NomeCampo,
            Sys_TipoCampo = dto.Sys_TipoCampo,
            Sys_Valore = dto.Sys_Valore,
            Sys_Lunghezza = dto.Sys_Lunghezza
        };

        private static object TryParseValue(string value, string sqlDataType)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            switch (sqlDataType.ToLowerInvariant())
            {
                case "int":
                case "bigint":
                case "smallint":
                case "tinyint":
                    if (int.TryParse(value, out int i)) return i;
                    break;

                case "bit":
                    if (bool.TryParse(value, out bool b)) return b;
                    if (value == "0") return false;
                    if (value == "1") return true;
                    break;

                case "money":
                case "decimal":
                case "numeric":
                case "float":
                case "real":
                    if (decimal.TryParse(value, out decimal d)) return d;
                    break;

                case "datetime":
                case "smalldatetime":
                case "date":
                case "datetime2":
                    if (DateTime.TryParse(value, out DateTime dt)) return dt;
                    break;

                case "varchar":
                case "nvarchar":
                case "char":
                case "nchar":
                case "text":
                case "ntext":
                    return value;

                default:
                    return value;
            }

            // Se la conversione fallisce, torna comunque la stringa originale
            return value;
        }



    }
}