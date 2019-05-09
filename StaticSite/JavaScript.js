function GetAirport() {
    var submitButton = document.getElementById("submitButton");
    submitButton.disabled = true;
    var messageLabel = document.getElementById("messageLabel");
    var iataTextBox = document.getElementById("iataTextBox");
    var iataCode = iataTextBox.value;
    var url = "http://cpl-iatacodes-dev.us-east-2.elasticbeanstalk.com/api/Airports/" + iataCode;

    var request = new XMLHttpRequest();
    request.open('GET', url, true);
    request.onload = function () {
        if (200 == request.status) {
            var response = JSON.parse(this.response);
            messageLabel.textContent = "Found airport with IATA code " + iataCode;
            document.getElementById("fullName").textContent = response.fullName;
            document.getElementById("latitude").textContent = response.latitude;
            document.getElementById("longitude").textContent = response.longitude;
        }
        else {
            document.getElementById("fullName").textContent = "";
            document.getElementById("latitude").textContent = "";
            document.getElementById("longitude").textContent = "";

            if (404 == request.status) {
                messageLabel.textContent = "Could not find airport with IATA code " + iataCode;
            }
            else {
                messageLabel.textContent = "Unknown error"
            }
        }
        submitButton.disabled = false;
    }
    request.send();
}