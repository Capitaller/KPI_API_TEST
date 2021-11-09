using System.Threading.Tasks;
using Kpi.ServerSide.AutomationFramework.Model.Domain;
using Kpi.ServerSide.AutomationFramework.Model.Domain.Pet;

namespace Kpi.ServerSide.AutomationFramework.PetApi.Pet
{
    public class PetContext : IPetContext
    {
        private readonly IPetApiClient _petApiClient;

        public PetContext(
            IPetApiClient petApiClient)
        {
            _petApiClient = petApiClient;
        }

        public async Task<PetResponse> GetPetByIdAsync(
            long petId)
        {  
            return await _petApiClient.GetPetByIdAsync(petId);
        }

        public async Task<ResponseMessage> GetPetByIdResponseAsync(
            string petId)
        {
            return await _petApiClient.GetPetByIdResponseAsync(petId);
        }

        public async Task<PetResponse> PostPetAsync(
            PetRequest petRequest)
        {
            return await _petApiClient.PostPetAsync(petRequest);
        }

        public async Task<PetResponse> PutPetAsync(
            PetRequest petRequest)
        {
            return await _petApiClient.PutPetAsync(petRequest);
        }

        public async Task<DeletePetResponse> DeletePetByIdAsync(
            long petId)
        {
            return await _petApiClient.DeletePetByIdAsync(petId);
        }
    }
}
