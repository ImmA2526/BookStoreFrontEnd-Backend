import http from "./Http"

class bookService {
    // Add Data  Method 
    addBag(bookData) {
        console.log(bookData)
        return http.post(`/Cart`, bookData, {
            headers: {
                Authorization: localStorage.getItem('AccessToken'),
            },
        });
    }
    // Get Data  Method 
    getBooks() {
        console.log("The Details are Service :")
        return http.get(`/Book`)
    }

}
export default new bookService