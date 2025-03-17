namespace knjiznica.Models
{
    public class KnjiznicarModel
    {
        public int Id {  get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? Oib { get; set; }
        public string? Email { get; set; }
        public string? Plaća { get; set; }

        public int Id_knjiznice { get; set; }  // foreign key

        public KnjiznicaModel? Knjiznica { get; set; }  // navigacijsko svojstvo


    }
}
