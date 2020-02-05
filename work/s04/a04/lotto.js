"use strict";

var draw = function(num){
  let numbers = [];

  while (numbers.length != num) {
    let number = Math.floor((Math.random() * 35) + 1);
    if (!numbers.includes(number)) {
      numbers[numbers.length] = number;
    }
  }

  return numbers;
};

var myNums = function(queryString) {
  let result = queryString.split(',');
  for (let i in result) {
    result[i] = parseInt(result[i], 10);
  }
  return result;
};

var matchesNumbers = function(lottoNumbers, ownNumbers){
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
  draw: draw,
  myNums: myNums,
  matchesNumbers: matchesNumbers
};
