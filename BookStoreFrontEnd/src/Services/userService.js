import http from './Http'
class UserRegister {

    registration(userData) {
        return http.post('/user/userSignUp', userData)
    }

    login(userData) {
        return http.post(`/user/login`, userData)
    }

    forgot(userData) {
        return http.post(`/user/reset`, userData)
    }

    reset(userData) {
        return http.post(`/user/reset`, userData)
    }

}

export default new UserRegister