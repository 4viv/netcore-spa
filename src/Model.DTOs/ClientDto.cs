using System.ComponentModel.DataAnnotations;

namespace Model.DTOs
{
    // Clase para agregar un cliente
    public class ClientCreateDto
    {
        [Required]
        public string Name { get; set; }
    }

    public class ClientUpdateDto
    {
        [Required]
        public string Name { get; set; }
    }

    // Clase para buscar clientes
    public class ClientDto
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
    }
}
