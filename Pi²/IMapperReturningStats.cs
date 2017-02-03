using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bin_packing_a_etoile
{
    public interface IMapperReturningStats<S> : IMapper<S> where S : class, ISprite, new()
    {
        /// <summary>
        /// Version of IMapper.Mapping. See IMapper.
        /// </summary>
        /// <param name="images">Same as for IMapper.Mapping</param>
        /// <param name="mapperStats">
        /// The method will fill the properties of this statistics object.
        /// Set to null if you don't want statistics.
        /// </param>
        /// <returns>
        /// Same as for IMapper.Mapping
        /// </returns>
        S Mapping(IEnumerable<IImageInfo> images, IMapperStats mapperStats);
    }
}
