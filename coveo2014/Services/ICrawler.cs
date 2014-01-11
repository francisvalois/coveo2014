namespace coveo2014.Services
{
    public interface ICrawler
    {
        object GetAlbum(string id);

        object[] GetAlbums(string[] ids);

        object GetArtist(string id);

        object[] GetArtists(string[] ids);
    }
}
