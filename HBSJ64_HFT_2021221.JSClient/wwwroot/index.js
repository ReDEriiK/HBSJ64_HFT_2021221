let films = [];
let connection = null;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:4472/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();


    connection.on("MovieCreated", (user, message) =>
    {
        console.log(user);
        console.log(message);
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
            "<tr><td>" + t.filmId + "</td><td>"
            + t.title + "</td><td>"
            + t.genre + "</td><td>"
            + t.dateOfPublish + "</td><td>"
            + `<button type="button" onclick="remove(${t.filmId})"> Delete</button>` + "</td></tr>";
    });

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
    getdata();
}
