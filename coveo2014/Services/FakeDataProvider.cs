namespace coveo2014.Services
{
    using System.Collections.Generic;

    using coveo2014.Domain;

    public class FakeDataProvider : IDataProvider
    {
        public IList<string> Genres { get; private set; }

        public IList<Artist> Artists { get; private set; }

        public IList<Album> Albums { get; private set; }

        public void CrawlData()
        {
            this.CrawlGenres();
        }

        private void CrawlGenres()
        {
            const string genresStr =
                "Blues & Blues Rock;Bluegrass;Children's;Christian;Christian: Gospel;Christmas;Classical;Classical: Crossover;Classical: Vocal;Country;Country: Classic Country;Country: Contemporary Country;Dance;Dance: Disco & Nu Disco;Dance: House & Techno;Dancehall;Dubstep & Drum 'n' Bass;Easy Listening;Electronica;Film Scores;Folk;Funk;Hawaiian ;Indie: Indie Electronic;Indie: Indie Folk & Americana;Indie: Indie Pop;Indie: Indie Rock;International/World;Int'l: African;Int'l: Asian;Int'l: Brazilian;Int'l: Jamaican;Int'l: Mediterranean;Jazz;Jazz: Vocal Jazz;Latin;Latin: Cuban;Latin: Puerto Rican;Latin: Salsa;Latin: Tropical;Nature Sounds;Oldies;Pop;Pop: Classic Pop;Pop: Dance Pop;Pop: Soft Pop;R&B;R&B: Classic R&B;R&B: Contemporary R&B;R&B: Soul;Rap;Rap: Classic Mainstream Rap;Rap: Old School Rap;Rap: Today's Mainstream Rap;Rap: Underground & Alternative Rap;Reggae & Ska;Reggaeton;Rock;Rock: Classic Alternative & Punk;Rock: Classic Rock;Rock: Contemporary Alternative;Rock: Emo/Pop-Punk;Rock: Hard Rock;Rock: Metal;Rock: Modern Rock;Rock: Rockabilly;Singer-Songwriter;Showtunes";

            this.Genres = genresStr.Split(';');
        }
    }
}
