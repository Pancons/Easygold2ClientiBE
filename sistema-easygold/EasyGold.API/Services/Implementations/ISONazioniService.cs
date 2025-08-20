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
using EasyGold.Web2.Models.Comune.GEO.ACL;
using EasyGold.Web2.Models.Comune.GEO.Entities.ACL;
using EasyGold.Web2.Models.Comune.GEO.Entities;

namespace EasyGold.API.Services.Implementations
{
    public class ISONazioniService : IISONazioniService
    {
        private readonly IISONazioniRepository _repository;

        public ISONazioniService(IISONazioniRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseListResponse<ISONazioniDTO>> GetAllAsync(ISONazioniListRequest request)
        {
            var (entities, total) = await _repository.GetAllAsync(request);
            var items = entities.Select(MapToDto).ToList();
            return new BaseListResponse<ISONazioniDTO>(items, total);
        }

        public async Task<ISONazioniDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<ISONazioniDTO> AddAsync(ISONazioniDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<ISONazioniDTO> UpdateAsync(ISONazioniDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Ntn_ISO1);
            if (entity == null) return null;

            entity.Ntn_Descrizione = dto.Ntn_Descrizione;
            entity.Ntn_ISO1A2 = dto.Ntn_ISO1A2;
            entity.Ntn_ISO1A3 = dto.Ntn_ISO1A3;
            entity.Ntn_PrefTelef = dto.Ntn_PrefTelef;
            entity.Ntn_Continente = dto.Ntn_Continente;
            entity.Ntn_ContinenteLegale = dto.Ntn_ContinenteLegale;
            entity.Ntn_Appartiene = dto.Ntn_Appartiene;
            entity.Ntn_Capitale = dto.Ntn_Capitale;
            entity.Ntn_CapitaleDeFacto = dto.Ntn_CapitaleDeFacto;
            entity.Ntn_CapitaleAmm = dto.Ntn_CapitaleAmm;
            entity.Ntn_CapitaleIdioma = dto.Ntn_CapitaleIdioma;
            entity.Ntn_IDValuta = dto.Ntn_IDValuta;
            entity.Ntn_LunghezzaCAP = dto.Ntn_LunghezzaCAP;
            entity.Ntn_NomePI = dto.Ntn_NomePI;
            entity.Ntn_TipoPI = dto.Ntn_TipoPI;
            entity.Ntn_LunghezzaPI = dto.Ntn_LunghezzaPI;
            entity.Ntn_NomeCF = dto.Ntn_NomeCF;
            entity.Ntn_TipoCF = dto.Ntn_TipoCF;
            entity.Ntn_LunghezzaCF = dto.Ntn_LunghezzaCF;
            entity.Ntn_DescStatoRegione = dto.Ntn_DescStatoRegione;
            entity.Ntn_StatoRegione = dto.Ntn_StatoRegione;
            entity.Ntn_LungSiglaProv = dto.Ntn_LungSiglaProv;
            entity.Ntn_ProvSiNo = dto.Ntn_ProvSiNo;
            entity.Ntn_Province = dto.Ntn_Province;
            entity.Ntn_Localita = dto.Ntn_Localita;
            entity.Ntn_Indirizzi = dto.Ntn_Indirizzi;

            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private ISONazioniDTO MapToDto(DbISONazioni entity)
        {
            return new ISONazioniDTO
            {
                Ntn_ISO1 = entity.Ntn_ISO1,
                Ntn_Descrizione = entity.Ntn_Descrizione,
                Ntn_ISO1A2 = entity.Ntn_ISO1A2,
                Ntn_ISO1A3 = entity.Ntn_ISO1A3,
                Ntn_PrefTelef = entity.Ntn_PrefTelef,
                Ntn_Continente = entity.Ntn_Continente,
                Ntn_ContinenteLegale = entity.Ntn_ContinenteLegale,
                Ntn_Appartiene = entity.Ntn_Appartiene,
                Ntn_Capitale = entity.Ntn_Capitale,
                Ntn_CapitaleDeFacto = entity.Ntn_CapitaleDeFacto,
                Ntn_CapitaleAmm = entity.Ntn_CapitaleAmm,
                Ntn_CapitaleIdioma = entity.Ntn_CapitaleIdioma,
                Ntn_IDValuta = entity.Ntn_IDValuta,
                Ntn_LunghezzaCAP = entity.Ntn_LunghezzaCAP,
                Ntn_NomePI = entity.Ntn_NomePI,
                Ntn_TipoPI = entity.Ntn_TipoPI,
                Ntn_LunghezzaPI = entity.Ntn_LunghezzaPI,
                Ntn_NomeCF = entity.Ntn_NomeCF,
                Ntn_TipoCF = entity.Ntn_TipoCF,
                Ntn_LunghezzaCF = entity.Ntn_LunghezzaCF,
                Ntn_DescStatoRegione = entity.Ntn_DescStatoRegione,
                Ntn_StatoRegione = entity.Ntn_StatoRegione,
                Ntn_LungSiglaProv = entity.Ntn_LungSiglaProv,
                Ntn_ProvSiNo = entity.Ntn_ProvSiNo,
                Ntn_Province = entity.Ntn_Province,
                Ntn_Localita = entity.Ntn_Localita,
                Ntn_Indirizzi = entity.Ntn_Indirizzi
            };
        }

        private DbISONazioni MapToEntity(ISONazioniDTO dto)
        {
            return new DbISONazioni
            {
                Ntn_ISO1 = dto.Ntn_ISO1,
                Ntn_Descrizione = dto.Ntn_Descrizione,
                Ntn_ISO1A2 = dto.Ntn_ISO1A2,
                Ntn_ISO1A3 = dto.Ntn_ISO1A3,
                Ntn_PrefTelef = dto.Ntn_PrefTelef,
                Ntn_Continente = dto.Ntn_Continente,
                Ntn_ContinenteLegale = dto.Ntn_ContinenteLegale,
                Ntn_Appartiene = dto.Ntn_Appartiene,
                Ntn_Capitale = dto.Ntn_Capitale,
                Ntn_CapitaleDeFacto = dto.Ntn_CapitaleDeFacto,
                Ntn_CapitaleAmm = dto.Ntn_CapitaleAmm,
                Ntn_CapitaleIdioma = dto.Ntn_CapitaleIdioma,
                Ntn_IDValuta = dto.Ntn_IDValuta,
                Ntn_LunghezzaCAP = dto.Ntn_LunghezzaCAP,
                Ntn_NomePI = dto.Ntn_NomePI,
                Ntn_TipoPI = dto.Ntn_TipoPI,
                Ntn_LunghezzaPI = dto.Ntn_LunghezzaPI,
                Ntn_NomeCF = dto.Ntn_NomeCF,
                Ntn_TipoCF = dto.Ntn_TipoCF,
                Ntn_LunghezzaCF = dto.Ntn_LunghezzaCF,
                Ntn_DescStatoRegione = dto.Ntn_DescStatoRegione,
                Ntn_StatoRegione = dto.Ntn_StatoRegione,
                Ntn_LungSiglaProv = dto.Ntn_LungSiglaProv,
                Ntn_ProvSiNo = dto.Ntn_ProvSiNo,
                Ntn_Province = dto.Ntn_Province,
                Ntn_Localita = dto.Ntn_Localita,
                Ntn_Indirizzi = dto.Ntn_Indirizzi
            };
        }
    }
}