using System.Threading.Tasks;
using FluentAssertions;
using Kpi.ServerSide.AutomationFramework.Model.Domain;
using Kpi.ServerSide.AutomationFramework.Model.Domain.Pet;
using Kpi.ServerSide.AutomationFramework.TestsData.Storages.Pet;
using TechTalk.SpecFlow;

namespace Kpi.ServerSide.AutomationFramework.Tests.Features
{
    [Binding, Scope(Feature = "Get Pet by Id")]
    public class GetDefinition
    {
        private readonly IPetContext _petContext;
        private PetResponse _petResponse;
        private ResponseMessage _invalidPetResponse;
        private PetResponse _createdPet;

        public GetDefinition(
            IPetContext petContext)
        {
            _petContext = petContext;
        }

        [Given(@"I have Pet API")]
        public void GivenIHaveFreeApiWithSwagger()
        {
        }

        [When(@"I receive pet by valid posted id")]
        public async Task GivenIReceivePetByValidId()
        {
            _createdPet = await _petContext.PostPetAsync(PetRequestsStorage.PetRequests["PetModel"]);
            _petResponse = await _petContext.GetPetByIdAsync(_createdPet.Id);
        }

        [When(@"I receive pet by invalid (.*) id")]
        public async Task GivenIReceivePetByInvalidId(string wrongId)
        {
            _invalidPetResponse = await _petContext.GetPetByIdResponseAsync(wrongId);
        }

        [Then(@"I see returned pet details")]
        public void ThenISeeReturnedPetDetails()
        {
            _petResponse.Should().BeEquivalentTo(_createdPet);
        }

        [Then(@"I see (.*) returned invalid pet details")]
        public void ThenISeeReturnedInvalidPetDetails(string invalidResponse)
        {
            _invalidPetResponse.Content.Should().Be(invalidResponse);
        }
    }
}
