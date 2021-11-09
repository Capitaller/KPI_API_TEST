using Bogus;
using Kpi.ServerSide.AutomationFramework.Model.Domain.Pet;

namespace Kpi.ServerSide.AutomationFramework.TestsData.Storages.Pet
{
    public static class PetTagsStorage
    {
        public static Tag Default =>
            new Faker<Tag>()
                .RuleFor(u => u.Name, "string")
                .RuleFor(u => u.Id, "0");
    }
}
