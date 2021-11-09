using System.Reflection;
using System.Threading.Tasks;
using Kpi.ServerSide.AutomationFramework.Model.Domain;
using Kpi.ServerSide.AutomationFramework.Model.Domain.Pet;
using Kpi.ServerSide.AutomationFramework.Model.Platform.Communication;
using Kpi.ServerSide.AutomationFramework.Platform.Client;
using Kpi.ServerSide.AutomationFramework.Platform.Communication.Http;
using Kpi.ServerSide.AutomationFramework.Platform.Configuration.Environment;
using Serilog;

namespace Kpi.ServerSide.AutomationFramework.PetApi.Pet
{
    public class PetApiClient : ApiClientBase, IPetApiClient
    {
        public PetApiClient (
            IClient client,
            ILogger logger,
            IEnvironmentConfiguration environmentConfiguration)
            : base(client, logger)
        {
            client.SetBaseUri(environmentConfiguration.EnvironmentUri);
        }

        private readonly string BaseUri = "/v2/pet";

        public async Task<PetResponse> GetPetByIdAsync(
            long petId)
        {
            var restResponse = await ExecuteGetAsync(
                $"{BaseUri}/{petId}");

            return restResponse.GetModel<PetResponse>();
        }

        public async Task<ResponseMessage> GetPetByIdResponseAsync(
            string petId)
        {
            Logger.Information(
                "Start '{@Method}' with {@petId}",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                petId);

            var restResponse = await ExecuteGetAsync(
                $"{BaseUri}/{petId}");

            Logger.Information(
                "Finished '{@Method}' with {@restResponse}",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                restResponse);

            return new ResponseMessage
            {
                Content = restResponse.Content,
                StatusCode = restResponse.StatusCode.ToString()
            };
        }

        public async Task<PetResponse> PostPetAsync(
            PetRequest petRequest)
        {
            Logger.Information(
                "Start '{@Method}' with {@petRequest}",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                petRequest);

            var restResponse = await ExecutePostAsync(BaseUri, petRequest);

            Logger.Information(
                "Finished '{@Method}' with {@restResponse}",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                restResponse);
            return restResponse.GetModel<PetResponse>();
        }

        public async Task<PetResponse> PutPetAsync(
            PetRequest petRequest)
        {
            Logger.Information(
                "Start '{@Method}' with {@petRequest}",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                petRequest);

            var restResponse = await ExecutePutAsync(
                BaseUri,
                petRequest);

            Logger.Information(
                "Finished '{@Method}' with {@restResponse}",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                restResponse);
            return restResponse.GetModel<PetResponse>();
        }

        public async Task<DeletePetResponse> DeletePetByIdAsync(
            long petId)
        {
            Logger.Information(
                "Start '{@Method}' with {@petId}",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                petId);

            var restResponse = await ExecuteDeleteAsync(
                $"{BaseUri}/{petId}");

            Logger.Information(
                "Finished '{@Method}' with {@restResponse}",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                restResponse);
            return restResponse.GetModel<DeletePetResponse>();
        }
    }
}
