

using Microsoft.AspNetCore.Http;

namespace Tapar.Core.Common.Dtos.Place
{
    public class UpdateVisitCartPic
    {
        public long placeid { get; set; }
        public IFormFile visitcart_front { get; set; }
        public IFormFile visitcart_back { get; set; }
    }
}
