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


app.use(favicon());
app.use(logger('dev'));
app.use(bodyParser.json());
app.use(bodyParser.urlencoded());
app.use(cookieParser());
app.use(express.static(path.join(__dirname, 'public')));

app.use(function(req, res, next) {
  res.header("Access-Control-Allow-Origin", "*");
  res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
  next();
});

app.use('/', routes);


//*********  read file and load here ******
var timer = setInterval(getCityData, 1000);

function getCityData() {  
  var data = {};

  //Get Cim data
  csv()
    .fromFile('/Users/i830729/Library/Application Support/unityColossalSkylines/cimdata.csv')
    .then((cimData)=>{
        data.citizens = cimData;

        // Get Building Data
        csv()
          .fromFile('/Users/i830729/Library/Application Support/unityColossalSkylines/buildingdata.csv')
          .then((buildingData)=>{
            data.buildings = buildingData;

              //get Gen info
              csv()
                .fromFile('/Users/i830729/Library/Application Support/unityColossalSkylines/genInfo.csv')
                .then((info)=>{
                  info.postTime = new Date();
                  data.genInfo = info;

                  csv()
                  .fromFile('/Users/i830729/Library/Application Support/unityColossalSkylines/econdata.csv')
                  .then((econ)=>{ 
                    data.economy = econ;

                      //Post Data to Server
                      var options = {
                        uri: 'http://blockchain.sapnait.com:45000/postCityData',
                        method: 'POST',
                        json: data
                      };

                      request.post(options, (err, httpResponse, body)=>{
                        console.log(body);
                      }); // end request


                  })// end csv


            })// end building CSV   

              
            
        })// end building CSV

  })//end CSV

  

}//end end get ata


module.exports = app;

