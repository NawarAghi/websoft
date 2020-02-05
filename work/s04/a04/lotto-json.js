
var myNumbers = function(queryString){
  let numbers = queryString.split(',');
  for (let i in numbers) {
    numbers[i] = parseInt(numbers[i], 10);
  }
  return numbers;
};

var matches = function(lottoNumbers, ownNumbers){
  let matchNumbers = [];
  for(let i=0; i<7; i++){
    for(let j=0; j<7; j++){
      if(lottoNumbers[i] === ownNumbers[j]){
        matchNumbers.push(lottoNumbers[i]);
      }
    }

  }
  return matchNumbers;
};

module.exports = {
myNumbers: myNumbers,
matches: matches
};
