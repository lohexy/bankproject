using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using BankEmulator.App.DTO;

namespace BankEmulator.App
{
    public class FileStorage : IFileStorage
    {
        private readonly string _filePath = "bank_data.json";
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        public List<ClientDto> LoadClients()
        {
            if (!File.Exists(_filePath))
            {
                return new List<ClientDto>();
            }

            try
            {
                string json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<ClientDto>>(json, _options) ?? new List<ClientDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка читання файлу: {ex.Message}");
                return new List<ClientDto>();
            }
        }

        public void SaveClients(List<ClientDto> clients)
        {
            try
            {
                string json = JsonSerializer.Serialize(clients, _options);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка збереження даних у файл: {ex.Message}");
            }
        }
    }
}