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
     })
 });






