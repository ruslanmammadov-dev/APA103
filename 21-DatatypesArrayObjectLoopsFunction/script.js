//Task 1
function removeDuplicates(arr) {
    let uniqueArray = [...new Set(arr)];
    let duplicateCount = arr.length - uniqueArray.length;
    
    return {
        result: uniqueArray,
        duplicatesRemoved: duplicateCount
    };
}
const nums = [1, 2, 2, 3, 4, 4, 4, 5];
console.log(removeDuplicates(nums)); 

//Task 2
const isPalindrome = (word) => {
    let reversed = word.split('').reverse().join('');
    return word.toLowerCase() === reversed.toLowerCase();
};

console.log(isPalindrome("Küllük")); 
console.log(isPalindrome("Salam"));  

//Task 3
function countGreaterElements(arr, num) {
    return arr.filter(el => el > num).length;
}

const numbers = [10, 25, 5, 30, 12];
console.log(countGreaterElements(numbers, 15));

//Task 4
function checkNumberType(n) {
    let sum = 0;
    for (let i = 1; i <= n / 2; i++) {
        if (n % i === 0) {
            sum += i;
        }
    }

    if (sum > n) {
        return `${n} - Abundant ədəddir`;
    } else {
        return `${n} - Deficient ədəddir`;
    }
}

console.log(checkNumberType(12)); 
console.log(checkNumberType(13)); 

//Task 5
const squareArray = (arr) => arr.map(x => x * x);

const simpleNumbers = [2, 3, 4, 5];
const squared = squareArray(simpleNumbers);

console.log(squared);