using System.Runtime.Serialization;

namespace Shopping.Api.Dtos
{
    public class UserDto
    {
        [DataMember(Name="name")]
        public string Name { get; set; }
        [DataMember(Name = "token")]
        public string Token { get; set; }
    }
}
