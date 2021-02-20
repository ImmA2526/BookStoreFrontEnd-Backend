import mainService from "./MainService"

class UserRegistration {

    registration(userData){
        return mainService.post(`/User/registerUser`,userData)
    }

    login(userData){
        return mainService.post(`/User/loginUser`,userData)
    }
}

export default new UserRegistration