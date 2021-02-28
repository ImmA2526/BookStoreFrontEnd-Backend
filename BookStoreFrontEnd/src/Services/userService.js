import http from './Http'
class UserRegister {

    registration(userData) {
        return http.post('/User/registerUser',userData)
    }

    login(userData) {
        return http.post(`/User/loginUser`, userData)
    }

    forgot(userData) {
        console.log(userData);
        return http.post(`/User/forgotPassword?Email=`+userData)
    }

    reset(userData) {
        return http.post(`/User/resetPassword`, userData)
    }

}

export default new UserRegister