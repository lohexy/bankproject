using System.Collections.Generic;
using BankEmulator.App.DTO;

namespace BankEmulator.App
{
    public interface IFileStorage
    {
        List<ClientDto> LoadClients();
        void SaveClients(List<ClientDto> clients);
    }
}