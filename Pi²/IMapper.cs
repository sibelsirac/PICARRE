using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bin_packing_a_etoile
{
    public interface IMapper<S> where S : class, ISprite, new()
    {
        /// <summary>
        /// Works out how to map a series of images into a sprite.
        /// </summary>
        /// <param name="images">
        /// The list of images to place into the sprite.
        /// </param>
        /// <returns>
        /// A SpriteInfo object. This describes the locations of the images within the sprite,
        /// and the dimensions of the sprite.
        /// </returns>
        S Mapping(IEnumerable<IImageInfo> images);
    }
}
