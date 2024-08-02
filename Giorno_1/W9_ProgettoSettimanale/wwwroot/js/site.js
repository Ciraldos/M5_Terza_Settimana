
let basePath = "/Order/Count"
let datePath = "/Order/AmountFromDay"
let numPath = "/Order/GetNumbersProductFromOrders"


function countOrders() {
    $.ajax({
        url: basePath,
        method: 'GET',
        success: (data) => {
            let div = $('#num')
            div.empty();
            let num = $(`<h1>Numero Ordini Evasi:<br><span class="text-danger"> ${(data)}</span></h1>`);
            div.append(num);
        },
        error: (err) => {
            console.log("Errore", err)
        }

    });
}
function countFromDate() {
    let date = $('#dateInput').val(); 
    $.ajax({
        url: `${datePath}?date=${date}`, 
        method: 'GET',
        success: (data) => {
            let div = $('#date');
            div.empty();
            let total = $(`<h1 class="mb-4">Totale degli incassi degli ordini evasi per il giorno ${date}:<br> <span class="text-danger">€${data}</span></h1>`);
            div.append(total);
        },
        error: (err) => {
            console.log("Errore", err);
        }
    });
}

function getNumProducts() {
    $.ajax({
        url: numPath,
        method: 'GET',
        success: (data) => {
            let span = $('#numProduct');
            span.text(`${data}`);
        },
        error: (err) => {
            console.error("Errore nella chiamata AJAX:", err);
        }
    });
}


$('#CountBtn').on('click', () => {
    countOrders();
})

$('#CountFromDateBtn').on('click', () => {
    countFromDate();
})

$(document).ready(() => {
    getNumProducts();
});