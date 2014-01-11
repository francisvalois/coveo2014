$(document).ready(function () {

    $(".facet-slider").slider();

    $('#test').slider({
        formater: function (value) {
            return 'Current value: ' + value;
        }
    });

    updateArtworkFromItunes();

    var wikiContents = document.getElementById('bibliography');
    if (wikiContents != undefined)
        wikiContents.innerHTML = wikiContents.innerHTML.wiki2html();
});


function updateArtworkFromItunes() {
    $(".albumArt[data-artist]").each(function (value, key) {
        console.log(value, key);

        var artist = key.attributes['data-artist'].value;
        var album = key.attributes['data-album'].value;

        getAlbumArtwork(album, artist).done(function (resp) {
            console.log(resp);
            if (resp.results.length > 0)
                key.innerHTML = '<img class="albumArt" src="' + resp.results[0].artworkUrl100 + '"/>';
            else {
                key.innerHTML = '<img class="albumArt" src="http://www.progx.org/users/Gfx/empty_case.png"/>';
            }
        });
    });

    $(".singleAlbumArt[data-artist]").each(function (value, key) {
        console.log(value, key);

        var artist = key.attributes['data-artist'].value;
        var album = key.attributes['data-album'].value;

        getAlbumArtwork(album, artist).done(function (resp) {
            console.log(resp);
            if (resp.results.length > 0)
                key.innerHTML = '<img class="singleAlbumArt" src="' + resp.results[0].artworkUrl100 + '"/>';
            else {
                key.innerHTML = '<img class="singleAlbumArt" src="http://www.progx.org/users/Gfx/empty_case.png"/>';
            }
        });
    });

}

function getAlbumArtwork(albumName, artistName) {
    var parsedAlbumName = albumName.split(' ').join('+');
    var parsedArtistName = artistName.split(' ').join('+');

    return $.ajax({
        type: "GET",
        url: "https://itunes.apple.com/search?term=" + parsedAlbumName + "+" + parsedArtistName,
        dataType: "json"
    });

}