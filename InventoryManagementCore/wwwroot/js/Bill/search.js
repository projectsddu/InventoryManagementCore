 $(document).ready(function () {
     $('.search-customer').on('keyup', function () {
         var searchTerm = $(this).val().toLowerCase();
         console.log(searchTerm)
         const address = ".search-customers-list li"
         $(address).each((e) => {
             console.log(e)
             const item = $(address)[e]
             console.log(item)
             const data = item.children[0].innerText.toLowerCase()
             console.log(data, searchTerm)
             if (data.indexOf(searchTerm) === -1) {
                 console.log("No")
                 console.log(item)
                 item.style.display = "none"
                 
             }
             else {
                 console.log("Yes")
                 $(item).show();
             }
         })
         
     });
     $("#products-search").on('keyup', () => {
         var searchTerm = $("#products-search").val().toLowerCase()
         console.log(searchTerm, "ckuck")
         const address = ".search-products-list li"
         $(address).each((e) => {
             const item = $(address)[e]
             const childElem = item.children[0].innerText.toLowerCase()
             if (childElem.indexOf(searchTerm) === -1) {
                 console.log("NO")
                 $(item).hide()
             }
             else {
                 console.log("Yes")
                 $(item).show()
             }
         })
     });
     $('.select-customer').click(function () {
         const id = this.id;
         //console.log(id);

         $.ajax({
             url: '/Bill/fillCustomerDetails/' + id,
             success: function (response) {
                 console.log(response);
                 const customerId = response["customerId"];
                 const name = response["customerName"];
                 const phoneNo = response["customerPhoneNo"];
                 const address = response["customerAddress"];

                 document.getElementById("cust-name").innerText = name;
                 document.getElementById("cust-phone-no").innerText = phoneNo;
                 document.getElementById("cust-address").innerText = address;
                 document.getElementById("cust-id").innerText = customerId;
             },
             method: 'post'
         })
     })
     $('.select-product').click(function () {
         const id = this.id;
         //console.log(id);
         

         $.ajax({
             url: '/Bill/fillProductDetails/' + id,
             method: 'post',
             success: function (response) {
                 //console.log(response);
                 const name = response["productName"];
                 const prodId = response["productId"];
                 const sellingPrice = response["sellingPrice"];
                 const quantity = 0;
                 const productCount = document.getElementById("product-items").children.length + 1;
                 //console.log($('#product-items'));

                 const productData = `<tr id="pdt-main-row-${productCount}">
                        <th scope="row" style="display: none">${prodId}</th>
                        <td>${name}</td>
                        <td> <input min="0" onchange="handleChange(${productCount})" onkeyup = "handleChange(${productCount})"  id="qty-${productCount}" class="product-quantity bill-quantity-price-input" type="number" placeholder="Qty" value="${quantity}"></td>
                        <td><input min="0" onchange="handleChange(${productCount})" onkeyup = "handleChange(${productCount})"  id="price-${productCount}" class="product-selling-price bill-quantity-price-input" type="number" placeholder="Price" value="${sellingPrice}"> </td>
                        <td id="total-${productCount}">0</td>
                        <td id="${productCount}"><button id="${productCount}" onclick="handleDelete(${productCount})" class="pdt-delete btn btn-sm btn-danger">Delete</button></td>
                    </tr>`

                 $('#product-items').append(productData);
             }
         })
     });

     $('.pdt-delete').click(function () {
         const id = this.id;
         //console.log(id);
         console.log("clicked");
     })
 });

function handleFinalTotal() {
    const parent = document.getElementById("product-items").children
    var total = 0;
    var totalQty = 0;
    $(parent).each((e) => {
        const childElem = parent[e]
        const childsChild = childElem.children[4].innerText
        const qty = childElem.children[2].children[0].value
        total += parseInt(childsChild)
        totalQty += parseInt(qty)
    })
    document.getElementById("finalTotal").innerText = total
    document.getElementById("finalQty").innerText = totalQty
    
}

function handleChange(idx) {
    const price = document.getElementById("price-" + idx).value
    const qty = document.getElementById("qty-" + idx).value
    const totalElem = document.getElementById("total-" + idx)
    totalElem.innerText = qty * price
    handleFinalTotal()
}

function handleDelete(idx) {
    console.log("delete clicked");
    document.getElementById("pdt-main-row-" + idx).remove();
    handleFinalTotal();
    //deleteRoutine();
}

function deleteRoutine() {
    const parent = document.getElementById("product-items").children

    $(parent).each((e) => {
        const childElem = parent[e].children[0]
        console.log(childElem);
        childElem.innerText = e + 1;
    })
}

    


