
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
            div.append(num)
        },
        error: (err) => {
            console.log("Errore", err)
        }

    });
}

$('#CountBtn').on('click', () => {
    countOrders();
})
$('#CountBtn').on('click', () => {
    countOrders();
})
