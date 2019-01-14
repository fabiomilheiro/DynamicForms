using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using DynamicForms.Common.Infrastructure.Extensions;
using DynamicForms.Common.Infrastructure.Helpers;
using DynamicForms.Common.Models.ConfigurationModels.Blocks;

namespace DynamicForms.Common.Infrastructure.Json.Converters
{
    public class BlockConverter : JsonConverterBase<BlockBase>
    {
        private static readonly List<Type> blockTypes = GetBlockTypes();

        public BlockConverter(IRequestWrapper requestWrapper) : base(requestWrapper)
        {
        }

        private static List<Type> GetBlockTypes()
        {
            return typeof(BlockConverter)
                .Assembly
                .GetTypes()
                .Where(t => typeof(BlockBase).IsAssignableFrom(t) && t.IsConcreteClass())
                .ToList();
        }

        public override BlockBase Create(Type objectType, JObject source)
        {
            var blockTypeName = source["type"] + "Block";
            var blockType = blockTypes.SingleOrDefault(w => w.Name == blockTypeName);
            if (blockType == null)
            {
                throw new NotSupportedException(
                    $"There is no block annotation named '{blockTypeName}'. Be sure to suffix the block class with 'Block'.");
            }

            var block = (BlockBase)Activator.CreateInstance(blockType);

            return block;
        }
    }
}