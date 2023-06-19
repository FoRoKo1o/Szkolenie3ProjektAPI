using System.ComponentModel.DataAnnotations;

namespace Szkolenie3API.DTO.Cat
{
    public class GetCatDto : BaseCatDto
    {
        public int Id { get; set; }
    }
}
