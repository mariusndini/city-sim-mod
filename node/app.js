var express = require('express');
var path = require('path');
var favicon = require('static-favicon');
var logger = require('morgan');
var cookieParser = require('cookie-parser');
var bodyParser = require('body-parser');
var routes = require('./routes/routes');
const fs = require("fs");
const csv = require('csvtojson');
var http = require('http');
var app = express();
var request = require('request');
var path = 'C:/Users/nait/AppData/LocalLow/Colossal Order/Cities_ Skylines/';

app.use(favicon());
app.use(logger('dev'));
app.use(bodyParser.json());
app.use(bodyParser.urlencoded());
app.use(cookieParser());
//app.use(express.static(path.join(__dirname, 'public')));

app.use(function(req, res, next) {
  res.header("Access-Control-Allow-Origin", "*");
  res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
  next();
});

app.use('/', routes);
//*********  read file and load here ******
var timer = setInterval(getCityData, 5000);


var webGet = function(link) {
    return new Promise((resolve, reject) => {
        var options = {
            uri: 'http://localhost:8080/'+link,
            method: 'POST',

        };
        request.post(options,
            (err, httpResponse, body) => {
                resolve(body);
            }); // end request

    });
}


function getCityData() {
    var data = {};

    return webGet('webBuildings').then((body) => {
        data.buildings = body;
        return webGet('webCimData');

        }).then((body) => {
            data.cim = body;
            return webGet('webGenInfo');

        }).then((body) => {
            data.cim = body;
            return webGet('webIncome');

        }).then((body) => {
            data.cim = body;
            return webGet('webVehicleStats');

        }).then((body) => {
            data.cim = body;
            return webGet('webTrafficData');

        }).then((body) => {
            data.cim = body;
            return webGet('Messages');

        }).then((body) => {
            data.cim = body;
            console.log(data);

    })





}



function postData(link) {
    var options = {
        uri: 'http:localhost:8080/' + link,
        method: 'POST',

    };
    request.post(options, (err, httpResponse, body) => {
        return body;
    }); // end request
}//end post data



/*
function getCityData() {  
    var data = {};
    data.generalData = {};
    data.econData = {};    

    csv()
    .fromFile(path + 'cimdata.csv') //get cims
    .then((cimdata)=>{
        data.citizens = cimdata;
        return csv().fromFile(path + 'buildingdata.csv'); //get buildings
    })
    .then((buildingdata)=>{
        data.buildings = buildingdata;
        return csv().fromFile(path + 'inout.csv'); // get expense-income
    })
    .then((inoutdata)=>{
        data.inout = inoutdata;
        return csv().fromFile(path + 'genInfo.csv'); //get geninfo
    })
    .then((genInfo)=>{
        data.genInfo = genInfo;
        return csv().fromFile(path + 'vehicledata.csv'); //get geninfo

    })
    .then((vehicles)=>{
        data.vehicles = vehicles;
        return csv().fromFile(path + 'allcarsdata.csv'); //get geninfo
    })
    .then((allVehicles)=>{
        data.allVehicles = allVehicles;
        postData(data);
    })




    //Post Data to server
    function postData(d){
        var options = {
            uri: 'http://blockchain.sapnait.com:45000/postCityData',
            method: 'POST',
            json: d
        };
        request.post(options, (err, httpResponse, body)=>{
            console.log(body);
        }); // end request
    }//end post data

}//end end get data
*/

module.exports = app;

