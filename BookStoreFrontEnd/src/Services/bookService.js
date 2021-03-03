import http from "./Http"

class bookService {
   
    // Get Data  Method 
    getBooks() {
        console.log("The Details are Service :")
        return http.get(`/Book`)
    }

    // Add Data To Cart  Method 
    addBag(bookData) {
        // var get = localStorage.getItem('AccessToken' +'Bearer ');
        console.log(bookData)
        return http.post(`/Cart/addBooks`, bookData, {
            headers: {
                Authorization: localStorage.getItem('AccessToken'),

            },
        });
    }

//Cart Books
    getCartBooks(){
      
        var userId =localStorage.getItem('UserId');
  console.log(userId);
        return http.get(`/Cart/`+userId, {
            headers: {
                Authorization: localStorage.getItem('AccessToken'),

            },
        });
    }

//Update Cart 
updateCart(cartId,bookData){
    console.log(cartId);
    return http.PUT(`/Cart/`+cartId,bookData,null,{
         headers: {
                Authorization: localStorage.getItem('AccessToken'),
            },
    });
}

    // Add Customer  
    AddCustomer(bookData) {
        // var get = localStorage.getItem('AccessToken' +'Bearer ');
        console.log(bookData)
        return http.post(`/Address`, bookData)
        // , {
        //     headers: {
        //         Authorization: localStorage.getItem('AccessToken'),

        //     },
        // });
    }


}
export default new bookService