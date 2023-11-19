namespace ParcialRostrosFelices.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TipoDocumento { get; set; }
        public int NroDocumento { get; set; }
        public int Telefono { get; set; }
        public ICollection<Servicio>? Servicios { get; set; }
    }
}
