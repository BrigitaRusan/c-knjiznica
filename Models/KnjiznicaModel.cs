namespace knjiznica.Models
{
    public class KnjiznicaModel
    {
        public int Id { get; set; }
        public string? Naziv { get; set; }
        public string? Adresa { get; set; }
        public string? God_osnivanja { get; set; }
        public string? Citaonica { get; set; }
        public string? Telefon {  get; set; }

        public List<KnjiznicarModel> Knjiznicari { get; set; } = new List<KnjiznicarModel>();
        public ICollection<KnjiznicaKnjigaModel>? KnjizniceKnjige { get; set; }

    }
}
