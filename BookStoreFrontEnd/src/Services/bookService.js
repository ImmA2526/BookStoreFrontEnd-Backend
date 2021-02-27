import http from "./Http"

class bookService {
    // Add Data  Method 
    addBook(bookData) {
        console.log(bookData)
        return http.post(`/books/abooks`, bookData, {
            headers: {
                Authorization: localStorage.getItem('AccessToken'),
            },
        });
    }
    // Get Data  Method 
    getBooks() {
        console.log("The Details are Service :")
        return http.get(`/Book/getAllRecord`, {
            // headers: {
            //     Authorization: localStorage.getItem('AccessToken'),
            // },
        });
    }

}
export default new bookService