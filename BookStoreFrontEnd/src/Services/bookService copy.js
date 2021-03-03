import http from "./Http"

class bookService {

// Get Data  Method 
    getBooks() {
        console.log("The Details are Service :")
        return http.get(`/Book`)
    }

// Add Data To Cart  Method 
    addBag(bookData) {
        console.log(bookData)
        return http.post(`/Cart/addBooks`, bookData)
    }

//Cart Books
    getCartBooks(){      
        var userId =localStorage.getItem('UserId');
        console.log(userId);
        return http.get(`/Cart/`+userId)
    }

//Update Cart 
updateCart(cartId,bookData){
    console.log(cartId);
    return http.PUT(`/Cart/`+cartId,bookData)
}

// Add Customer  
    AddCustomer(bookData) {
        console.log(bookData)
        return http.post(`/Address`, bookData)
    }
}

export default new bookService