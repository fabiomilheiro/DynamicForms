namespace DynamicForms.Common.Models.ConfigurationModels.Blocks
{
    public class BlockBase
    {
        public string Type => GetType().Name.Replace("Block", null);
    }
}