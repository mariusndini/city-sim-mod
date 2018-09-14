const http = require('http');
const https = require('https');
const app = require('./app.js');
const fs = require("fs");

const port = 50000;


//const server = http.createServer(app);
const server = http.createServer(app).listen(port);
//const httpserver = http.createServer(app).listen(port);

let io = require('socket.io')(server);

io.on('connection', function(socket){
	app.socket = socket;
});

app.io = io;

console.log('SERVER START -p: ' + port );
//server.listen(port);

