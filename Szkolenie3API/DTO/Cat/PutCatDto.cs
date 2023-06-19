using System.ComponentModel.DataAnnotations;

namespace Szkolenie3API.DTO.Cat
{
    public class PutCatDto : BaseCatDto
    {
        public int Id { get; set; }
    }
}
