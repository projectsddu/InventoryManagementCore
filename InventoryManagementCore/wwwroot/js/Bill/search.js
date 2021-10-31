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
                 const name = response["customerName"];
                 const phoneNo = response["customerPhoneNo"];
                 const address = response["customerAddress"];

                 document.getElementById("cust-name").innerText = name;
                 document.getElementById("cust-phone-no").innerText = phoneNo;
                 document.getElementById("cust-address").innerText = address;
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
                 console.log(response);
                 const name = response["productName"];
                 const sellingPrice = response["sellingPrice"];
                 const quantity = 0;
                 const productCount = document.getElementById("product-items").children.length + 1;
                 console.log($('#product-items'));

                 const productData = `<tr>
                        <th scope="row">${productCount}</th>
                        <td>${name}</td>
                        <td> <input id="qty-${productCount}" class="product-quantity bill-quantity-price-input" type="number" placeholder="Quantity" value="${quantity}"></td>
                        <td><input id="price-${productCount}" class="product-selling-price bill-quantity-price-input" type="number" placeholder="Price" value="${sellingPrice}"> </td>
                        <td>0</td>
                        <td id="${productCount}"><button class="btn btn-sm btn-danger">Delete</button></td>
                    </tr>`

                 $('#product-items').append(productData);
             }
         })
     })
 });






