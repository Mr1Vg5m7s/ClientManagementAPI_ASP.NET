using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClientManagementAPI.Profiles
{
    public class ClientsProfile: Profile
    {
        public ClientsProfile()
        {
            CreateMap<Model.Client, Interface.ClientResponseDto>();
            CreateMap<Interface.CreateClientDto, Model.Client>();
            CreateMap<Interface.UpdateClientDto, Model.Client>();
        }
    }
}
