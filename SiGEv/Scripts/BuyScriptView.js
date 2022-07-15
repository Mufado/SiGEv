
var paymentMethod = document.getElementById('paymentMethod');
if (paymentMethod) {
	paymentMethod.addEventListener('change', function () {
		var radios = document.getElementsByName("paymentMethod");
		var selectedPaymentMethod = document.getElementById("selectedPaymentMethod");
		for (var i = 0; i < radios.length; i++) {
			if (radios[i].checked) {
				if (i == 0) selectedPaymentMethod.innerHTML = "Dinheiro";
				if (i == 1) selectedPaymentMethod.innerHTML = "Cartão de Crédito";
				if (i == 2) selectedPaymentMethod.innerHTML = "Cartão de Débito";
			}
		}
	});

	paymentMethod.addEventListener('change', function () {
		var radios = document.getElementsByName("paymentMethod");
		var parcelas = document.getElementById("parcelas");
		var detailsParcelas = document.getElementById("detailsParcelas");
		radios.forEach(r => {
			if (r.checked && r.id == "paymentMethodCredit") {
				parcelas.classList.remove("d-none");
				detailsParcelas.classList.remove("d-none");
			}
			if (r.checked && r.id != "paymentMethodCredit") {
				parcelas.classList.add("d-none");
				detailsParcelas.classList.add("d-none");
			}
		})

	});
}

var valorTaxado = document.getElementById("valw_rate");
var valorBilhete = parseFloat(document.getElementById("ticket_value"));
var qtdTickets = parseInt(document.getElementById("qtd_tickets"));

console.log(qtdTickets)

var total = valorBilhete * qtdTickets;//Valor que vai ficar no campo "Valor da Compra"
total = total + (total * 0.05)//Valor que vai ficar no campo com a taxa

