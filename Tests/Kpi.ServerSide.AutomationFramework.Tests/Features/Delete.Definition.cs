using System.Threading.Tasks;
using FluentAssertions;
using Kpi.ServerSide.AutomationFramework.Model.Domain.Pet;
using Kpi.ServerSide.AutomationFramework.TestsData.Storages.Pet;
using TechTalk.SpecFlow;

namespace Kpi.ServerSide.AutomationFramework.Tests.Features
{
    [Binding, Scope(Feature = "Delete Pet by Id")]
    public class DeleteDefinition
    {
        private readonly IPetContext _petContext;
        private PetResponse _createdPet;
        private PetResponse _petResponse;

        public DeleteDefinition(
            IPetContext petContext)
        {
            _petContext = petContext;
        }

        [Given(@"I have created Pet")]
        public async Task GivenIHaveCreatedPet()
        {
            _createdPet = await _petContext.PostPetAsync(PetRequestsStorage.PetRequests["PetModel"]);
        }

        [When(@"I send Pet delete request")]
        public async Task GivenISendPetDeleteRequest()
        {
            await _petContext.DeletePetByIdAsync(_createdPet.Id);
        }

        [Then(@"I see pet response with (.*) id")]
        public async Task GivenISeeReturnedPetDetails(int id)
        {
            _petResponse = await _petContext.GetPetByIdAsync(_createdPet.Id);
            _petResponse.Id.Should().Be(id);
        }
    }
}
