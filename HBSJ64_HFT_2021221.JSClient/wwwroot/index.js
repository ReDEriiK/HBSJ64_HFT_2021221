let films = [];

fetch('http://localhost:4472/film')
    .then(x => x.json())
    .then(y => {
        films = y;
        console.log(films);
        display();
    });

function display() {
    films.forEach(t => { 
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.filmId + "</td><td>"
            + t.title + "</td><td>"
            + t.genre + "</td><td>"
            + t.dateOfPublish + "</td></tr>";
    });

}
function create() {
    let titleofthefilm = document.getElementById('filmtitle').value;
    let genreofthefilm = document.getElementById('filmgenre').value;
    let dateofthefilm = document.getElementById('filmdate').value;


    fetch('http://localhost:4472/film', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                title: titleofthefilm,
                genre: genreofthefilm,
                dateOfPublish: dateofthefilm,
                actorId: 1,
                directorId: 1
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
