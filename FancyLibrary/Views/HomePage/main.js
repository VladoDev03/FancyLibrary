const text = "FancyLibrary"

let index = 1;

function writeText() {
    let element = document.getElementById('title')
    
    element.innerText = text.slice(0, index);
    index++;

    if (index > text.length) {
        index = 1;
    }
}

setInterval(writeText, 350);