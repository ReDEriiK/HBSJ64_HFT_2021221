let films = [];
let connection = null;
let filmIdToUpdate = -1;    

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:4472/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();


    connection.on("FilmCreated", (user, message) =>
    {
        getdata();
    });
    connection.on("FilmUpdated", (user, message) => {
        getdata();
    });
    connection.on("FilmDeleted", (user, message) => {
        getdata();
    });
    connection.onclose(async () =>
    {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};


async function getdata() {
    await fetch('http://localhost:4472/film')
        .then(x => x.json())
        .then(y => {
            films = y;
            //console.log(films);
            display();
        });
    
}




function display() {
    document.getElementById('resultarea').innerHTML = "";
    films.forEach(t => { 
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>"
            + t.filmId + "</td><td>"
            + t.title + "</td><td>"
            + t.genre + "</td><td>"
            + t.dateOfPublish + "</td><td>"
            + t.actorId + "</td><td>"
            + t.directorId + "</td><td>"
            `<button type="button" onclick="remove(${t.filmId})">Delete</button>` + "</td><td>"
            `<button type="button" onclick="showupdate(${t.filmId})">Update</button>`
            + "</td></tr>";
    });
}

function showupdate(id) {
    document.getElementById('filmtitleupdate').value = films.find(t => t['filmId'] == id)['title'];
    document.getElementById('filmgenreupdate').value = films.find(t => t['filmId'] == id)['genre'];
    document.getElementById('filmdateupdate').value = films.find(t => t['filmId'] == id)['dateOfPublish'];
    document.getElementById('filmactorupdate').value = films.find(t => t['filmId'] == id)['actorId'];
    document.getElementById('filmdirectorupdate').value = films.find(t => t['filmId'] == id)['directorId'];
    document.getElementById('updateformdiv').style.display = 'flex';
    filmIdToUpdate = id;
}

function remove(id) {
    fetch('http://localhost:4472/film/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
    
}
function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let titleofthefilm = document.getElementById('filmtitleupdate').value;
    let genreofthefilm = document.getElementById('filmgenreupdate').value;
    let dateofthefilm = document.getElementById('filmdateupdate').value;
    let actorofthefilm = document.getElementById('filmactorupdate').value;
    let directorofthefilm = document.getElementById('filmdirectorupdate').value;


    fetch('http://localhost:4472/film', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                title: titleofthefilm,
                genre: genreofthefilm,
                dateOfPublish: dateofthefilm,
                actorId: actorofthefilm,
                directorId: directorofthefilm,
                filmId: filmIdToUpdate
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
        })
        .catch((error) => {
            console.error('Error:', error);
        });
    getdata();
}

function create() {
    let titleofthefilm = document.getElementById('filmtitle').value;
    let genreofthefilm = document.getElementById('filmgenre').value;
    let dateofthefilm = document.getElementById('filmdate').value;
    let actorofthefilm = document.getElementById('filmactor').value;
    let directorofthefilm= document.getElementById('filmdirector').value;


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
                actorId: actorofthefilm,
                directorId: directorofthefilm
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
        })
        .catch((error) => {
            console.error('Error:', error);
        });
    getdata();
}
