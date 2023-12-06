var io = require("socket.io-client");
var socket = io("http://localhost:5203/chathub");
socket.on("connect", function () {
    console.log("Connected to server");
});
socket.on("ReceiveMessage", function (user, message) {
    console.log("Received message from ".concat(user, ": ").concat(message));
    // Do something with the received message
});
// Keep the script running until the socket connection is established
var checkConnectionInterval = setInterval(function () {
    if (socket.connected) {
        clearInterval(checkConnectionInterval); // Stop checking
    }
}, 1000); // Check every 1 second
