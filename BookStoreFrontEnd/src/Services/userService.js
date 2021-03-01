import http from './Http'
class UserRegister {

    registration(userData) {
        return http.post('/User/registerUser', userData)
    }

    login(userData) {
        return http.post(`/User/Login`, userData)
    }

    forgot(email) {
        console.log(email);
        return http.get(`/User/forgotPassword/` + email, null)
    }

    reset(userData) {
        return http.PUT(`/User/resetPassword`, userData)
    }

}

export default new UserRegister