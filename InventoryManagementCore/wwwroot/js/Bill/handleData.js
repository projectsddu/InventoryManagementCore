function generateItemsData(prodDetails) {
    var productsData = []
    $(prodDetails).each((e) => {
        const liElem = prodDetails[e]
        console.log(liElem)
        const productId = liElem.children[0].innerText
        const quantity = liElem.children[2].children[0].value
        const sellPrice = liElem.children[3].children[0].value
        const total = parseInt(quantity) * parseInt(sellPrice)
        const finalData = {
            productId,
            quantity,
            sellPrice,
            total
        }
        productsData.push(finalData)
        
    })
    
    return productsData
}

function returnAlert(reason,type) {
    return `<div class="alert alert-${type} alert-dismissible fade show" role="alert">
  <strong>${reason}</strong> 
  <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
</div>`;
}


function handleMakeBill() {
    const alertContainer = document.getElementById("errors")
    alertContainer.innerHTML = ""
    const customerId = document.getElementById("cust-id").innerText;
    var flag = false;
    var reason = ""
    const finalTotal = document.getElementById("finalTotal").innerText
    const finalQty = document.getElementById("finalQty").innerText
    console.log(finalQty)
    const totalPaid = document.getElementById("totalPaid").value
    const productDetails = document.getElementById("product-items").children
    if (finalTotal < 0) {
        flag = true
        reason+=" Selling price cannot be negative!! "
    }
    if (isNaN(finalQty) || finalQty<0) {
        flag = true;
        reason += " Final Quantity must be a valid number!! "
    }
    if (totalPaid == 0 || !totalPaid) {
        flag = true
        reason += " Please enter total amount paid!! " 
    }
    if (customerId == -1) {
        flag = true
        reason += " Please select a customer to make a bill!! "
    }
    if (productDetails.length == 0) {
        flag = true
        reason += " Please Enter some items to make a bill!!"
    }
    if (!flag) {
        // make bill
        if (finalTotal == 0) {
            reason += " Your total bill amount is 0!! Do you really want to make the bill? "
        }
        const productData = generateItemsData(productDetails)
        const finalData = {
            "customerId": parseInt(customerId),
            "productData": productData,
            "totalPaid": parseInt(totalPaid),
            "totalBillAmount": parseInt(finalTotal)
        }
        console.log(finalData)
        $.ajax({
            url: '/Bill/makeBill',
            type: 'POST',
            dataType: "json",
            data: finalData,
            contentType: 'application/x-www-form-urlencoded; charset=utf-8',
            //contentType: "application/json; charset=utf-8",
            success: function (res) {
                console.log(res)
                if (res["messageType"] == "Success") {
                    location.replace("/Bill/Details/" + res["message"])
                }
            }
        })
    }
    
    if (reason != "") {
        
        alertContainer.style.display = "block"
        // donot make the bill
        reasons = reason.split("  ")
        console.log(reasons)
        $(reasons).each((e) => {
            const data = reasons[e]
            const _alert = returnAlert(data, "danger")
            console.log(_alert)
            $(alertContainer).append(_alert)
        })
    }
    else {
        // make bill
    }
    
}