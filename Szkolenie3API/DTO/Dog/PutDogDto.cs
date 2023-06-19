using System.ComponentModel.DataAnnotations;

namespace Szkolenie3API.DTO.Dog
{
    public class PutDogDto : BaseDogDto
    {
        public int Id { get; set; }
    }
}
