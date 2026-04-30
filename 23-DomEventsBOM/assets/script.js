const calculate = (operator) => {
    const n1 = document.querySelector('#num1').value;
    const n2 = document.querySelector('#num2').value;
    const resultDisplay = document.querySelector('#result');

    if (n1 === "" || n2 === "") {
        resultDisplay.textContent = "Ədəd daxil edin!";
        resultDisplay.style.color = "red";
        return;
    }

    const num1 = parseFloat(n1);
    const num2 = parseFloat(n2);
    let result = 0;

    switch (operator) {
        case '+':
            result = num1 + num2;
            break;
        case '-':
            result = num1 - n2;
            break;
        case '*':
            result = num1 * num2;
            break;
        case '/':
            if (num2 === 0) {
                resultDisplay.textContent = "0-a bölmək olmaz!";
                resultDisplay.style.color = "red";
                return;
            }
            result = num1 / num2;
            break;
        default:
            return;
    }

    resultDisplay.textContent = Number.isInteger(result) ? result : result.toFixed(2);
    resultDisplay.style.color = "#764ba2";
};