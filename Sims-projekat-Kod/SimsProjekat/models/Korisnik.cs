namespace SismProjekat.models
{
    public class Korisnik
    {
        protected string ime { get; set; }
        protected string prezime { get; set; }
        protected string email { get; set; }
        protected string brojTelefona { get; set; }

        public string Ime => ime;
        public string Prezime=>prezime;
        public string Email => email;
        public string BrojTelefona=>brojTelefona;

        public Korisnik() { }

        public Korisnik(string ime, string prezime, string email, string brojTelefona)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.email = email;
            this.brojTelefona = brojTelefona;
        }

    }
}