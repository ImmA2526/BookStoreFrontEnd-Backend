import http from "./CartServices"

class bookService {

// Get Data  Method 
    getBooks() {
        console.log("The Details are Service :")
        return http.get(`/Book`)
    }

// Add Data To Cart  Method 
    addBag(bookData) {
        console.log("service data",bookData)
        return http.post(`/Cart`, bookData)
    }

// Display Cart Books
    getCartBooks() {
        var userId = localStorage.getItem('UserId');
        console.log(userId);
        return http.get(`/Cart/` + userId)
    }

// Update Cart Books 
    updateCart(bookData) {
        console.log(bookData);
        return http.PUT(`/Cart/`, bookData)
    }

//Remove From Cart 
    removeCart(cartId) {
        console.log(cartId);
        // var cartId = localStorage.getItem('cartId');
        return http.DELETE(`/Cart/`+cartId)
    }

//Add Book To Wishlist
    addToWishlist(bookData){
        console.log(bookData)
        return http.post(`/WishList`,bookData)
    }

//get item From WishList
    getWishListBooks(){
        var userId = localStorage.getItem('UserId');
        console.log(userId);
        return http.get(`/WishList/` + userId)
    }

//Remove Item From WishList
    RemoveWishlistItem(wishId) {
        console.log("Wishlist Id is: " + wishId);
        return http.DELETE(`/WishList/` + wishId)
    }
//Order Checkout

    orderCheckout(bookData) {
        console.log(bookData)
        return http.post(`/Order`, bookData)
    }

//Plus and Minus Items 
// updateCartBookQnty(bookCount,bookId){
//     console.log(bookCount);
//     console.log(bookId);
//     return http.PUT(`/Book/addBookCount/`+bookCount+'/'+bookId)
// }


// Add Customer  
    AddCustomer(bookData) {
        console.log(bookData)
        return http.post(`/Address`, bookData)
    }

}
export default new bookService