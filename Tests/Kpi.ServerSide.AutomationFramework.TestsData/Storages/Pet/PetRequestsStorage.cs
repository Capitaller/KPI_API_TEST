using System.Collections.Generic;
using Bogus;
using Kpi.ServerSide.AutomationFramework.Model.Domain.Pet;

namespace Kpi.ServerSide.AutomationFramework.TestsData.Storages.Pet
{
    public static class PetRequestsStorage
    {
        public static Dictionary<string, PetRequest> PetRequests =>
            new Dictionary<string, PetRequest>
            {
                { "PetModel", PetModel }
            };

        private static PetRequest PetModel =>
            new Faker<PetRequest>()
                .RuleFor(u => u.Id, 999)
                .RuleFor(u => u.Category, PetCategoriesStorage.DefaultCategory)
                .RuleFor(u => u.Name, "Test")
                .RuleFor(u => u.Status, "available")
                .RuleFor(u => u.PhotoUrls, value: new[] { "string" })
                .RuleFor(u => u.Tags, new[] { PetTagsStorage.Default });
    }
}
