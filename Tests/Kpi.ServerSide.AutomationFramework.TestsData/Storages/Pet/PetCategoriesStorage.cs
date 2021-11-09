using Bogus;
using Kpi.ServerSide.AutomationFramework.Model.Domain.Pet;

namespace Kpi.ServerSide.AutomationFramework.TestsData.Storages.Pet
{
    public static class PetCategoriesStorage
    {
        public static Category DefaultCategory =>
            new Faker<Category>()
                .RuleFor(u => u.Id, 0);
    }
}
