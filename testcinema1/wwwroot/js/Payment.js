document.addEventListener("DOMContentLoaded", function () {
    // Find the payment form and payment button by id
    var paymentForm = document.getElementById("paymentForm");
    var paymentButton = document.getElementById("paymentButton");

    // Add a click event listener to the payment button
    if (paymentButton) {
        paymentButton.addEventListener("click", function (event) {
            // Prevent the default form submission
            event.preventDefault();

            // Gather payment information
            var paymentInfo = gatherPaymentInfo();

            // Call the pay function with the payment method
            pay("Thanh Toán", paymentInfo);
        });
    }
});

function gatherPaymentInfo() {
    // Get the values from the form fields
    var fullName = document.getElementById("txtCardName").value;
    var email = document.getElementById("txtEmail").value;
    var phoneNumber = document.getElementById("txtCustPhone").value;
    var amount = parseFloat(document.getElementsByClassName("total-numb")[0].innerText.replace(" VNĐ", "").replace(/,/g, ""));

    // Create an object with the gathered information
    var paymentInfo = {
        fullName: fullName,
        email: email,
        phoneNumber: phoneNumber,
        amount: amount
    };

    console.log("Payment information:", paymentInfo);
    return paymentInfo;
}

function pay(paymentMethod, paymentInfo) {
    if (paymentMethod === "Thanh Toán") {
        // Create AJAX request to the server
        $.ajax({
            url: '/Home/Pay',
            method: 'POST',
            data: {
                amount: paymentInfo.amount,
                txtCardName: paymentInfo.fullName,
                txtEmail: paymentInfo.email,
                txtCustPhone: paymentInfo.phoneNumber
            },
            success: function (response) {
                // Handle success if needed
            },
            error: function (error) {
                // Handle error if needed
            }
        });
    }
}
