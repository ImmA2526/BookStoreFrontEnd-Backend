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
        console.log("Responsehhg")
        return http.get(`/Cart`), {
            headers: {
                Authorization: localStorage.getItem('AccessToken'),

            },
        };
    }

}
export default new bookService