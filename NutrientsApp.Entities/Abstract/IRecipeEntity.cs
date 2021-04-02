namespace NutrientsApp.Entities.Abstract
{
    public interface IRecipeEntity: IBaseEntity
    {
        public string Name { get; set; }
        public string HowTo { get; set; }
    }
}