var express = require('express');
var app = express();
var path = require("path");
app.set('view engine', 'ejs');

app.use(express.static(path.join(__dirname, "public")));

app.get('/report', function(req, res){
  res.sendFile('/report.html');
});

app.get('/lotto', function(req, res){
  let lotto = require('./lotto.js');
  var lottoNumbers = lotto.draw(7);
  var quer = Object.keys(req.query).length;
  if (quer !=0) {
    var myNumbers = lotto.myNums(req.query.row);
    var matches = lotto.matchesNumbers(lottoNumbers, myNumbers);
    res.render('lotto', {lottoNumbers: lottoNumbers, myNumbers: myNumbers, matches: matches, quer: quer});
  }
  else {
    res.render('lotto', {lottoNumbers: lottoNumbers, quer: quer});
  }

});

app.get('/lotto-json', function(req, res){
  var lottoJson = require('./lotto-json.js');
  let lotto = require('./lotto.js');
  var lottoNumbers = lotto.draw(7);
  var myNumbers = lottoJson.myNumbers(req.query.row);
  var numberOfMatches = lottoJson.matches(lottoNumbers, myNumbers);
  var matchesNumbers = numberOfMatches.length;
  res.json({
    lottoNumbers,
    myNumbers,
    matchesNumbers
  });
});

app.listen(1337);
