using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICampaignService
{
    Task Create(PostCampaignDTO campaignDTO);
    Task<List<GetCampaignsDTO>> GetAll();
    Task Update(long id, PutCampaignDTO campaignDTO);
    Task<GetCampaignByIdDTO> GetById(long id);
    Task Delete(long id);
}