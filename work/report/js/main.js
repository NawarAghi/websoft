/**
 * A function to wrap it all in.
 */
(function () {
    "use strict";

    console.log("All ready.");
})();

function clickme(opt){
  const proxyUrl = "https://cors-anywhere.herokuapp.com/";
  var komCode = '';
  switch (opt) {
    case 'Kristianstad':
      komCode = '1290';
      console.log(komCode);
      break;
    case 'Hudiksvall':
      komCode = '2184';
      console.log(komCode);
      break;
    case 'Lund':
      komCode='1281';
      console.log(komCode);
      break;
    case 'Stockholm':
      komCode = '0180';
      console.log(komCode);
      break;
    default:
  }
  fetch(proxyUrl+
    "http://api.scb.se/UF0109/v2/skolenhetsregister/sv/kommun/" + komCode)
  .then((response) => {
    return response.json();
  })
  .then((myJson) => {
    var schols = myJson.Skolenheter;
    var table = "<tr><th>Skolenhetskod</th><th>Skolenhetsnamn</th><th>Kommunkod</th><th>PeOrgNr</th></tr>";

    for(i=0; i < schols.length; i++){
      table += "<tr><td>" + schols[i].Skolenhetskod +"</td>"
                + "<td>" + schols[i].Skolenhetsnamn + "</td>"
                + "<td>" + schols[i].Kommunkod + "</td>"
                + "<td>" + schols[i].PeOrgNr + "</td></tr>";
    }
    document.getElementById("container").innerHTML = table;

  });

}

function moveDuck(){
  var area = document.body,
      areaHeight = window.innerHeight,
      areaWidth = window.innerWidth,
      duck = document.getElementById('duck');

      duck.style.position ='fixed';
      duck.style.left = '0px';
      duck.style.top = '0px';
      duck.style.zIndex = 10000;

      var newX = Math.floor(Math.random() * (areaWidth - duck.width)),
          newY = Math.floor(Math.random() * (areaHeight - duck.height));
          console.log(newX, newY);

      duck.style.left = newX+'px';
      duck.style.top = newY+'px';
      area.appendChild(duck);
}

function show(){
  var button = document.getElementById("duckButton");
  var duck = document.getElementById("duck")
 if (button.value === "Show Duck") {
   button.value = "Hide Duck";
   duck.style.display = "block";
   document.getElementById("duckButton").innerHTML = button.value;
 } else {
   button.value = "Show Duck";
   document.getElementById("duckButton").innerHTML = button.value;
   duck.style.display = "none";
 }
}


function drawGermanFlag(){
  var germanTarget = document.getElementById("german_flag");
  var germanLink = document.getElementById("german_flag_link");
  var germany = '<div class= "german"></div>';
  if (germanTarget.style.visibility === "hidden") {
    germanTarget.style.visibility = "visible";
    germanTarget.style.opacity = "1";
  }
  germanTarget.innerHTML = germany;

}

function drawFrenchFlag(){
  var frenchTarget = document.getElementById("french_flag");
  var frenchLink = document.getElementById("french_flag_link");
  var france = '<div class= "french"></div>';
  if (frenchTarget.style.visibility === "hidden") {
    frenchTarget.style.visibility = "visible";
    frenchTarget.style.opacity = "1";
  }
  frenchTarget.innerHTML = france;

}

function drawItalianFlag(){
  var italianTarget = document.getElementById("italian_flag");
  varitalianLink = document.getElementById("italian_flag_link");
  var italy = '<div class= "italian"></div>';
  if (italianTarget.style.visibility === "hidden") {

    italianTarget.style.visibility = "visible";
    italianTarget.style.opacity = "1";
  }
  italianTarget.innerHTML= italy;

}

function hideFlags(flagId){
  var flag = document.getElementById(flagId);
  console.log(flag.id);
  flag.style.visibility = "hidden";
  flag.style.opacity = "0";
  flag.style.transition = "all 1.6s linear";
}
