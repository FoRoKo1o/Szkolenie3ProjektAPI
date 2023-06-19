using System.ComponentModel.DataAnnotations;

namespace Szkolenie3API.DTO.Dog
{
    public class GetDogDto : BaseDogDto
    {
        public int Id { get; set; }
    }
}
