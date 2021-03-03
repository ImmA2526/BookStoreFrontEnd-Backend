import http from './Http_User'
class UserRegister {

    registration(userData) {
        return http.post('/User', userData)
    }

    login(userData) {
        return http.post(`/User/Login`, userData)
    }

    forgot(email) {
        console.log(email);
        return http.get(`/User/` + email, null)
    }

    reset(userData) {
        return http.PUT(`/User`, userData)
    }

}

export default new UserRegister