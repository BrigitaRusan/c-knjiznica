namespace knjiznica.Models
{
    public class KnjigaModel
    {
        public int Id { get; set; }
        public string? Naziv { get; set; }
        public string? Autor { get; set; }
        public string? Isbn { get; set; }
        public int Kolicina { get; set; }

        public ICollection<KnjiznicaKnjigaModel>? KnjizniceKnjige { get; set; }
    }
}
