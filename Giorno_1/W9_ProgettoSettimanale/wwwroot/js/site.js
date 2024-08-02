
let basePath = "/Order/Count"
let datePath = "/Order/AmountFromDay"

function countOrders() {
    $.ajax({
        url: basePath,
        method: 'GET',
        success: (data) => {
            let div = $('#num')
            div.empty();
            let num = $(`<h1 class="display-5">Numero Ordini Evasi: ${(data)}</h1>`);
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
            let total = $(`<h1 class="display-5">Totale degli incassi degli ordini evasi per il giorno ${date}: €${data}</h1>`);
            div.append(total);
        },
        error: (err) => {
            console.log("Errore", err);
        }
    });
}


$('#CountBtn').on('click', () => {
    countOrders();
})

$('#CountFromDateBtn').on('click', () => {
    countFromDate();
})
