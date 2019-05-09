
function GetAirport() {
    var request = new XMLHttpRequest();
    request.open('GET', 'http://cpl-iatacodes-dev.us-east-2.elasticbeanstalk.com/api/Airports/LACI', true);

    request.send();
}

request.onload = function () {


    // Begin accessing JSON data here
    var data = JSON.parse(this.response);
    if (request.status >= 200 && request.status < 400) {
        var statusCodeElement = document.getElementById("statusCode");
        statusCodeElement.textContent = "Yay";
    } else {
        const errorMessage = document.createElement('marquee');
        errorMessage.textContent = `Gah, it's not working!`;
        app.appendChild(errorMessage);
    }
}

request.send();