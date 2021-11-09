using System.Collections.Generic;
using Bogus;
using Kpi.ServerSide.AutomationFramework.Model.Domain.Pet;

namespace Kpi.ServerSide.AutomationFramework.TestsData.Storages.Pet
{
    public static class PetResponsesStorage
    {
        public static Dictionary<string, PetResponse> PetResponses =>
            new Dictionary<string, PetResponse>
            {
                { "PetModel", PetModel }
            };

        private static PetResponse PetModel =>
            new Faker<PetResponse>()
                .RuleFor(u => u.Id, 999)
                .RuleFor(u => u.Category, PetCategoriesStorage.DefaultCategory)
                .RuleFor(u => u.Name, "Test")
                .RuleFor(u => u.Status, "available")
                .RuleFor(u => u.PhotoUrls, value: new[] { "string" })
                .RuleFor(u => u.Tags, new[] { PetTagsStorage.Default });
    }
}
