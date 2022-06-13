function lettersOnly(input) {
    var regex = /[^a-z]/gi;
    input.value = input.value.replace(regex, "");
}

function lettersAndNumsOnly(input) {
    var regex = /[^a-zA-Z0-9_.-]/gi;
    input.value = input.value.replace(regex, "");
}