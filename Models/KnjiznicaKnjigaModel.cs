namespace knjiznica.Models
{
    public class KnjiznicaKnjigaModel
    {
        public int Id { get; set; }
        public int Id_knjiznice { get; set; }
        public KnjiznicaModel? Knjiznica { get; set; } // prema knjiznici
        public int Id_knjige { get; set; }
        public KnjigaModel? Knjiga { get; set; }
        public int Kolicina { get; set; }
    }
}
