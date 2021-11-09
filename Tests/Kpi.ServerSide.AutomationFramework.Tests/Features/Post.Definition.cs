using System.Threading.Tasks;
using FluentAssertions;
using Kpi.ServerSide.AutomationFramework.Model.Domain.Pet;
using Kpi.ServerSide.AutomationFramework.TestsData.Storages.Pet;
using TechTalk.SpecFlow;

namespace Kpi.ServerSide.AutomationFramework.Tests.Features
{
    [Binding, Scope(Feature = "Post")]
    public class PostDefinition
    {
        private readonly IPetContext _petContext;
        private PetResponse _createdPet;
        private PetResponse _petResponse;

        public PostDefinition(
            IPetContext petContext)
        {
            _petContext = petContext;
        }

        [Given(@"I have free API with swagger")]
        public void GivenIHaveFreeApiWithSwagger()
        {
        }

        [When(@"I send pet creation request")]
        public async Task GivenISendPetCreationRequest()
        {
            _createdPet = await _petContext.PostPetAsync(PetRequestsStorage.PetRequests["PetModel"]);
        }

        [Then(@"I see created pet in get response")]

        public async Task GivenISeeCreatedPetInGetResponse()
        {
            _petResponse = await _petContext.GetPetByIdAsync(_createdPet.Id);
            _petResponse.Should().BeEquivalentTo(_createdPet);
        }
    }
}
