using System.Threading.Tasks;

namespace Kpi.ServerSide.AutomationFramework.Model.Domain.Pet
{
    public interface IPetContext
    {
        Task<PetResponse> GetPetByIdAsync(long petId);

        Task<ResponseMessage> GetPetByIdResponseAsync(string petId);

        Task<PetResponse> PostPetAsync(PetRequest petRequest);

        Task<DeletePetResponse> DeletePetByIdAsync(long petId);

        Task<PetResponse> PutPetAsync(PetRequest petRequest);
    }
}
